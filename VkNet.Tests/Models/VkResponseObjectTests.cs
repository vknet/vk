using System;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models
{

	public class VkResponseObjectTests : BaseTest
	{
		[Fact]
		public void VkResponseObjectOfEmptyObjectCorrectSerialize()
		{
			// Arrange
			ReadCommonJsonFile(JsonTestFolderConstants.Common.EmptyObject);

			var responseObject = new VkResponseObject<object>
			{
				Response = new object()
			};

			// Act
			var result = JsonConvert.SerializeObject(responseObject,
				new JsonSerializerSettings
				{
					Formatting = Formatting.Indented
				});

			// Assert
			result.Should().BeEquivalentTo(Json.Replace("\t", "  "));
		}

		[Fact]
		public void VkResponseObjectOfEmptyObjectArrayCorrectSerialize()
		{
			// Arrange
			ReadCommonJsonFile(JsonTestFolderConstants.Common.EmptyArray);

			var responseObject = new VkResponseObject<object[]>
			{
				Response = Array.Empty<object>()
			};

			// Act
			var result = JsonConvert.SerializeObject(responseObject,
				new JsonSerializerSettings
				{
					Formatting = Formatting.Indented
				});

			// Assert
			result.Should().BeEquivalentTo(Json.Replace("\t", "  "));
		}

		[Fact]
		public void VkResponseObjectOfStoryServerUrlCorrectSerialize()
		{
			// Arrange
			ReadCategoryJsonFile(JsonTestFolderConstants.Categories.Stories, "GetPhotoUploadServer");

			var responseObject = new VkResponseObject<StoryServerUrl>
			{
				Response = new StoryServerUrl
				{
					UploadUrl = new Uri("https://pu.vk.com/Tk0YjM0MjRmNzA5NSJ9"),
					PeerIds = Enumerable.Empty<long>(),
					UsersIds = Enumerable.Empty<long>()
				}
			};

			// Act
			var result = JsonConvert.SerializeObject(responseObject,
				new JsonSerializerSettings
				{
					Formatting = Formatting.Indented
				});

			// Assert
			result.Should().BeEquivalentTo(Json.Replace("\t", "  "));
		}
	}
}