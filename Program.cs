using Gtk;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using SkiaSharp.Views.Gtk;

namespace SkiaSharpTest
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Application.Init();

            var win = new Window(WindowType.Toplevel)
            {
                Title = "SkiaSharp on .NET Core with GTK#",
                WindowPosition = WindowPosition.CenterOnParent,
                DefaultWidth = 640,
                DefaultHeight = 480,
            };
            win.DeleteEvent += OnDeleteEvent;

            var skiaView = new SKWidget();
            skiaView.PaintSurface += OnPaintSurface;
            win.Add(skiaView);

            win.Child.ShowAll();
            win.Show();

            Application.Run();
        }

        private static void OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
            a.RetVal = true;
        }

        private static void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var info = e.Info;

            canvas.Clear(SKColors.Azure);

            var paint = new SKPaint
            {
                Color = SKColors.Orange,
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                TextAlign = SKTextAlign.Center,
                TextSize = 32
            };

            canvas.DrawText("SkiaSharp on .NET Core with GTK#", info.Width / 2, (info.Height + paint.TextSize) / 2, paint);
        }
    }
}
