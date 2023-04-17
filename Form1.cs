using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Windows.Forms;

namespace Parcial_3
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        Graphics g;
        Point l1, l2, l3, l4;
        Point origen;
        int width, height, wMid, hMid;
        bool xRotating, yRotating, zRotating, allRotating;
        int counterAngle = 0;
        Pen marcadorL = new Pen(Color.Gray, 1);
        int velocidad = 3;

        private void FileBTN_Click(object sender, EventArgs e)
        {
            if (!canvas.fileLoaded)
            {
                canvas.ButtonClicked();
            }
            else
            {
                canvas.fileLoaded = false;
                canvas.ButtonClicked();
            }
            xRotating = yRotating = zRotating = allRotating = false;
            counterAngle = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            canvas = new Canvas(PCT_Canvas.Size);
            PCT_Canvas.Image = canvas.bmp;
            g = Graphics.FromImage(canvas.bmp);
            InitPB();
            xRotating = yRotating = zRotating = allRotating = false;

            width = PCT_Canvas.Width;
            height = PCT_Canvas.Height;
            wMid = width / 2;
            hMid = height / 2;
            origen = new Point(wMid, hMid);

            if(canvas.fileLoaded)
                canvas.SetModelInstances("NoRotation", TBSize.Value / 100f, counterAngle);
            PCT_Canvas.Invalidate();
        }

        private void RotateXBTN_Click(object sender, EventArgs e)
        {
            if(canvas.fileLoaded)
            {
                xRotating = true;
                yRotating = zRotating = false;
                if(!xRotating)
                    counterAngle = 1;
            }
        }

        private void RotateYBTN_Click(object sender, EventArgs e)
        {
            if(canvas.fileLoaded)
            {
                yRotating = true;
                xRotating = zRotating = false;
                if (!yRotating)
                    counterAngle = 1;
            }
        }

        private void RotateZBTN_Click(object sender, EventArgs e)
        {
            if (canvas.fileLoaded)
            {
                zRotating = true;
                xRotating = yRotating = false;
                if (!zRotating)
                    counterAngle = 1;
            }
        }

        private void RotateABTN_Click(object sender, EventArgs e)
        {
            if(canvas.fileLoaded)
            {
                allRotating = true;
                xRotating = yRotating = zRotating = false;
                if (!allRotating)
                    counterAngle = 1;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (canvas.fileLoaded)
            {
                canvas.FastClear();
                //FileBTN.Visible = false;
            }
            InitPB();


            if (canvas.fileLoaded)
            {
                if (xRotating)
                {
                    canvas.SetModelInstances("xRotating", TBSize.Value / 100f, counterAngle);
                }
                else if (yRotating)
                {
                    canvas.SetModelInstances("yRotating", TBSize.Value / 100f, counterAngle);
                }
                else if (zRotating)
                {
                    canvas.SetModelInstances("zRotating", TBSize.Value / 100f, counterAngle);
                }
                else if (allRotating)
                {
                    canvas.SetModelInstances("allRotating", TBSize.Value / 100f, counterAngle);
                }
                else
                {
                    canvas.SetModelInstances("NoRotation", TBSize.Value / 100f, counterAngle);
                }
            }
            
            PCT_Canvas.Invalidate();
            if (xRotating || yRotating || zRotating || allRotating)
            {
                if (counterAngle < 360)
                    counterAngle+=velocidad;
                else
                    counterAngle = 0;
            }
        }

        private void InitPB()
        {
            // points to draw intersecting lines (center of the picture box)
            l1 = new Point(origen.X, 0);
            l2 = new Point(origen.X, height);
            l3 = new Point(0, origen.Y);
            l4 = new Point(width, origen.Y);

            // Draw intersecting lines
            g.DrawLine(marcadorL, l1, l2);
            g.DrawLine(marcadorL, l3, l4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}