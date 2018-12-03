using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Abstractions.Authorization;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Wpf
{
	/// <inheritdoc />
	[UsedImplicitly]
	public class WpfAuthorize : IBrowser
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

		public string GetJson(string url, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			throw new NotImplementedException();
		}

		public void SetAuthParams(IApiAuthParams authParams)
		{
			_authParams = authParams;
		}

		public IWebProxy Proxy { get; set; }

		/// <inheritdoc />
		public AuthorizationResult Authorize()
		{
			var dlg = new AuthForm();

			dlg.WebBrowser.Navigate(
				CreateAuthorizeUrl(_authParams.ApplicationId, _authParams.Settings.ToUInt64(), Display.Mobile, "123456"));

			dlg.WebBrowser.Navigated += (sender, args) =>
			{
				var result = VkAuthorization.From(args.Uri.AbsoluteUri);

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

			return dlg.Auth;
		}

		/// <inheritdoc />
		public Uri CreateAuthorizeUrl(ulong clientId, ulong scope, Display display, string state)
		{
			var builder = new StringBuilder("https://oauth.vk.com/authorize?");

			builder.Append($"client_id={clientId}&");
			builder.Append("redirect_uri=https://oauth.vk.com/blank.html&");
			builder.Append($"display={display}&");
			builder.Append($"scope={scope}&");
			builder.Append("response_type=token&");
			builder.Append($"v={_versionManager.Version}&");
			builder.Append($"state={state}&");
			builder.Append("revoke=1");

			return new Uri(builder.ToString());
		}

		public AuthorizationResult Validate(string validateUrl, string phoneNumber)
		{
			throw new NotImplementedException();
		}

		public AuthorizationResult Validate(string validateUrl)
		{
			throw new NotImplementedException();
		}
	}
}