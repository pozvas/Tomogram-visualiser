using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace Tomogram_visualiser
{
    enum Mode
    {
        QUADS,
        TEXTURE
    }
    public partial class Form1 : Form
    {
        private Bin bin;
        private View view;
        private bool loaded = false;
        private int currentLayer;
        private int FrameCount;
        DateTime NextFPSUpdate = DateTime.Now.AddSeconds(1);
        bool needReload = false;
        Mode mode = Mode.QUADS;
        public Form1()
        {
            InitializeComponent();
            bin = new Bin();
            view = new View();
            radioButton1.Select();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object? sender, EventArgs e)
        {
            while (glControl1.IsIdle)
            {
                displayFPS();
                glControl1.Invalidate();
            }
        }

        private void displayFPS()
        {
            if (DateTime.Now >= NextFPSUpdate)
            {
                this.Text = String.Format("CT Visualizer (fps={0})", FrameCount);
                NextFPSUpdate = DateTime.Now.AddSeconds(1);
                FrameCount = 0;
            }
            FrameCount++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string str = dialog.FileName;
                bin.readBIN(str);
                view.SetupView(glControl1.Width, glControl1.Height);
                loaded = true;
                glControl1.Invalidate();
                trackBar1.Maximum = Bin.Z - 1;

            }
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (loaded)
            {
                if (mode == Mode.QUADS)
                    view.DrawQuads(currentLayer);
                else
                {
                    if (needReload)
                    {
                        view.generateTexrureImage(currentLayer);
                        view.Load2DTexture();
                        needReload = false;
                    }
                    view.DrawTexture();
                }
                glControl1.SwapBuffers();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentLayer = trackBar1.Value;
            needReload = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            mode = Mode.QUADS;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mode = Mode.TEXTURE;
        }
    }
}