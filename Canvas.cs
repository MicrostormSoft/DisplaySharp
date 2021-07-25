using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplaySharp
{
    public class Canvas : IDisposable
    {
        public readonly string DeviceName;
        public readonly IntPtr Handler;
        public readonly Size Size;
        public int Width => Size.Width;
        public int Height => Size.Height;
        private bool disposedValue;

        public Canvas(string device)
        {
            DeviceName = device;
            Handler = Native.init(device);
            if (Handler == IntPtr.Zero) throw new InvalidOperationException("Can't start device " + device);
            Size = new Size((int)Native.width(Handler), (int)Native.height(Handler));
        }

        public void DrawBitmap(Bitmap map)
        {
            map = ResizeImage(map,Width,Height);
            var items = map.LockBits(new Rectangle(0, 0, Width, Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Native.fill_bitmap(Handler, items.Scan0, (uint)(Width * Height * 4));
        }

        public void DrawPixel(Point loc,Color color)
        {
            Native.draw_pixel(Handler, (uint)loc.X, (uint)loc.Y, (uint)color.ToArgb());
        }

        public void DrawLine(Point start,Point end,Color color)
        {
            Native.draw_line(Handler, (uint)start.X, (uint)start.Y, (uint)end.X, (uint)end.Y, (uint)color.ToArgb());
        }

        public void DrawRectangle(Rectangle rect,Color color,bool fill = false)
        {
            if (fill)
            {
                Native.fill_rectangle(Handler, (uint)rect.Left, (uint)rect.Top, (uint)rect.Right, (uint)rect.Bottom, (uint)color.ToArgb());
            }
            else
            {
                Native.draw_rectangle(Handler, (uint)rect.Left, (uint)rect.Top, (uint)rect.Right, (uint)rect.Bottom, (uint)color.ToArgb());
            }
        }

        public void DrawCircle(Point center,int r,Color color,bool fill = false)
        {
            if (fill)
            {
                Native.fill_circle(Handler, (uint)center.X, (uint)center.Y, (uint)r, (uint)color.ToArgb());
            }
            else
            {
                Native.draw_circle(Handler, (uint)center.X, (uint)center.Y, (uint)r, (uint)color.ToArgb());
            }
        }

        public void Clear(Color background)
        {
            Native.background(Handler, (uint)background.ToArgb());
        }

        public static Bitmap ResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                g.InterpolationMode = InterpolationMode.Low;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并替代终结器
                // TODO: 将大型字段设置为 null
                Native.sc_close();
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        ~Canvas()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: false);
        }

        void IDisposable.Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
