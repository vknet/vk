using NUnit.Framework;
using VkToolkit.Enums;

namespace VkToolkit.Tests.Enum
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
                "uid,first_name,last_name,nickname,screen_name,sex,bdate,city,country,timezone," + 
                "photo_50,photo_100,photo_200_orig,has_mobile,contacts,education,online,counters,relation,last_seen," + 
                "status,can_write_private_message,can_see_all_posts,can_see_audio,can_post,universities,schools," + 
                "verified,connections,site,relatives,activities,interests,music,movies,tv,books,games,quotes,about," + 
                "lang,personal,photo_400_orig,photo_max,photo_max_orig";

            string s = all.ToString();

            Assert.That(s, Is.EqualTo(expected));
        }
         
    }
}