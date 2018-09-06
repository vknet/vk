using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class PhotoSaveMessagePhotoTests : BaseTest
	{
		[Test]
		public void SaveMessagePhoto()
		{
			Url = "https://api.vk.com/method/photos.saveMessagesPhoto";

			Json = @"{
			  response: [
				{
				  id: 456240173,
				  album_id: -3,
				  owner_id: 32190123,
				  sizes: [
					{
					  type: ""s"",
					  url: ""https://pp.userapi.com/c847017/v847017534/66e9c/PAZHqnQBYt4.jpg"",
					  width: 75,
					  height: 56
					},
					{
					  type: ""m"",
					  url: ""https://pp.userapi.com/c847017/v847017534/66e9d/16O6MBElIq0.jpg"",
					  width: 130,
					  height: 97
					},
					{
					  type: ""x"",
					  url: ""https://pp.userapi.com/c847017/v847017534/66e9e/dyupsW2_oak.jpg"",
					  width: 550,
					  height: 412
					},
					{
					  type: ""o"",
					  url: ""https://pp.userapi.com/c847017/v847017534/66e9f/n4hbQyhmJRQ.jpg"",
					  width: 130,
					  height: 97
					},
					{
					  type: ""p"",
					  url: ""https://pp.userapi.com/c847017/v847017534/66ea0/fuws2C9tjWA.jpg"",
					  width: 200,
					  height: 150
					},
					{
					  type: ""q"",
					  url: ""https://pp.userapi.com/c847017/v847017534/66ea1/78cnn5nN8ns.jpg"",
					  width: 320,
					  height: 240
					},
					{
					  type: ""r"",
					  url: ""https://pp.userapi.com/c847017/v847017534/66ea2/uic-YSr7sSo.jpg"",
					  width: 510,
					  height: 382
					}
				  ],
				  text: """",
				  date: 1527934131,
				  access_key: ""9392e3146a13f8df7b""
				}
			  ]
			}
			";

			var parameter = @"{
              photo: ""[{\""photo\"":\""e8ca48933e:x\"",\""sizes\"":[[\""s\"",847017534,\""66e9c\"",\""PAZHqnQBYt4\"",75,56],[\""m\"",847017534,\""66e9d\"",\""16O6MBElIq0\"",130,97],[\""x\"",847017534,\""66e9e\"",\""dyupsW2_oak\"",550,412],[\""o\"",847017534,\""66e9f\"",\""n4hbQyhmJRQ\"",130,97],[\""p\"",847017534,\""66ea0\"",\""fuws2C9tjWA\"",200,150],[\""q\"",847017534,\""66ea1\"",\""78cnn5nN8ns\"",320,240],[\""r\"",847017534,\""66ea2\"",\""uic-YSr7sSo\"",510,382]],\""latitude\"":0,\""longitude\"":0,\""kid\"":\""721eade072f6ae1252a6547055258eb6\""}]"",
              hash: ""99bdf043811b602a5b54f8fa4fd05f8f"",
              server: ""847017"",
              v: ""5.78"",
              access_token: ""7824d8edf8fe183d5b8de4765502116526dbf3a190f93ca711031813899c20f0f52db0141f3cc370d7a63""
            }";

			var result = Api.Photo.SaveMessagesPhoto(parameter);
			Assert.IsNotEmpty(result);
			var first = result.FirstOrDefault();
			var size = first.Sizes.FirstOrDefault();
			Assert.AreEqual(new Uri("https://pp.userapi.com/c847017/v847017534/66e9c/PAZHqnQBYt4.jpg"), size.Src);
		}
	}
}