using System.Text;
using Flurl;
using Moq.AutoMock;
using NUnit.Framework;
using VkNet.Abstractions.Core;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Tests.Infrastructure
{
	[TestFixture]
	public class ImplicitFlowTests
	{
		[Test]
		public void CreateAuthorizeUrl()
		{
			const int clientId = 1;
			var scope = Settings.Notify.ToUInt64();
			const string state = "123";
			var display = Display.Mobile;
			var builder = new StringBuilder("https://oauth.vk.com/authorize?");

			builder.Append($"client_id={clientId}&");
			builder.Append("redirect_uri=https://oauth.vk.com/blank.html&");

			builder.Append($"display={display}&");
			builder.Append($"scope={scope}&");
			builder.Append("response_type=token&");
			builder.Append($"v=5.92&");

			builder.Append($"state={state}&");
			builder.Append("revoke=1");

			var expected = builder.ToString();
			var mocker = new AutoMocker();
			mocker.Setup<IVkApiVersionManager, string>(x => x.Version).Returns("5.92");

			var implicitFlow = mocker.CreateInstance<ImplicitFlow>();

			var authorizeUrl = implicitFlow.CreateAuthorizeUrl(clientId, scope, display, state);

			Assert.AreEqual(new Url(expected), authorizeUrl);
		}
	}
}