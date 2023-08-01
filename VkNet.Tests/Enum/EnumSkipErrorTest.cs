using System.Linq;
using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Enum;

public class EnumSkipErrorTest : CategoryBaseTest
{
	/// <inheritdoc />
	protected override string Folder => "SkipEnum";

	[Fact(Skip = "Работает только с VkApi.DeserializationErrorHandler = true")]
	public void CheckStatus()
	{
		Url = "https://api.vk.com/method/asr.checkStatus";

		ReadCategoryJsonPath(nameof(CheckStatus));

		var result = Api.Asr.CheckStatus("7ee0fa8e-64ac-4391-af7a-5c98a6330866");

		result.Id.Should()
			.Be("7ee0fa8e-64ac-4391-af7a-5c98a6330866");

		result.Text.Should()
			.Be("Это тестовая запись для сервиса распознавания речи ВКонтакте.");

		result.Status.Should()
			.Be(null);
	}

	[Fact(Skip = "Работает только с VkApi.DeserializationErrorHandler = true")]
	public void Get_CheckType()
	{
		Url = "https://api.vk.com/method/apps.get";
		ReadCategoryJsonPath(nameof(Get_CheckType));


		var app = Api.Apps.Get(new()
		{
			AppIds = new ulong[]
			{
				4268118
			},
			Platform = AppPlatforms.Web
		});

		app.Apps.First()
			.Type.Should()
			.Be(null);
	}
}