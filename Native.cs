using System;
using System.Runtime.InteropServices;

namespace DisplaySharp
{
    public class Native
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct buffer_object
        {
            public UInt32 width;
            public UInt32 height;
            public UInt32 pitch;
            public UInt32 handle;
            public UInt32 size;
            public IntPtr vaddr;
            public UInt32 fb_id;
        };


        [DllImport("libdisplaysharp")]
        public static extern IntPtr init(string device);
        [DllImport("libdisplaysharp")]
        public static extern void sc_close();
        [DllImport("libdisplaysharp")]
        public static extern void draw_pixel(IntPtr handler, UInt32 x, UInt32 y, UInt32 color);
        [DllImport("libdisplaysharp")]
        public static extern void draw_line(IntPtr handler, UInt32 x1, UInt32 y1, UInt32 x2, UInt32 y2, uint color);
        [DllImport("libdisplaysharp")]
        public static extern void draw_rectangle(IntPtr handler, UInt32 x1, UInt32 y1, UInt32 x2, UInt32 y2, uint color);
        [DllImport("libdisplaysharp")]
        public static extern void fill_rectangle(IntPtr handler, UInt32 x1, UInt32 y1, UInt32 x2, UInt32 y2, uint color);
        [DllImport("libdisplaysharp")]
        public static extern void draw_circle(IntPtr handler, UInt32 x, UInt32 y, UInt32 r, uint color);
        [DllImport("libdisplaysharp")]
        public static extern void fill_circle(IntPtr handler, UInt32 x, UInt32 y, UInt32 r, uint color);
        [DllImport("libdisplaysharp")]
        public static extern void fill_bitmap(IntPtr handler, IntPtr bitmap, uint size);
        [DllImport("libdisplaysharp")]
        public static extern void fill_bitmap_area(IntPtr handler, IntPtr bitmap, UInt32 x1, UInt32 y1, UInt32 x2, UInt32 y2);
        [DllImport("libdisplaysharp")]
        public static extern UInt32 background(IntPtr handler,uint color);
        [DllImport("libdisplaysharp")]
        public static extern UInt32 height(IntPtr handler);
        [DllImport("libdisplaysharp")]
        public static extern UInt32 width(IntPtr handler);
    }
}
