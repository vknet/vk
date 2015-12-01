using NUnit.Framework;
using VkNet.Enums.Filters;

namespace VkNet.Tests.Enum.Filters
{
    [TestFixture]
    public class GroupsFieldsTest
    {
        [Test]
        public void ToString_OneGroupsFields()
        {
            var groupsFields = GroupsFields.CountryId;
            Assert.That(groupsFields.ToString(), Is.EqualTo("country"));
        }

        [Test]
        public void ToString_DuplicateFields_NoDuplicates()
        {
            var groupsFields = GroupsFields.CountryId | GroupsFields.Place | GroupsFields.CountryId;
            Assert.That(groupsFields.ToString(), Is.EqualTo("country,place"));
        }

        [Test]
        public void ToString_AllValues()
        {
            var groupsFields = GroupsFields.All;
            Assert.That(groupsFields.ToString(), Is.EqualTo("city,country,place,description,wiki_page,members_count,counters,start_date,end_date,can_post,can_see_all_posts,can_create_topic,activity,status,contacts,links,fixed_post,verified,site,ban_info"));
        }
    }
}