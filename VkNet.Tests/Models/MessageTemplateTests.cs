using NUnit.Framework;
using VkNet.Model.Template;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class MessageTemplateTests : BaseTest
	{

		[Test]
		public void Template_Carousel()
		{
			ReadJsonFile("Models", "Template_Carousel");

			var response = GetResponse();

			var result = MessageTemplate.FromJson(response);

			Assert.IsNotNull(result);
		}
	}
}