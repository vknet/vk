using FluentAssertions;
using Newtonsoft.Json;
using VkNet.Model.GroupUpdate;
using Xunit;

namespace VkNet.Tests.Models
{

	public class GroupChangeSettingsTests : BaseTest
	{
		[Fact]
		public void GroupChangeSettings_should_correct_deserialize_from_VkResponse()
		{
			ReadJsonFile("Models", nameof(GroupChangeSettings));

			var response = GetResponse();

			var result = GroupChangeSettings.FromJson(response);

			result.Should().NotBeNull();
			result.UserId.Should().Be(641766519);
			result.Changes.Should().HaveCount(2);
			result.Changes.Should().ContainKey("title");
			result.Changes.Should().ContainKey("description");
		}

		[Fact]
		public void GroupChangeSettings_should_correct_deserialize_from_JsonConverter()
		{
			ReadJsonFile("Models", nameof(GroupChangeSettings));

			var result = JsonConvert.DeserializeObject<GroupChangeSettings>(Json);

			result.Should().NotBeNull();

			if (result == null)
			{
				return;
			}

			result.UserId.Should().Be(641766519);
			result.Changes.Should().HaveCount(2);
			result.Changes.Should().ContainKey("title");
			result.Changes.Should().ContainKey("description");
		}
	}
}