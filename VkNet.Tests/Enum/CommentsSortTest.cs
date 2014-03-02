using NUnit.Framework;
using VkNet.Enums;

namespace VkNet.Tests.Enum
{
    [TestFixture]
    public class CommentsSortTest
    {
        [Test]
        public void ToString_Asc()
        {
            CommentsSort sort = CommentsSort.Asc;

            string type = sort.ToString();
            type.ShouldEqual("asc");
        }

        [Test]
        public void ToString_Desc()
        {
            CommentsSort sort = CommentsSort.Desc;

            string type = sort.ToString();

            type.ShouldEqual("desc");
        }
    }
}