using System.Linq;
using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Audio;

public class AudioGetBroadcastListTest : CategoryBaseTest
{
	protected override string Folder => "Audio";

	[Fact]
	public void GetBroadcastListTest()
	{
		Url = "https://api.vk.com/method/audio.getBroadcastList";

		ReadCategoryJsonPath(nameof(Api.Audio.GetBroadcastList));

		var result = Api.Audio.GetBroadcastList()
			.ToList();

		var firstOrDefault = result.FirstOrDefault();

		result.Should()
			.NotBeEmpty();

		firstOrDefault.Should()
			.NotBeNull();
	}
}