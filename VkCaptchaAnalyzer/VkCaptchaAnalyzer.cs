using System;
using System.Collections.Generic;
using System.Linq;
using AForge.Imaging.Filters;

namespace VkCaptchaAnalyzer
{
    using System.Drawing;
    
    using JetBrains.Annotations;

    public class VkCaptchaAnalyzer
    {
        /// <summary>
        /// Изображение капчи
        /// </summary>
        public Bitmap Captcha { get; set; }

        private const int Step = 10;

        public static Bitmap LoadImage([PathReference] string path)
        {
            return AForge.Imaging.Image.FromFile(path);
        }

        public void Load([PathReference] string path)
        {
            Captcha = LoadImage(path);
        }
        public void Analyze(Bitmap img)
        {
                     
        }

        public static Bitmap Inverse(Bitmap img)
        {
            IFilter filter = new Invert();
            return filter.Apply(img);
        }

        [Pure]
        public static Bitmap ReplaceColor(Bitmap img, Color source, Color destination)
        {
            return ReplaceColors(img, new [] {source}, destination);
        }

        [Pure]
        public static Bitmap ReplaceColors([NotNull] Bitmap img, [NotNull] IEnumerable<Color> sourceColors, Color destinationColor)
        {
            if (img == null)
                throw new ArgumentException("Image is not set", "img");

            Bitmap tmp = AForge.Imaging.Image.Clone(img);

            if (sourceColors == null)
                throw new ArgumentException("Source colors not set.", "sourceColors");

            var colors = sourceColors.ToList();
            for (int x = 0; x < tmp.Width; x++)
                for (int y = 0; y < tmp.Height; y++)
                {
                    Color color = tmp.GetPixel(x, y);
                    if (colors.Any(c => c == color))
                        tmp.SetPixel(x, y, destinationColor);
                }

            return tmp;
        }

        /// <summary>
        /// Выбирает цвета в вертикальной полосе, начинас с позиции startPos и шириной lenght
        /// </summary>
        /// <param name="img"></param>
        /// <param name="startPos"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static IEnumerable<Color> GetAllColors(Bitmap img, int startPos, int width)
        {
            if (img == null)
                throw new ArgumentException("Image is not set", "img");

            if (startPos < 0)
                throw new ArgumentException("Start position less then zero.", "startPos");

            if (width > img.Width)
                throw new ArgumentException("Length is more than image width", "width");

            var colors = new List<Color>();
            for (int x = startPos; x < width || x < img.Width; x++)
                for (int y = 0; y < img.Height; y++)
                {
                    Color c = img.GetPixel(x, y);
                    if (colors.All(color => color != c))
                        colors.Add(c);
                }

            return colors;
        }

        public static IEnumerable<Color> GetSimilarColors(IEnumerable<Color> colors, Color neededColor, double distance = 250.0)
        {
            var result = new List<Color>();

            double r = Convert.ToDouble(neededColor.R);
            double g = Convert.ToDouble(neededColor.G);
            double b = Convert.ToDouble(neededColor.B);

            foreach (Color color in colors)
            {
                double tmpR = Math.Pow(Convert.ToDouble(color.R) - r, 2.0);
                double tmpG = Math.Pow(Convert.ToDouble(color.G) - g, 2.0);
                double tmpB = Math.Pow(Convert.ToDouble(color.B) - b, 2.0);

                double temp = Math.Sqrt(tmpR + tmpG + tmpB);
                if (temp < distance)
                    result.Add(color);
            }

            return result;
        }

        public static Color GetDarkestColor([NotNull] IEnumerable<Color> colors)
        {
            if (colors == null)
                throw new ArgumentException("Colors is null.", "colors");

            var clrs = colors.ToList();
            if (clrs.Count == 1) return clrs[0];

            // or may be change to int
            double dark = 0.0;
            Color result = Color.Empty;
            foreach (Color color in clrs)
            {
                double r = Convert.ToDouble(color.R);
                double g = Convert.ToDouble(color.G);
                double b = Convert.ToDouble(color.B);

                double rgb = r + g + b;
                if (rgb > dark)
                {
                    result = color;
                    dark = rgb;
                }
            }

            return result;
        }

    }
}