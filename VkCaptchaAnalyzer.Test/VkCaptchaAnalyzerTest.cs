using System.Drawing;
using System.Drawing.Imaging;
using VkNet.Utils.Tests;

namespace VkCaptchaAnalyzer.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class VkCaptchaAnalyzerTest
    {
        private Bitmap _hhc4;
        public Bitmap Hhc4
        {
            get { return _hhc4 ?? (_hhc4 = VkCaptchaAnalyzer.LoadImage("CaptchaImgs/hhc4.jpg")); }
        }

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
            Bitmap inversed = VkCaptchaAnalyzer.Inverse(Hhc4);

            inversed.Save(@"d:\tmp\tested.jpg", ImageFormat.Jpeg);
        }
    }
}