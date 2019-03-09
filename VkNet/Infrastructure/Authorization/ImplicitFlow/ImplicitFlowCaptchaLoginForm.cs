using Flurl.Http.Configuration;
using JetBrains.Annotations;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Utils.AntiCaptcha;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	[UsedImplicitly]
	public sealed class ImplicitFlowCaptchaLoginForm : AbstractAuthorizationForm
	{
		private readonly IApiAuthParams _authorizationParameters;

		private readonly ICaptchaSolver _captchaSolver;

		/// <inheritdoc />
		public ImplicitFlowCaptchaLoginForm(IAuthorizationFormHtmlParser htmlParser, DefaultHttpClientFactory httpClientFactory,
											IApiAuthParams authorizationParameters, ICaptchaSolver captchaSolver)
			: base(htmlParser, httpClientFactory)
		{
			_authorizationParameters = authorizationParameters;
			_captchaSolver = captchaSolver;
		}

		/// <inheritdoc />
		public override ImplicitFlowPageType GetPageType() => ImplicitFlowPageType.Captcha;

		/// <inheritdoc />
		protected override void FillFormFields(VkHtmlFormResult form)
		{
			if (_captchaSolver == null)
			{
				throw new VkAuthorizationException("Необходимо определить решатель капчи реализовав интерфейс " + nameof(ICaptchaSolver));
			}

			if (form.Fields.ContainsKey(AuthorizationFormFields.Email))
			{
				form.Fields[AuthorizationFormFields.Email] = _authorizationParameters.Login;
			}

			if (form.Fields.ContainsKey(AuthorizationFormFields.Password))
			{
				form.Fields[AuthorizationFormFields.Password] = _authorizationParameters.Password;
			}

			var captchaKey = _captchaSolver.Solve($"https://api.vk.com//captcha.php?sid={form.Fields[AuthorizationFormFields.CaptchaSid]}&s=1");

			if (form.Fields.ContainsKey(AuthorizationFormFields.CaptchaKey))
			{
				form.Fields[AuthorizationFormFields.CaptchaKey] = captchaKey;
			}
		}
	}
}