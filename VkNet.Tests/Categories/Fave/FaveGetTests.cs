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

		var fave = faves.FirstOrDefault();

		faves.Should()
			.NotBeEmpty();

		fave.Should()
			.NotBeNull();

		fave.Link.LinkId.Should()
			.Be("1234_434_4324");
	}
}