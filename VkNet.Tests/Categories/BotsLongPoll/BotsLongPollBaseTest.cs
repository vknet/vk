using NUnit.Framework;
using VkNet.Categories;

namespace VkNet.Tests.Categories.BotsLongPoll
{
	[TestFixture]
	public abstract class BotsLongPollBaseTest : BaseTest
	{
		protected GroupsCategory GetMockedGroupCategory(string url, string json)
		{
			Json = json;
			Url = url;

			return new GroupsCategory(Api);
		}

		protected string GetFullResponse(string updateJson)
		{
			return $"{{'ts': '713','updates': [{updateJson}]}}";
		}
	}
}