using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Overlay
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                bool hasError = false;

                var image = args[0];
                if (!File.Exists(image))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@$"Incorrect filepath: {image}");
                    Console.ForegroundColor = ConsoleColor.Black;
                    hasError = true;
                }

                var text = args[1];
                if (text.Length < 5 && text.Length > 30)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@$"Text should be >= 5 and <= 30 filepath: {text}");
                    Console.ForegroundColor = ConsoleColor.Black;
                    hasError = true;
                }

                if (!hasError)
                {
                    Process(text, image);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"Incorrect input, example: Overlay.exe ""C:\Users\user1\Desktop\pic.jpg"" ""@insta""");
                Console.ForegroundColor = ConsoleColor.Black;
                return;
            }
        }

        private static void Process(string text, string image)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;

            var watermark = text.Length switch
            {
                > 0 and <= 6 => @$"{dir}\icon50x200.png",
                > 6 and <= 10 => @$"{dir}\icon50x250.png",
                > 10 and <= 13 => @$"{dir}\icon50x300.png",
                > 13 and <= 17 => @$"{dir}\icon50x350.png",
                > 17 and <= 24 => @$"{dir}\icon50x450.png",
                _ => @$"{dir}\icon50x600.png"
            };

            var back = (Bitmap) Image.FromFile(image);
            var front = WriteText(watermark, text, new PointF(50f, 7f));
            var result = Overlay(back, front);
            result.Save(image);
            result.Dispose();
        }

        private static Image Overlay(Bitmap background, Bitmap foreground)
        {
            Image img = new Bitmap(background.Width, background.Height, PixelFormat.Format32bppArgb);

            using (Graphics gr = Graphics.FromImage(img))
            {
                gr.CompositingMode = CompositingMode.SourceOver;
                gr.DrawImage(background, new RectangleF(0 ,0 ,background.Width , background.Height));
                gr.DrawImage(foreground, new RectangleF(background.Width-foreground.Width, background.Height-foreground.Height, foreground.Width, foreground.Height));
            }
            background.Dispose();
            foreground.Dispose();

            return img;
        }

        private static Bitmap WriteText(string filepath, string text, PointF location)
        {
            using var bitmap = (Bitmap)Image.FromFile(filepath);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                using (var arialFont = new Font("Arial", 16))
                {
                    graphics.DrawString(text, arialFont, Brushes.Black, location);
                }
            }

            return new Bitmap(bitmap, bitmap.Width, bitmap.Height);
        }
    }
}