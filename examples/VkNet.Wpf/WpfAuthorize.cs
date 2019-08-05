using System.Threading.Tasks;
using Flurl;
using JetBrains.Annotations;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Core;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Wpf
{
	/// <inheritdoc />
	[UsedImplicitly]
	public class WpfAuthorize : IAuthorizationFlow
	{
		/// <summary>
		/// Менеджер версий VkApi
		/// </summary>
		private readonly IVkApiVersionManager _versionManager;

		private IApiAuthParams _authParams;

		public WpfAuthorize(IVkApiVersionManager versionManager)
		{
			_versionManager = versionManager;
		}

		public Task<AuthorizationResult> AuthorizeAsync()
		{
			var dlg = new AuthForm();

			dlg.WebBrowser.Navigate(
				CreateAuthorizeUrl(_authParams.ApplicationId, _authParams.Settings.ToUInt64(), Display.Mobile, "123456"),
				null,
				null,
				"User-Agent: CustomUserAgent");

			dlg.WebBrowser.Navigated += (sender, args) =>
			{
				dlg.WebBrowser.SetSilent();
				var result = VkAuthorization2.From(args.Uri.AbsoluteUri);

				if (!result.IsAuthorized)
				{
					return;
				}

				dlg.Auth = new AuthorizationResult
				{
					AccessToken = result.AccessToken,
					ExpiresIn = result.ExpiresIn,
					UserId = result.UserId,
					State = result.State
				};

				dlg.Close();
			};

			dlg.ShowDialog();

			return Task.FromResult(dlg.Auth);
		}

		public void SetAuthorizationParams(IApiAuthParams authorizationParams)
		{
			_authParams = authorizationParams;
		}

		public Url CreateAuthorizeUrl()
		{
			var url = new Url("https://oauth.vk.com/authorize")
				.SetQueryParam("client_id", _authParams.ApplicationId)
				.SetQueryParam("redirect_uri", "https://oauth.vk.com/blank.html")
				.SetQueryParam("display", Display.Mobile)
				.SetQueryParam("scope", _authParams.Settings.ToUInt64())
				.SetQueryParam("response_type", "token")
				.SetQueryParam("v", _versionManager.Version)
				.SetQueryParam("state", "1234567")
				.SetQueryParam("revoke", "1");

			return url;
		}

		public Url CreateAuthorizeUrl(ulong clientId, ulong scope, Display display, string state)
		{
			return CreateAuthorizeUrl().ToUri();
		}
	}
}