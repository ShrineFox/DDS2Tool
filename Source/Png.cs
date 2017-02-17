using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace DDS2Tool
{
    class Png
    {
        public static void Convert(string dds)
        {
            KUtility.DDSImage img = new KUtility.DDSImage(File.ReadAllBytes(dds));
            var newFolder = $"{Path.GetDirectoryName(dds)}\\Png";
            if (!Directory.Exists(newFolder))
            {
                Directory.CreateDirectory(newFolder);
            }

            for (int i = 0; i < img.images.Length; i++)
            {
                img.images[i].Save($"{newFolder}//{Path.GetFileNameWithoutExtension(dds)}.png", ImageFormat.Png);
            }
        }

        public static void Combine(string png1, string png2)
        {
            Bitmap source1 = new Bitmap(png1, true);
            Bitmap source2 = new Bitmap(png2, true);

            var target = new Bitmap(source1.Width, source1.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(target);
            graphics.CompositingMode = CompositingMode.SourceOver;

            graphics.DrawImage(source1, 0, 0);
            graphics.DrawImage(source2, 0, 0);

            var newFolder = $"{Path.GetDirectoryName(Path.GetDirectoryName(png1))}\\Combined";
            if (!Directory.Exists(newFolder)) {
                Directory.CreateDirectory(newFolder);
                }
            var newPath = $"{newFolder}\\{Path.GetFileNameWithoutExtension(png2)}";

            target.Save($"{newPath}.png", ImageFormat.Png);
        }
    }
}
