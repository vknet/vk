using Flurl.Http.Configuration;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	public class TwoFactorForm : AbstractAuthorizationForm
	{
		private readonly IApiAuthParams _authorizationParameters;

		/// <inheritdoc />
		public TwoFactorForm(IApiAuthParams authorizationParameters, DefaultHttpClientFactory httpClientFactory,
							IAuthorizationFormHtmlParser htmlParser) : base(htmlParser, httpClientFactory)
		{
			_authorizationParameters = authorizationParameters;
		}

		/// <inheritdoc />
		public override ImplicitFlowPageType GetPageType() => ImplicitFlowPageType.TwoFactor;

		/// <inheritdoc />
		/// <summary>
		/// Заполнить форму двухфакторной авторизации
		/// </summary>
		/// <param name="form"> Форма </param>
		protected override void FillFormFields(VkHtmlFormResult form)
		{
			if (_authorizationParameters.TwoFactorAuthorization == null)
			{
				throw new VkAuthorizationException("Двухфакторная авторизация должна быть установлена в IApiAuthParams");
			}

			if (form.Fields.ContainsKey("code"))
			{
				form.Fields["code"] = _authorizationParameters.TwoFactorAuthorization.Invoke();
			}
		}
	}
}