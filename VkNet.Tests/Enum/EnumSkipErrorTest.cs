using System.Linq;
using AwesomeAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Enum;

public class EnumSkipErrorTest : CategoryBaseTest
{
	/// <inheritdoc />
	protected override string Folder => "SkipEnum";

	[Test]
	[DisplayName("Check status")]
	public void CheckStatus()
	{
		Url = "https://api.vk.ru/method/asr.checkStatus";

		ReadCategoryJsonPath(nameof(CheckStatus));

		if (Api.DeserializationErrorHandler is not true)
		{
			return;
		}

		var result = Api.Asr.CheckStatus("7ee0fa8e-64ac-4391-af7a-5c98a6330866");

		result.Id.Should()
			.Be("7ee0fa8e-64ac-4391-af7a-5c98a6330866");

		result.Text.Should()
			.Be("Это тестовая запись для сервиса распознавания речи ВКонтакте.");

		result.Status.Should()
			.Be(null);
	}

	[Test]
	[DisplayName("Get check type")]
	public void Get_CheckType()
	{
		Url = "https://api.vk.ru/method/apps.get";
		ReadCategoryJsonPath(nameof(Get_CheckType));

		if (Api.DeserializationErrorHandler is not true)
		{
			return;
		}

		var app = Api.Apps.Get(new()
		{
			AppIds = [4268118],
			Platform = AppPlatforms.Web
		});

		app.Apps.First()
			.Type.Should()
			.Be(null);
	}
}