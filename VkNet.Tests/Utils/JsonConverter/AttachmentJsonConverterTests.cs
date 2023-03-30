using FluentAssertions;
using Newtonsoft.Json;
using VkNet.Model;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Utils.JsonConverter;

public class AttachmentJsonConverterTests : BaseTest
{
	[Fact]
	public void CallAndConvertToType()
	{
		ReadJsonFile("Attachment", nameof(CallAndConvertToType));
		Url = "https://api.vk.com/method/friends.getRequests";

		CommentBoard result = Api.Call<CommentBoard>("friends.getRequests", VkParameters.Empty);

		result.Should()
			.NotBeNull();

		result.Id.Should()
			.Be(3);

		result.FromId.Should()
			.Be(32190123);

		result.Attachments.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void SerializationTest()
	{
		ReadJsonFile("Attachment", nameof(SerializationTest));

		Url = "https://api.vk.com/method/wall.get";

		var wall = Api.Wall.Get(new());

		var json = JsonConvert.SerializeObject(wall,
			new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				DefaultValueHandling = DefaultValueHandling.Ignore
			});

		var result = JsonConvert.DeserializeObject<WallGetObject>(json,
			new JsonSerializerSettings
			{
				MaxDepth = null,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			});

		result.Should()
			.NotBeNull();

		result.WallPosts[0].Attachments[0].Instance.Id.Should()
			.Be(456239677);
	}
}