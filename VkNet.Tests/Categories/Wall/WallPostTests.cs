using FluentAssertions;
using VkNet.Exception;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Categories.Wall;

public class WallPostTests : CategoryBaseTest
{
	protected override string Folder => "Wall";

	[Fact]
	public void Post_ReturnValidateNeeded()
	{
		Url = "https://api.vk.com/method/wall.post";
		ReadErrorsJsonFile(17);

		FluentActions.Invoking(() => VkErrors.IfErrorThrowException(Json))
			.Should()
			.ThrowExactly<NeedValidationException>();
	}

	[Fact]
	public void Post_AccessToAddingPostDenied()
	{
		Url = "https://api.vk.com/method/wall.post";
		ReadErrorsJsonFile(214);

		FluentActions.Invoking(() => Api.Wall.Post(new()))
			.Should()
			.ThrowExactly<PostLimitException>();
	}
}