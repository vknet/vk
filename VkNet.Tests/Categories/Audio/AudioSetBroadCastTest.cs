using System.Collections.Generic;
using System.Linq;
using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Audio;

public class AudioSetBroadCastTest : CategoryBaseTest
{
	protected override string Folder => "Audio";

	[Fact(DisplayName = "Set broad cast test")]
	public void SetBroadCastTest()
	{
		Url = "https://api.vk.ru/method/audio.setBroadcast";

		ReadCategoryJsonPath(nameof(Api.Audio.SetBroadcast));

		var result = Api.Audio.SetBroadcast("123456789_123456789",
				new List<long>
				{
					123456789,
					123456789
				})
			.ToList();

		result.Should()
			.NotBeEmpty();

		result.Should()
			.HaveCount(2);
	}
}