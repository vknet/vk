using NUnit.Framework;
using VkApiGenerator.Model;
using FluentNUnit;

namespace VkApiGenerator.Test.Model
{
    [TestFixture]
    public class VkMethodParamTest
    {
        [Test]
        public void CanonicalName_OneWord()
        {
            var param = new VkMethodParam {Name = "sort"};
            param.CanonicalName.ShouldEqual("sort");
        }

        [Test]
        public void CanonicalName_EmptyName()
        {
            var param = new VkMethodParam();
            param.CanonicalName.ShouldEqual(string.Empty);
        }

        [Test]
        public void CanonicalName_TwoWords()
        {
            var param = new VkMethodParam {Name = "user_id"};
            param.CanonicalName.ShouldEqual("userId");
        }

        [Test]
        public void ToString_CountDigitMandatory()
        {
            var param = new VkMethodParam { Name = "count", Type = VkParamType.Digit, IsMandatory = true };

            string result = param.ToString();

            result.ShouldEqual("int count");
        }

        [Test]
        public void ToString_Offset()
        {
            var param = new VkMethodParam { Name = "offset", Type = VkParamType.Digit };

            string result = param.ToString();

            result.ShouldEqual("int? offset = null");
        }

        [Test]
        public void ToString_Mandatory()
        {
            var param = new VkMethodParam { Name = "user_id", Type = VkParamType.Digit, IsMandatory = true};
            string result = param.ToString();

            result.ShouldEqual("long userId");
        }

        [Test]
        public void ToString_NormalCase()
        {
            var param = new VkMethodParam {Name = "user_id", Type = VkParamType.Digit};
            string result = param.ToString();

            result.ShouldEqual("long? userId = null");
        }
    }
}