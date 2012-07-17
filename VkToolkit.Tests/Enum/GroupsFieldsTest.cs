using NUnit.Framework;
using VkToolkit.Enums;

namespace VkToolkit.Tests.Enum
{
    [TestFixture]
    public class GroupsFieldsTest
    {
        [Test]
        public void ToString_OneGroupsFields()
        {
            var g = GroupsFields.Country;
            Assert.That(g.ToString(), Is.EqualTo("country"));
        }

        [Test]
        public void ToString_DuplicateFields_NoDuplicates()
        {
            var g = GroupsFields.Country | GroupsFields.Place | GroupsFields.Country;
            Assert.That(g.ToString(), Is.EqualTo("country,place"));
        }

        [Test]
        public void ToString_AllValues()
        {
            var g = GroupsFields.All;
            Assert.That(g.ToString(), Is.EqualTo("city,country,place,description,wiki_page,start_date,end_date"));
        }
    }
}