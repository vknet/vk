using AwesomeAssertions;
using Newtonsoft.Json;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class VkResponseObjectTests : BaseTest
{
	[Fact(DisplayName = "Vk response object of empty object correct serialize")]
	public void VkResponseObjectOfEmptyObjectCorrectSerialize()
	{
		// Arrange
		ReadCommonJsonFile(JsonTestFolderConstants.Common.EmptyObject);

		var responseObject = new VkResponseObject<object>
		{
			Response = new()
		};

		// Act
		var result = JsonConvert.SerializeObject(responseObject,
			new JsonSerializerSettings
			{
				Formatting = Formatting.Indented
			});

		// Assert
		result.Should()
			.BeEquivalentTo(Json.Replace("\t", "  "));
	}

	[Fact(DisplayName = "Vk response object of empty object array correct serialize")]
	public void VkResponseObjectOfEmptyObjectArrayCorrectSerialize()
	{
		// Arrange
		ReadCommonJsonFile(JsonTestFolderConstants.Common.EmptyArray);

		var responseObject = new VkResponseObject<object[]>
		{
			Response = []
		};

		// Act
		var result = JsonConvert.SerializeObject(responseObject,
			new JsonSerializerSettings
			{
				Formatting = Formatting.Indented
			});

		// Assert
		result.Should()
			.BeEquivalentTo(Json.Replace("\t", "  "));
	}

	[Fact(DisplayName = "Vk response object of story server url correct serialize")]
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
		var result = JsonConvert.SerializeObject(responseObject,
			new JsonSerializerSettings
			{
				Formatting = Formatting.Indented
			});

		// Assert
		result.Should()
			.BeEquivalentTo(Json.Replace("\t", "  "));
	}
}