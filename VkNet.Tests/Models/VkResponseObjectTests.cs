using System.Text.Json;
using AwesomeAssertions;
using Newtonsoft.Json;
using VkNet.Model;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace VkNet.Tests.Models;

public class VkResponseObjectTests : BaseTest
{
	private static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web)
	{
		WriteIndented = true,
		IndentCharacter = '\t',
		IndentSize = 1,
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
	};
	[Test]
	[DisplayName("Vk response object of empty object correct serialize")]
	public void VkResponseObjectOfEmptyObjectCorrectSerialize()
	{
		// Arrange
		ReadCommonJsonFile(JsonTestFolderConstants.Common.EmptyObject);

		var responseObject = new VkResponseObject<object>
		{
			Response = new()
		};

		// Act
		var result = JsonSerializer.Serialize(responseObject, Options);

		// Assert
		result.Should()
			.BeEquivalentTo(Json, x => x.IgnoringNewlineStyle()
				.IgnoringTrailingWhitespace());
	}

	[Test]
	[DisplayName("Vk response object of empty object array correct serialize")]
	public void VkResponseObjectOfEmptyObjectArrayCorrectSerialize()
	{
		// Arrange
		ReadCommonJsonFile(JsonTestFolderConstants.Common.EmptyArray);

		var responseObject = new VkResponseObject<object[]>
		{
			Response = []
		};

		// Act
		var result = JsonSerializer.Serialize(responseObject, Options);

		// Assert
		result.Should()
			.BeEquivalentTo(Json, x => x.IgnoringNewlineStyle()
				.IgnoringTrailingWhitespace());
	}

	[Test]
	[DisplayName("Vk response object of story server url correct serialize")]
	public void VkResponseObjectOfStoryServerUrlCorrectSerialize()
	{
		// Arrange
		ReadCategoryJsonFile(JsonTestFolderConstants.Categories.Stories, "GetPhotoUploadServer");

		var responseObject = new VkResponseObject<StoryServerUrl>
		{
			Response = new()
			{
				UploadUrl = new("https://pu.vk.ru/Tk0YjM0MjRmNzA5NSJ9"),
				PeerIds = [],
				UsersIds = []
			}
		};

		// Act
		var result = JsonSerializer.Serialize(responseObject, Options);

		// Assert
		result.Should()
			.BeEquivalentTo(Json, x => x.IgnoringNewlineStyle()
				.IgnoringTrailingWhitespace());
	}
}