using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace Tomogram_visualiser
{
    internal class View
    {
        private int VBOtexture;
        private Bitmap textureImage;
        public void Load2DTexture()
        {
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);
            BitmapData data = textureImage.LockBits(new System.Drawing.Rectangle(0, 0, textureImage.Width, textureImage.Height), 
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            textureImage.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            ErrorCode Er = GL.GetError();
            string str = Er.ToString();
        }
        public void generateTexrureImage(int layerNum, int min, int width)
        {
            textureImage = new Bitmap(Bin.X, Bin.Y);
            for(int i = 0; i < Bin.X; i++) 
                for(int j = 0; j < Bin.Y; j++)
                {
                    int pixelNumber = i + j * Bin.X + layerNum * Bin.X * Bin.Y;
                    textureImage.SetPixel(i, j, TransferFunction(Bin.array[pixelNumber], min, width));
                }
        }
        public void DrawTexture()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);


            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(2, 8);
            GL.TexCoord2(0f, 1);
            GL.Vertex2(0, Bin.Y);
            GL.TexCoord2(1F, 1);
            GL.Vertex2(Bin.X, Bin.Y);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(Bin.X, 0);
            GL.End();

            GL.Disable(EnableCap.Texture2D);
        }

        public void SetupView(int width, int height)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, Bin.X, 0, Bin.Y, -1, 1);
            GL.Viewport(0, 0, width, height);
        }
        public void DrawQuads(int layerNum, int min, int width)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Begin(BeginMode.Quads);
            for(int x = 0; x < Bin.X - 1; x++)
                for(int y = 0; y <  Bin.Y - 1; y++)
                {
                    short value;

                    value = Bin.array[x + y * Bin.X + layerNum * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value, min, width));
                    GL.Vertex2(x, y);

                    value = Bin.array[x + (y + 1) * Bin.X + layerNum * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value, min, width));
                    GL.Vertex2(x, y + 1);

                    value = Bin.array[(x + 1) + (y + 1) * Bin.X + layerNum * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value, min, width));
                    GL.Vertex2(x + 1, y + 1);

                    value = Bin.array[(x + 1) + y * Bin.X + layerNum * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value, min, width));
                    GL.Vertex2(x + 1, y);
                }
            GL.End();
        }
        public void DrawQuadsStrip(int layerNum, int min, int width)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            for (int y = 0; y < Bin.Y - 1; y++)
            {
                GL.Begin(BeginMode.QuadStrip);
                for (int x = 0; x < Bin.X; x++)
                {
                    short value;
                    value = Bin.array[x + y * Bin.X + layerNum * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value, min, width));
                    GL.Vertex2(x, y);

                    value = Bin.array[x + (y + 1) * Bin.X + layerNum * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value, min, width));
                    GL.Vertex2(x, y + 1);

                }
                GL.End();
            }
        }
        /*public Color TransferFunction(short value)
        {
            int min = 0;
            int max = 2000;
            int newVal = Clamp((value - min) * 255 / (max - min), 0, 255);
            return Color.FromArgb(255, newVal, newVal, newVal);
        }*/
        Color TransferFunction(short value, int min, int width)
        {
            int max = min + width;
            int newVal = Clamp((value - min) * 255 / (max - min), 0, 255);
            return Color.FromArgb(newVal, newVal, newVal);
        }
        public int Clamp(int value, int min, int max)
        {
            if (value > max) return max;
            if (value < min) return min;
            return value;
        }
    }
}
