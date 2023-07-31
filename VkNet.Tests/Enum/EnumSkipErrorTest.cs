﻿using System.Linq;
using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Enum;

public class EnumSkipErrorTest : EnumDeserializationCategoryBaseTest
{
	/// <inheritdoc />
	protected override string Folder => "SkipEnum";

	[Fact]
	public void CheckStatus()
	{
		Url = "https://api.vk.com/method/asr.checkStatus";

		ReadJsonPath(nameof(CheckStatus));

		var result = Api.Asr.CheckStatus("7ee0fa8e-64ac-4391-af7a-5c98a6330866");

		result.Id.Should()
			.Be("7ee0fa8e-64ac-4391-af7a-5c98a6330866");

		result.Text.Should()
			.Be("Это тестовая запись для сервиса распознавания речи ВКонтакте.");

		result.Status.Should()
			.Be(null);
	}

	[Fact]
	public void Get_CheckType()
	{
		Url = "https://api.vk.com/method/apps.get";
		ReadJsonPath(nameof(Get_CheckType));


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