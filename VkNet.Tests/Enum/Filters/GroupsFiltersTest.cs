using NUnit.Framework;
using VkNet.Enums.Filters;

namespace VkNet.Tests.Enum.Filters
{
    [TestFixture]
    public class GroupsFiltersTest
    {
        [Test]
        public void ToString_OneGroupsFilters()
        {
            var groupsFilters = GroupsFilters.Groups;
            Assert.That(groupsFilters.ToString(), Is.EqualTo("groups"));
        }

        [Test]
        public void ToString_DuplicateFields_NoDuplicates()
        {
            var groupsFilters = GroupsFilters.Administrator | GroupsFilters.Events | GroupsFilters.Administrator;

            var result = groupsFilters.ToString();

			Assert.That(result, Is.EqualTo("admin,events"));
        }

        [Test]
        public void ToString_AllValues()
        {
            var groupsFilters = GroupsFilters.All;

            var result = groupsFilters.ToString();

			Assert.That(result, Is.EqualTo("admin,editor,moder,groups,publics,events"));
        }
    }
}