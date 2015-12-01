using NUnit.Framework;
using VkNet.Enums.Filters;

namespace VkNet.Tests.Enum.Filters
{
    [TestFixture]
    public class ProfileFieldsTest
    {
        [Test]
        public void ToString_OneProfileField()
        {
            var f = ProfileFields.Country;
            Assert.That(f.ToString(), Is.EqualTo("country"));
        }

        [Test]
        public void ToString_DuplicateFields_NoDuplicates()
        {
            var fields = ProfileFields.City | ProfileFields.FirstName | ProfileFields.City;
            const string expected = "first_name,city";

            Assert.That(fields.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void ToString_MultipleItems()
        {
            var fio = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Sex;

            var output = fio.ToString();

			Assert.That(output, Is.EqualTo("first_name,last_name,sex"));
        }

        [Test]
        public void ToString_All()
        {
            var all = ProfileFields.All;
			const string expected = 
                "uid,first_name,last_name,sex,bdate,city,country,photo_50,photo_100,photo_200,photo_200_orig," + 
                "photo_400_orig,photo_max,photo_max_orig,online,lists,domain,has_mobile,contacts,connections," + 
                "site,education,universities,schools,can_post,can_see_all_posts,can_see_audio,can_write_private_message," + 
                "status,last_seen,common_count,relation,relatives,counters,nickname,timezone";

            var s = all.ToString();

			Assert.That(s, Is.EqualTo(expected));
        }

        [Test]
        public void ToString_All_Undocumented()
        {
            var all = ProfileFields.AllUndocumented;
			const string expected =
                "uid,first_name,last_name,sex,bdate,city,country,photo_50,photo_100,photo_200,photo_200_orig," +
                "photo_400_orig,photo_max,photo_max_orig,online,lists,domain,has_mobile,contacts,connections," +
                "site,education,universities,schools,can_post,can_see_all_posts,can_see_audio,can_write_private_message," + 
                "status,last_seen,common_count,relation,relatives,counters,nickname,timezone,lang,online_mobile,online_app," + 
                "relation_partner,personal,interests,music,activities,movies,tv,books,games,about,quotes,invited_by";

            var actual = all.ToString();

			Assert.That(actual, Is.EqualTo(expected));
        }
 
    }
}