using System;
using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Asr;

public class AsrCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Asr";

	[Fact]
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
			.Be(AsrStatus.Finished);
	}

	[Fact]
	public void GetUploadUrl()
	{
		Url = "https://api.vk.com/method/asr.getUploadUrl";

		ReadCategoryJsonPath(nameof(GetUploadUrl));

		var result = Api.Asr.GetUploadUrl();

		result.UploadUrl.Should()
			.Be(new Uri(
				"https://pu.vk.com/gu/speech/v2/upload?token=eyJ0e13iOiJKV1QiLCJhbGmdOiJIUzI1NiJ9.eyqlmAQiOjE2NjM1OTAzNDYsInZrX3VzZXJfaWQiOjgxNDI3MDksInZrX2FwcF9pZCI6ODE0MjcwOSwidmtfdXBsb2FkX3R5cGUiOiJzcGVlY2gifQ.9PStNUU8cf-rlFdPhM5hKQ2xSjhbxzxy7SRKYHvXC_M"));
	}
}