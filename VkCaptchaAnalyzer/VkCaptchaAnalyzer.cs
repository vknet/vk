using JetBrains.Annotations;

namespace VkCaptchaAnalyzer
{
    using System.Drawing;
    using System;

    public class VkCaptchaAnalyzer
    {
        public Bitmap Captcha { get; set; }

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
            throw new NotImplementedException();
        }
    }
}