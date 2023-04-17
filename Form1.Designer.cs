namespace Parcial_3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FileBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TBSize = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.RotateABTN = new System.Windows.Forms.Button();
            this.RotateZBTN = new System.Windows.Forms.Button();
            this.RotateXBTN = new System.Windows.Forms.Button();
            this.RotateYBTN = new System.Windows.Forms.Button();
            this.PCT_Canvas = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBSize)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FileBTN);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TBSize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1902, 65);
            this.panel1.TabIndex = 0;
            // 
            // FileBTN
            // 
            this.FileBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FileBTN.FlatAppearance.BorderSize = 0;
            this.FileBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileBTN.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FileBTN.ForeColor = System.Drawing.Color.White;
            this.FileBTN.Location = new System.Drawing.Point(19, 7);
            this.FileBTN.Name = "FileBTN";
            this.FileBTN.Size = new System.Drawing.Size(224, 52);
            this.FileBTN.TabIndex = 4;
            this.FileBTN.Text = "Select file";
            this.FileBTN.UseVisualStyleBackColor = false;
            this.FileBTN.Click += new System.EventHandler(this.FileBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(258, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Scale";
            // 
            // TBSize
            // 
            this.TBSize.Location = new System.Drawing.Point(332, 16);
            this.TBSize.Maximum = 400;
            this.TBSize.Minimum = 150;
            this.TBSize.Name = "TBSize";
            this.TBSize.Size = new System.Drawing.Size(1404, 56);
            this.TBSize.TabIndex = 0;
            this.TBSize.Value = 260;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.PCT_Canvas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1902, 968);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.RotateABTN);
            this.panel3.Controls.Add(this.RotateZBTN);
            this.panel3.Controls.Add(this.RotateXBTN);
            this.panel3.Controls.Add(this.RotateYBTN);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 903);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1902, 65);
            this.panel3.TabIndex = 1;
            // 
            // RotateABTN
            // 
            this.RotateABTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.RotateABTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RotateABTN.FlatAppearance.BorderSize = 0;
            this.RotateABTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RotateABTN.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RotateABTN.ForeColor = System.Drawing.Color.White;
            this.RotateABTN.Location = new System.Drawing.Point(1313, 5);
            this.RotateABTN.Name = "RotateABTN";
            this.RotateABTN.Size = new System.Drawing.Size(224, 52);
            this.RotateABTN.TabIndex = 3;
            this.RotateABTN.Text = "Rotate All";
            this.RotateABTN.UseVisualStyleBackColor = false;
            this.RotateABTN.Click += new System.EventHandler(this.RotateABTN_Click);
            // 
            // RotateZBTN
            // 
            this.RotateZBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.RotateZBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RotateZBTN.FlatAppearance.BorderSize = 0;
            this.RotateZBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RotateZBTN.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RotateZBTN.ForeColor = System.Drawing.Color.White;
            this.RotateZBTN.Location = new System.Drawing.Point(998, 5);
            this.RotateZBTN.Name = "RotateZBTN";
            this.RotateZBTN.Size = new System.Drawing.Size(224, 52);
            this.RotateZBTN.TabIndex = 2;
            this.RotateZBTN.Text = "Rotate Z";
            this.RotateZBTN.UseVisualStyleBackColor = false;
            this.RotateZBTN.Click += new System.EventHandler(this.RotateZBTN_Click);
            // 
            // RotateXBTN
            // 
            this.RotateXBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.RotateXBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RotateXBTN.FlatAppearance.BorderSize = 0;
            this.RotateXBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RotateXBTN.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RotateXBTN.ForeColor = System.Drawing.Color.White;
            this.RotateXBTN.Location = new System.Drawing.Point(368, 5);
            this.RotateXBTN.Name = "RotateXBTN";
            this.RotateXBTN.Size = new System.Drawing.Size(224, 52);
            this.RotateXBTN.TabIndex = 1;
            this.RotateXBTN.Text = "Rotate X";
            this.RotateXBTN.UseVisualStyleBackColor = false;
            this.RotateXBTN.Click += new System.EventHandler(this.RotateXBTN_Click);
            // 
            // RotateYBTN
            // 
            this.RotateYBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.RotateYBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RotateYBTN.FlatAppearance.BorderSize = 0;
            this.RotateYBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RotateYBTN.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RotateYBTN.ForeColor = System.Drawing.Color.White;
            this.RotateYBTN.Location = new System.Drawing.Point(683, 5);
            this.RotateYBTN.Name = "RotateYBTN";
            this.RotateYBTN.Size = new System.Drawing.Size(224, 52);
            this.RotateYBTN.TabIndex = 0;
            this.RotateYBTN.Text = "Rotate Y";
            this.RotateYBTN.UseVisualStyleBackColor = false;
            this.RotateYBTN.Click += new System.EventHandler(this.RotateYBTN_Click);
            // 
            // PCT_Canvas
            // 
            this.PCT_Canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.PCT_Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCT_Canvas.Location = new System.Drawing.Point(0, 0);
            this.PCT_Canvas.Name = "PCT_Canvas";
            this.PCT_Canvas.Size = new System.Drawing.Size(1902, 968);
            this.PCT_Canvas.TabIndex = 0;
            this.PCT_Canvas.TabStop = false;
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 10;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1918, 1040);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBSize)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_Canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox PCT_Canvas;
        private System.Windows.Forms.Timer Timer;
        private TrackBar TBSize;
        private Panel panel3;
        private Button RotateYBTN;
        private Button RotateABTN;
        private Button RotateZBTN;
        private Button RotateXBTN;
        private Label label1;
        private Button FileBTN;
    }
}