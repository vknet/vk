using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class MessagesPinTests: BaseTest
	{
		[Test]
		public void Pin()
		{
			Url = "https://api.vk.com/method/messages.pin";

			Json = @"{
				'response': {
					'id': 123,
					'text': 'text'
				}
			}";

			var result = Api.Messages.Pin(123, 345);

			Assert.NotNull(result);
		}
	}
}