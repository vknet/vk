using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Abstractions.Core;
using VkNet.Enums.Filters;
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

		/// <inheritdoc />
		public string GetJson(string url, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public void SetAuthParams(IApiAuthParams authParams)
		{
			_authParams = authParams;
		}

		/// <inheritdoc />
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
			var builder = new StringBuilder(value: "https://oauth.vk.com/authorize?");

			builder.Append(value: $"client_id={clientId}&");
			builder.Append(value: "redirect_uri=https://oauth.vk.com/blank.html&");
			builder.Append(value: $"display={display}&");
			builder.Append(value: $"scope={scope}&");
			builder.Append(value: "response_type=token&");
			builder.Append(value: $"v={_versionManager.Version}&");
			builder.Append(value: $"state={state}&");
			builder.Append(value: "revoke=1");

			return new Uri(builder.ToString());
		}

		/// <inheritdoc />
		AuthorizationResult INeedValidationHandler.Validate(string validateUrl, string phoneNumber)
		{
			throw new NotImplementedException();
		}
	}
}