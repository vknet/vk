using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using FluentNUnit;

namespace VkNet.Tests.Enum.SafetyEnums
{
	[TestFixture]
    public class CommentsSortTest
    {
        [Test]
        public void ToString_Asc()
        {
            var sort = CommentsSort.Asc;

			var type = sort.ToString();
            type.ShouldEqual("asc");
        }

        [Test]
        public void ToString_Desc()
        {
            var sort = CommentsSort.Desc;

			var type = sort.ToString();

            type.ShouldEqual("desc");
        }
    }
}