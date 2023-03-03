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

		var response = GetResponse();
		var message = Message.FromJson(response);

		var json = JsonConvert.SerializeObject(message,
			new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				DefaultValueHandling = DefaultValueHandling.Ignore
			});

		var result = JsonConvert.DeserializeObject<Message>(json,
			new JsonSerializerSettings
			{
				MaxDepth = null,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			});

		result.Should()
			.NotBeNull();

		result.Attachments.Should()
			.NotBeEmpty();
	}
}