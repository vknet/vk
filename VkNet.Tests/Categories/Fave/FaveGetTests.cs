using System.Linq;
using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Fave;

public class FaveGetTests : CategoryBaseTest
{
	/// <inheritdoc />
	protected override string Folder => "Fave";

	[Fact]
	public void Get()
	{
		Url = "https://api.vk.com/method/fave.get";
		ReadCategoryJsonPath(nameof(Get));

		var faves = Api.Fave.Get(new()
		{
			Count = 1
		});

		faves[1]
			.Link.OldId.Should()
			.Be(null);

		faves[1]
			.Link.LinkId.Should()
			.Be("6_759823298_736260903");

		faves[2]
			.Link.OldId.Should()
			.Be(6736260903);

		faves[2]
			.Link.LinkId.Should()
			.Be("6736260903");

		var fave = faves.FirstOrDefault();

		faves.Should()
			.NotBeEmpty();

		fave.Should()
			.NotBeNull();
	}
}