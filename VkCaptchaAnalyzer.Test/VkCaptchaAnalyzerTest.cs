using System.Drawing;
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
            get
            {
                if (_hhc4 != null)
                    _hhc4 = VkCaptchaAnalyzer.LoadImage("CaptchaImgs/hhc4.jpg");

                return _hhc4;
            }
        }

        [Test]
        public void Load_SuccessfullLoading()
        {
            var analyzer = new VkCaptchaAnalyzer();
            analyzer.Load("CaptchaImgs/1.jpg");

            analyzer.Captcha.ShouldNotBeNull();
        }
    }
}