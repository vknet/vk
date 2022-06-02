using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Photos
{
	[TestFixture]
	public class PhotoSaveMessagePhotoTests : CategoryBaseTest
	{
		protected override string Folder => "Photos";

		[Test]
		public void SaveMessagePhoto()
		{
			Url = "https://api.vk.com/method/photos.saveMessagesPhoto";
			ReadCategoryJsonPath(nameof(SaveMessagePhoto));

			const string parameter = @"{
              photo: ""[{\""photo\"":\""e8ca48933e:x\"",\""sizes\"":[[\""s\"",847017534,\""66e9c\"",\""PAZHqnQBYt4\"",75,56],[\""m\"",847017534,\""66e9d\"",\""16O6MBElIq0\"",130,97],[\""x\"",847017534,\""66e9e\"",\""dyupsW2_oak\"",550,412],[\""o\"",847017534,\""66e9f\"",\""n4hbQyhmJRQ\"",130,97],[\""p\"",847017534,\""66ea0\"",\""fuws2C9tjWA\"",200,150],[\""q\"",847017534,\""66ea1\"",\""78cnn5nN8ns\"",320,240],[\""r\"",847017534,\""66ea2\"",\""uic-YSr7sSo\"",510,382]],\""latitude\"":0,\""longitude\"":0,\""kid\"":\""721eade072f6ae1252a6547055258eb6\""}]"",
              hash: ""99bdf043811b602a5b54f8fa4fd05f8f"",
              server: ""847017"",
              v: ""5.78"",
              access_token: ""7824d8edf8fe183d5b8de4765502116526dbf3a190f93ca711031813899c20f0f52db0141f3cc370d7a63""
            }";

			var result = Api.Photo.SaveMessagesPhoto(parameter);
			result.Should().NotBeEmpty();
			var first = result.First();
			var size = first.Sizes.First();
			size.Url.Should().Be(new Uri("https://pp.userapi.com/c847017/v847017534/66e9c/PAZHqnQBYt4.jpg"));
		}
	}
}