using NUnit.Framework;
using VkNet.Enums.SafetyEnums;


namespace VkNet.Tests.Enum.SafetyEnums
{
	[TestFixture]
    public class CommentsSortTest
    {
        [Test]
        public void ToString_Asc()
        {
            var sort = CommentsSort.Asc;

			Assert.That(sort.ToString(), Is.EqualTo("asc"));
        }

        [Test]
        public void ToString_Desc()
        {
            var sort = CommentsSort.Desc;

			Assert.That(sort.ToString(), Is.EqualTo("desc"));
		}
    }
}