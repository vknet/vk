using System;
using FluentAssertions;
using Moq;
using VkNet.Abstractions.Core;
using VkNet.Model;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Utils
{


	public class CaptchaNeededExceptionTests : BaseTest
	{
		/// <inheritdoc />
		protected override void SetupCaptchaHandler()
		{
			Mocker.Setup<ICaptchaHandler, string>(m => m.Perform(It.IsAny<Func<ulong?, string, string>>()))
				.Callback(() => ReadJsonFile("Categories", "Messages", "GetById_NormalCase_Message"))
				.Returns(() => Json);

			Mocker.Setup<ICaptchaHandler, bool>(m => m.Perform(It.IsAny<Func<ulong?, string, bool>>()))
				.Returns(true);

			Mocker.Setup<ICaptchaHandler, int>(m => m.MaxCaptchaRecognitionCount)
				.Returns(1);

			Api.CaptchaHandler = Mocker.Get<ICaptchaHandler>();
		}

		[Fact]
		public void Call_ThrowsCaptchaNeededException()
		{
			Url = "https://api.vk.com/method/messages.send";
			ReadErrorsJsonFile(14);

			var ex = Api.Call<VkCollection<Message>>("messages.send", VkParameters.Empty, true);

			ex.TotalCount.Should().Be(1);
		}
	}
}