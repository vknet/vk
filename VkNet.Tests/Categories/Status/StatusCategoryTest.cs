using FluentAssertions;
using VkNet.Categories;
using VkNet.Exception;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Status;

public class StatusCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Status";

	[Fact]
	public void Get_AccessDenied_ThrowAccessDeniedException()
	{
		Url = "https://api.vk.com/method/status.get";
		ReadErrorsJsonFile(7);

		// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
		FluentActions.Invoking(() => Api.Status.Get(1))
			.Should()
			.ThrowExactly<PermissionToPerformThisActionException>()
			.And.Message.Should()
			.Be("Permission to perform this action is denied");
	}

	[Fact]
	public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		var status = new StatusCategory(new VkApi());

		FluentActions.Invoking(() => status.Get(1))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void Get_Audio_ReturnStatus()
	{
		Url = "https://api.vk.com/method/status.get";

		ReadCategoryJsonPath(nameof(Get_Audio_ReturnStatus));

		var actual = Api.Status.Get(1);

		actual.Should()
			.NotBeNull();

		actual.Text.Should()
			.Be("Тараканы! – Собачье Сердце");

		actual.Audio.Should()
			.NotBeNull();

		actual.Audio.Id.Should()
			.Be(158073513);

		actual.Audio.OwnerId.Should()
			.Be(4793858);

		actual.Audio.Artist.Should()
			.Be("Тараканы!");

		actual.Audio.Title.Should()
			.Be("Собачье Сердце");

		actual.Audio.Duration.Should()
			.Be(230);

		actual.Audio.Url.OriginalString.Should()
			.Be("https://cs1-43v4/lR-RTwXXMk_q1RrO_-g");

		actual.Audio.LyricsId.Should()
			.Be(7985406);
	}

	[Fact]
	public void Get_SimpleText_ReturnStatus()
	{
		Url = "https://api.vk.com/method/status.get";
		ReadCategoryJsonPath(nameof(Get_SimpleText_ReturnStatus));

		var actual = Api.Status.Get(1);

		actual.Should()
			.NotBeNull();

		actual.Text.Should()
			.Be("it really work!!!");

		actual.Audio.Should()
			.BeNull();
	}

	[Fact]
	public void Set_AccessDenied_ThrowAccessDeniedException()
	{
		Url = "https://api.vk.com/method/status.set";
		ReadErrorsJsonFile(7);

		FluentActions.Invoking(() => Api.Status.Set("test"))
			.Should()
			.ThrowExactly<PermissionToPerformThisActionException>();
	}

	[Fact]
	public void Set_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		var status = new StatusCategory(new VkApi());

		FluentActions.Invoking(() => status.Set("test"))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void Set_SimpleText_ReturnTrue()
	{
		Url = "https://api.vk.com/method/status.set";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Status.Set("test test test");

		result.Should()
			.BeTrue();
	}
}