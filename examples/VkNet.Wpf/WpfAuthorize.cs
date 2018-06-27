using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using JetBrains.Annotations;
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
		/// <inheritdoc />
		public string GetJson(string url, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public VkAuthorization Authorize(IApiAuthParams authParams)
		{
			var dlg = new AuthForm();
			dlg.WebBrowser.Navigate(CreateAuthorizeUrlFor(authParams.ApplicationId, authParams.Settings, Display.Mobile));

			dlg.WebBrowser.Navigated += (sender, args) =>
			{
				var result = VkAuthorization.From(args.Uri.AbsoluteUri);

				if (!result.IsAuthorized)
				{
					return;
				}

				dlg.Auth = result;
				dlg.Close();
			};

			dlg.ShowDialog();

			return dlg.Auth;
		}

		/// <inheritdoc />
		public VkAuthorization Validate(string validateUrl, string phoneNumber)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public IWebProxy Proxy { get; set; }

		/// <summary>
		/// Построить URL для авторизации.
		/// </summary>
		/// <param name="appId"> Идентификатор приложения. </param>
		/// <param name="settings"> Настройки прав доступа. </param>
		/// <param name="display"> Вид окна авторизации. </param>
		/// <returns> Возвращает Uri для авторизации </returns>
		[NotNull]
		private static string CreateAuthorizeUrlFor(ulong appId, [NotNull]
													Settings settings, [NotNull]
													Display display)
		{
			var builder = new StringBuilder(value: "https://oauth.vk.com/authorize?");

			builder.AppendFormat(format: "client_id={0}&", arg0: appId);
			builder.AppendFormat(format: "scope={0}&", arg0: settings.ToUInt64());
			builder.Append(value: "redirect_uri=https://oauth.vk.com/blank.html&");
			builder.AppendFormat(format: "display={0}&", arg0: display);
			builder.Append(value: "response_type=token");

			return builder.ToString();
		}
	}
}