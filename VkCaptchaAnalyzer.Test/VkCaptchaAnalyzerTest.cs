using System.Drawing.Imaging;

namespace VkCaptchaAnalyzer.Test
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using VkNet.Utils.Tests;
    using NUnit.Framework;

    [TestFixture]
    public class VkCaptchaAnalyzerTest
    {
        #region Captcha bitmaps
        private Bitmap _hhc4;
        public Bitmap Hhc4
        {
            get { return _hhc4 ?? (_hhc4 = VkCaptchaAnalyzer.LoadImage("CaptchaImgs/hhc4.jpg")); }
        }

        private Bitmap _imgRgbw;
        public Bitmap ImgRgbw
        {
            get { return _imgRgbw ?? (_imgRgbw = VkCaptchaAnalyzer.LoadImage("CaptchaImgs/rgbw.jpg")); }
        }

        private Bitmap _vznx;
        public Bitmap CaptchaVznx
        {
            get { return _vznx ?? (_vznx = VkCaptchaAnalyzer.LoadImage("CaptchaImgs/vznx.jpg")); }
        }
        #endregion

        [Test]
        public void Load_SuccessfullLoading()
        {
            var analyzer = new VkCaptchaAnalyzer();
            analyzer.Load("CaptchaImgs/1.jpg");

            analyzer.Captcha.ShouldNotBeNull();
        }

        [Test]
        public void Inverse_NormalCase()
        {
            Color original = Hhc4.GetPixel(30, 30);
            Bitmap inversedImg = VkCaptchaAnalyzer.Inverse(Hhc4);

            Color inversed = inversedImg.GetPixel(30, 30);

            inversed.R.ShouldEqual((byte)(255 - original.R));
            inversed.G.ShouldEqual((byte)(255 - original.G));
            inversed.B.ShouldEqual((byte)(255 - original.B));
        }

        [Test]
        public void GetAllColors_AllImage_FourColors()
        {
            var colors = VkCaptchaAnalyzer.GetAllColors(ImgRgbw, 0, ImgRgbw.Width).ToList();
            //colors.Count.ShouldEqual(4);

            Color yellow = colors.Find(x => x.Name == "ffffd800");
            Color blue = colors.Find(x => x.Name == "ff0026ff");
            Color red = colors.Find(x => x.Name == "fffe0000");
            Color green = colors.Find(x => x.Name == "ff00fe21");

            Assert.Fail();
        }

        [Test]
        public void ReplaceColors_AllColorsToAqua()
        {
            // 1. take initial image
            IEnumerable<Color> colors = VkCaptchaAnalyzer.GetAllColors(ImgRgbw, 0, ImgRgbw.Width);

            // 2. change color to aqua
            Color aqua = Color.Aqua;
            Bitmap replaced = VkCaptchaAnalyzer.ReplaceColors(ImgRgbw, colors, aqua);

            // 3. get new colors and make assert
            var replacedColors = VkCaptchaAnalyzer.GetAllColors(replaced, 0, replaced.Width).ToList();
            replacedColors.Count.ShouldEqual(1);
            Color c = replacedColors[0];
            c.A.ShouldEqual(aqua.A);
            c.R.ShouldEqual(aqua.R);
            c.G.ShouldEqual(aqua.G);
            c.B.ShouldEqual(aqua.B);
        }

        [Test]
        public void GetDarkestColor_BlueAndRed_Blue()
        {
            var colors = VkCaptchaAnalyzer.GetAllColors(CaptchaVznx, 0, 50).ToList();

            Color blue = colors.Find(x => x.Name == "ff0026ff");

            Color dark = VkCaptchaAnalyzer.GetDarkestColor(colors);

            var similar = VkCaptchaAnalyzer.GetSimilarColors(colors, dark);

            Bitmap result = VkCaptchaAnalyzer.ReplaceColors(CaptchaVznx, similar, Color.DeepSkyBlue);

            result.Save(@"d:\tmp\result.jpeg", ImageFormat.Jpeg);

            dark.ShouldEqual(blue);

            Assert.Fail();
        }

        [Test]
        public void ReplaceColors_SimiliarYellowColorsToAqua()
        {
            Assert.Fail();
        }

        [Test]
        public void GetColors_HalfImage_TwoColors()
        {
            Assert.Fail();
        }
    }
}