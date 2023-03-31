using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using VkNet.Abstractions.Core;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Infrastructure;
using VkNet.Infrastructure.Authorization.ImplicitFlow;
using VkNet.Infrastructure.Authorization.ImplicitFlow.Forms;
using VkNet.Model;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Infrastructure;

public class ImplicitFlowTests
{
	[Fact]
	public void CreateAuthorizeUrl()
	{
		const int clientId = 4268118;
		var scope = Settings.All|Settings.Offline;
		const string state = "123";
		var display = Display.Mobile;

		var builder = new StringBuilder("https://oauth.vk.com/authorize?");
		builder.Append($"client_id={clientId}&");
		builder.Append($"redirect_uri={Constants.DefaultRedirectUri}&");
		builder.Append($"display={display.ToString().ToSnakeCase()}&");
		builder.Append($"scope={scope.ToUInt64()}&");
		builder.Append($"response_type={ResponseType.Token.ToString().ToSnakeCase()}&");
		builder.Append("v=5.92&");
		builder.Append($"state={state}&");
		builder.Append("revoke=1");
		var expected = builder.ToString();

		var mocker = new AutoMocker();

		mocker.Setup<IVkApiVersionManager, string>(x => x.Version)
			.Returns("5.92");

		var implicitFlow = mocker.CreateInstance<ImplicitFlow>();

		implicitFlow.SetAuthorizationParams(new ApiAuthParams
		{
			ApplicationId = clientId,
			Settings = scope,
			Display = display,
			State = state,
			RedirectUri = new(Constants.DefaultRedirectUri),
			Revoke = true
		});

		var authorizeUrl = implicitFlow.CreateAuthorizeUrl();

		authorizeUrl.Should()
			.Be(new Uri(expected));
	}

	[Fact]
	public async Task Authorize()
	{
		var mocker = new AutoMocker();

		mocker.Setup<IVkApiVersionManager, string>(x => x.Version)
			.Returns("5.92");

		mocker.Setup<IAuthorizationForm, Task<AuthorizationFormResult>>(x =>
				x.ExecuteAsync(It.IsAny<Uri>(), It.IsAny<IApiAuthParams>(), CancellationToken.None))
			.ReturnsAsync(new AuthorizationFormResult
			{
				ResponseUrl = new("https://m.vk.com/login?act=authcheck&m=442"),
				RequestUrl = new("https://m.vk.com/login?act=authcheck&m=442")
			});

		mocker.Setup<IAuthorizationFormFactory, IAuthorizationForm>(x => x.Create(It.IsAny<ImplicitFlowPageType>()))
			.Returns(mocker.Get<IAuthorizationForm>());

		mocker.GetMock<IVkAuthorization<ImplicitFlowPageType>>()
			.Setup(x => x.GetPageType(It.IsAny<Uri>()))
			.Returns(ImplicitFlowPageType.Result);

		mocker.GetMock<IVkAuthorization<ImplicitFlowPageType>>()
			.Setup(x => x.GetAuthorizationResult(It.IsAny<Uri>()))
			.Returns(new AuthorizationResult
			{
				AccessToken = "access_token",
				UserId = 123,
				ExpiresIn = 0,
				State = "123"
			});

		var implicitFlow = mocker.CreateInstance<ImplicitFlow>();

		implicitFlow.SetAuthorizationParams(new ApiAuthParams
		{
			Login = "login",
			Password = "pass",
			ApplicationId = 4268118,
			Settings = Settings.All,
			RedirectUri = new(Constants.DefaultRedirectUri)
		});

		var result = await implicitFlow.AuthorizeAsync()
			.ConfigureAwait(false);

		result.Should()
			.NotBeNull();
	}

	[Fact]
	public void Authorize_ValidateError()
	{
		var mocker = new AutoMocker();

		mocker.Setup<IVkApiVersionManager, string>(x => x.Version)
			.Returns("5.92");

		var implicitFlow = mocker.CreateInstance<ImplicitFlow>();

		implicitFlow.SetAuthorizationParams(new ApiAuthParams
		{
			Login = "login"
		});

		FluentActions.Invoking(() => implicitFlow.AuthorizeAsync())
			.Should()
			.ThrowExactlyAsync<VkAuthorizationException>();
	}
}