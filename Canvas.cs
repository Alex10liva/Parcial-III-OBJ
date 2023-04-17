using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using System.Numerics;
using System.Security.Policy;
using System.Diagnostics;
using System.Reflection;

namespace Parcial_3
{
    public class Canvas
    {
        int counter = 1;
        public Bitmap bmp;
        byte[] bits;
        int pixelFormatSize, stride;
        Graphics g;
        int Width, Height;
        float viewport_size = 1;
        float projection_plane_z = 1;
        Model objModel;
        public Camera camera = new(new Vertex(0, 0, 0), Mtx.RotY(0));
        Instance[] instances;
        Size size;
        ObjFileReader obj;
        Vertex[] vertices;
        Triangle[] triangles;
        public bool fileLoaded = false;

        public void ButtonClicked()
        {
            obj = new ObjFileReader();
            OpenFileDialog openFileDialog = new();

            openFileDialog.Filter = "obj files (*.obj)|*.obj";

            if (fileLoaded == false)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileLoaded = true;
                    obj.LoadObj(openFileDialog.FileName);
                    createObj();
                }
            }
        }

        public Canvas(Size size)
        {
            bmp = new Bitmap(size.Width, size.Height);
            this.size = size;
            Init(size.Width, size.Height);
        }

        private void createObj()
        {
            vertices = new Vertex[obj.vertices.Count];

            for (int i = 0; i < obj.vertices.Count; i++)
            {
                vertices[i] = obj.vertices[i];
            }

            triangles = new Triangle[obj.indices.Count / 3];

            int j = 0;
            for (int i = 0; i < obj.indices.Count; i++)
            {
                if (i % 3 == 0)
                {
                    triangles[j] = new Triangle(obj.indices[i], obj.indices[i + 1], obj.indices[i + 2], Color.White);
                    j++;
                }
            }
        }

        public void Init(int width, int height)
        {
            PixelFormat format;
            GCHandle handle;
            IntPtr bitPtr;
            int padding;

            format = PixelFormat.Format32bppArgb;
            Width = width;
            Height = height;
            pixelFormatSize = Image.GetPixelFormatSize(format) / 8; // 8 bits = 1 byte
            stride = width * pixelFormatSize;                       // total pixels (width) times ARGB (4)
            padding = (stride % 4);                                 // PADD = move every pixel in bytes
            stride += padding == 0 ? 0 : 4 - padding;               // 4 byte multiple Alpha, Red, Green, BLue
            bits = new byte[stride * height];                       // total pixels (width) times ARGB (4) times Height
            handle = GCHandle.Alloc(bits, GCHandleType.Pinned);     // To lock the memory
            bitPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0);
            bmp = new Bitmap(width, height, stride, format, bitPtr);

            g = Graphics.FromImage(bmp);                         // Para hacer pruebas regulares

        }
        public void SetModelInstances(String typeRotation, float scale, int angle)
        {
            objModel = new Model(vertices, triangles);
            switch (typeRotation)
            {
                case "NoRotation":
                    instances = new Instance[] {
                                            new Instance(objModel, new Vertex(0, 0, 10f), Mtx.Identity, scale)};
                    break;
                case "xRotating":
                    instances = new Instance[] {
                                            new Instance(objModel, new Vertex(0, 0, 10f), Mtx.RotX(angle), scale)};
                    break;
                case "yRotating":
                    instances = new Instance[] {
                                            new Instance(objModel, new Vertex(0, 0, 10f), Mtx.RotY(angle), scale)};
                    break;
                case "zRotating":
                    instances = new Instance[] {
                                            new Instance(objModel, new Vertex(0, 0, 10f), Mtx.RotZ(angle), scale)};
                    break;
                case "allRotating":
                    instances = new Instance[] {
                                            new Instance(objModel, new Vertex(0, 0, 10f), Mtx.RotateALL(angle), scale)};
                    break;
            }
            if(fileLoaded)
                Render();
        }

        private void Render()
        {
            RenderScene(camera, instances);
        }

        public void PutPixel(int x, int y, Color c)
        {
            x = Width / 2 + x;
            y = Height / 2 - y - 1;

            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return;
            }

            int res = (int)((x * pixelFormatSize) + (y * stride));
            bits[res + 0] = c.B; // (byte)Blue;
            bits[res + 1] = c.G; // (byte)Green;
            bits[res + 2] = c.R; // (byte)Red;
            bits[res + 3] = c.A; // (byte)ALPHA;
        }

        public void FastClear()
        {
            unsafe
            {
                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadWrite, bmp.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y => // usando proceso en paralelo
                {
                    byte* bits = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        bits[x + 0] = 0; // (byte) Blue
                        bits[x + 1] = 0; // (byte) Green
                        bits[x + 2] = 0; // (byte) Red
                        bits[x + 3] = 0; // (byte) Alpha
                    }
                });
                bmp.UnlockBits(bitmapData);
            }
        }

        public static List<float> Interpolate(int i0, float d0, int i1, float d1)
        {
            if (i0 == i1)
            {
                return new List<float> { d0 };
            }

            List<float> values = new List<float>();
            float a = (d1 - d0) / (i1 - i0);
            float d = d0;
            for (int i = i0; i <= i1; i++)
            {
                values.Add(d);
                d += a;
            }

            return values;
        }

        public void DrawLine(Vertex p0, Vertex p1, Color color)
        {
            float dx = p1.x - p0.x, dy = p1.y - p0.y;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                // The line is horizontal-ish. Make sure it's left to right.
                if (dx < 0) { var swap = p0; p0 = p1; p1 = swap; }

                // Compute the Y values and draw.
                var ys = Interpolate((int)p0.x, p0.y, (int)p1.x, p1.y);
                for (int x = (int)p0.x; x <= (int)p1.x; x++)
                {
                    try
                    {
                        PutPixel(x, (int)ys[(int)(x - p0.x)], color);
                    } catch (Exception) {
                    }
                }
            }
            else
            {
                // The line is verical-ish. Make sure it's bottom to top.
                if (dy < 0) { var swap = p0; p0 = p1; p1 = swap; }

                // Compute the X values and draw.
                var xs = Interpolate((int)p0.y, p0.x, (int)p1.y, p1.x);
                for (int y = (int)p0.y; y <= (int)p1.y; y++)
                {
                    try
                    {
                        PutPixel((int)xs[(int)(y - p0.y)], y, color);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void Swap(ref Vertex p1, ref Vertex p2)
        {
            Vertex temp = p1;
            p1 = p2;
            p2 = temp;
        }

        public void DrawWireframeTriangle(Vertex p0, Vertex p1, Vertex p2, Color color)
        {
            DrawLine(p0, p1, color);
            DrawLine(p1, p2, color);
            DrawLine(p2, p0, color);
            
            //DrawFilledTriangle(p0, p1, p2, color);
            //DrawShadedTriangle(p0, p1, p2, color);
        }

        public void DrawFilledTriangle(Vertex p0, Vertex p1, Vertex p2, Color color)
        {
            if (p1.y < p0.y)
                Swap(ref p1, ref p0);
            if (p2.y < p0.y)
                Swap(ref p2, ref p0);
            if (p2.y < p1.y)
                Swap(ref p2, ref p1);

            var x01 = Interpolate((int)p0.y, p0.x, (int)p1.y, p1.x);
            var x12 = Interpolate((int)p1.y, p1.x, (int)p2.y, p2.x);
            var x02 = Interpolate((int)p0.y, p0.x, (int)p2.y, p2.x);

            if (x01.Count > 0)
            {
                x01.RemoveAt(x01.Count - 1);
            }

            var x012 = x01.Concat(x12).ToList();

            List<float> x_left, x_right;

            int m = (int)Math.Floor((double)(x02.Count / 2));
            if (x02[m] < x012[m])
            {
                x_left = x02;
                x_right = x012;
            }
            else
            {
                x_left = x012;
                x_right = x02;
            }

            // Draw the horizontal segments 
            for (int y = (int)p0.y; y <= p2.y; y++)
            {
                for (int x = (int)x_left[(int)(y - p0.y)]; x <= (int)x_right[(int)(y - p0.y)]; x++)
                {
                    PutPixel(x, y, color);
                }
            }
        }

        public void DrawShadedTriangle(Vertex p0, Vertex p1, Vertex p2, Color color)
        {
            // Sort the points so that y0 <= y1 <= y2
            if (p1.y < p0.y)
                Swap(ref p1, ref p0);
            if (p2.y < p0.y)
                Swap(ref p2, ref p0);
            if (p2.y < p1.y)
                Swap(ref p2, ref p1);

            // Compute the x coordinates and h values of the triangle edges
            var x01 = Interpolate((int)p0.y, p0.x, (int)p1.y, p1.x);
            var h01 = Interpolate((int)p0.y, p0.h, (int)p1.y, p1.h);

            var x12 = Interpolate((int)p1.y, p1.x, (int)p2.y, p2.x);
            var h12 = Interpolate((int)p1.y, p1.h, (int)p2.y, p2.h);

            var x02 = Interpolate((int)p0.y, p0.x, (int)p2.y, p2.x);
            var h02 = Interpolate((int)p0.y, p0.h, (int)p2.y, p2.h);

            // Concatenate the short sides
            if (x01.Count > 0)
            {
                x01.RemoveAt(x01.Count - 1);
            }
            var x012 = x01.Concat(x12).ToList();

            if (h01.Count > 0)
            {
                h01.RemoveAt(h01.Count - 1);
            }
            var h012 = h01.Concat(h12).ToList();

            List<float> x_left, x_right, h_left, h_right;

            // Determine which is left and which is right
            int m = (int)Math.Floor((double)(x02.Count / 2));
            if (x02[m] < x012[m])
            {
                x_left = x02;
                h_left = h02;

                x_right = x012;
                h_right = h012;
            }
            else
            {
                x_left = x012;
                h_left = h012;

                x_right = x02;
                h_right = h02;
            }

            // Draw the horizontal segments
            for (int y = (int)p0.y; y <= (int)p2.y; y++)
            {
                int x_l = (int)x_left[y - (int)p0.y];
                int x_r = (int)x_right[y - (int)p0.y];

                List<float> h_segment = Interpolate(x_l, h_left[y - (int)p0.y], x_r, h_right[y - (int)p0.y]);

                for (int x = x_l; x <= x_r; x++)
                {
                    PutPixel(x, y, Multiply(h_segment[x - x_l], color));
                }
            }
        }

        public Vertex ViewportToCanvas(Vertex p2d)
        {
            float vW = (float)Width / Height;
            return new Vertex((p2d.x * Width / vW), (p2d.y * Height / viewport_size), 0, p2d.h);
        }

        public Vertex ProjectVertex(Vertex v)
        {
            return ViewportToCanvas(new Vertex(v.x * projection_plane_z / v.z, v.y * projection_plane_z / v.z, 0, v.h));
        }
    
        public void RenderTriangle(Triangle triangle, List<Vertex> projected)
        {
            DrawWireframeTriangle(projected[triangle.v0],
                                  projected[triangle.v1],
                                  projected[triangle.v2],
                                  triangle.color);
        }

        private void RenderModel(Instance instance, Mtx transform)
        {
            List<Vertex> projected = new List<Vertex>();
            Model model = instance.model;

            if(fileLoaded)
            {
                for (int i = 0; i < model.vertices.Length; i++)
                {
                    projected.Add(ProjectVertex(transform * model.vertices[i]));
                }

                for (int i = 0; i < model.triangles.Length; i++)
                {
                    RenderTriangle(model.triangles[i], projected);
                }
            }
        }

        public void RenderScene(Camera camera, Instance[] instances)
        {
            Mtx cameraMatrix;
            Mtx transform;

            cameraMatrix = (camera.orientation.Transposed()) * Mtx.MakeTranslationMatrix(-camera.position) * Mtx.FOV();
            for (int i = 0; i < instances.Length; i++)
            {
                transform = (cameraMatrix * instances[i].transform);
                RenderModel(instances[i], transform);
            }
        }

        private Color Multiply(float factor, Color color)
        {
            return Color.FromArgb((int)(color.R * factor), (int)(color.G * factor), (int)(color.B * factor));
        }
    }
}
