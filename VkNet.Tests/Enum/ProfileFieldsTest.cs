using NUnit.Framework;
using VkNet.Enums;

namespace VkNet.Tests.Enum
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
            const string expected = "city,first_name";

            Assert.That(fields.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void ToString_MultipleItems()
        {
            var fio = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Sex;

            string output = fio.ToString();

            Assert.That(output, Is.EqualTo("first_name,last_name,sex"));
        }

        [Test]
        public void ToString_All()
        {
            ProfileFields all = ProfileFields.All;
            const string expected = 
                "uid,first_name,last_name,sex,bdate,city,country,photo_50,photo_100,photo_200,photo_200_orig," + 
                "photo_400_orig,photo_max,photo_max_orig,online,lists,domain,has_mobile,contacts,connections," + 
                "site,education,universities,schools,can_post,can_see_all_posts,can_see_audio,can_write_private_message," + 
                "status,last_seen,common_count,relation,relatives,counters,nickname,timezone";

            string s = all.ToString();

            Assert.That(s, Is.EqualTo(expected));
        }

        [Test]
        public void ToString_All_Undocumented()
        {
            ProfileFields all = ProfileFields.AllUndocumented;
            const string expected =
                "uid,first_name,last_name,sex,bdate,city,country,photo_50,photo_100,photo_200,photo_200_orig," +
                "photo_400_orig,photo_max,photo_max_orig,online,lists,domain,has_mobile,contacts,connections," +
                "site,education,universities,schools,can_post,can_see_all_posts,can_see_audio,can_write_private_message," + 
                "status,last_seen,common_count,relation,relatives,counters,nickname,timezone,lang,online_mobile,online_app," + 
                "relation_partner,personal,interests,music,activities,movies,tv,books,games,about,quotes,invited_by";

            string s = all.ToString();

            Assert.That(s, Is.EqualTo(expected));
        }
 
    }
}