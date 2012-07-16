using NUnit.Framework;
using VkToolkit.Enum;

namespace VkToolkit.Tests.Enum
{
    [TestFixture]
    public class GroupsFiltersTest
    {
        [Test]
        public void ToString_OneGroupsFilters()
        {
            var g = GroupsFilters.Groups;
            Assert.That(g.ToString(), Is.EqualTo("groups"));
        }

        [Test]
        public void ToString_DuplicateFields_NoDuplicates()
        {
            var g = GroupsFilters.Admin | GroupsFilters.Events | GroupsFilters.Admin;

            string result = g.ToString();

            Assert.That(result, Is.EqualTo("admin,events"));
        }

        [Test]
        public void ToString_AllValues()
        {
            var g = GroupsFilters.All;

            string result = g.ToString();

            Assert.That(result, Is.EqualTo("admin,groups,publics,events"));
        }
    }
}