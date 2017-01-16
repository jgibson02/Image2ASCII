using System;
using System.Drawing;
using System.IO;

public class IMG2ASCII
{

    static  void Main(string[] args)
    {
        StreamWriter swrt = new StreamWriter(Environment.CurrentDirectory + "/ascii.txt");
        string pixels = " .'`^\",:; Il!i >< ~+_ -?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";

        if (args.Length != 0) // user supplied a path
        {
            Bitmap image = new Bitmap(args[0]);
            if (image.Width > 250 || image.Height > 250)
            {
                float scaleFactor = (float) 250 / (float) Math.Max(image.Width, image.Height);
                image = new Bitmap(image, new Size((int)((float)image.Width * scaleFactor), (int)((float)image.Height * scaleFactor)));
            }
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var brightness = Brightness(image.GetPixel(x, y));
                    var idx = brightness / 255 * (pixels.Length - 1);
                    var pxl = pixels[pixels.Length - (int)Math.Round(idx) - 1];
                    swrt.Write(pxl);
                }
                swrt.WriteLine();
            }
        }
    }

    private static double Brightness(Color c)
    {
        return Math.Sqrt(c.R * c.R * .2126 + c.G * c.G * .7152 + c.B * c.B * .0722);
    }
}
