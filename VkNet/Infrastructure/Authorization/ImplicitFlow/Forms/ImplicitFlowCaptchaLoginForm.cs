using JetBrains.Annotations;
using VkNet.Abstractions.Utils;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Utils.AntiCaptcha;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow.Forms
{
	/// <inheritdoc />
	[UsedImplicitly]
	public sealed class ImplicitFlowCaptchaLoginForm : AbstractAuthorizationForm
	{
		private readonly ICaptchaSolver _captchaSolver;

		/// <inheritdoc />
		public ImplicitFlowCaptchaLoginForm(IRestClient restClient, IAuthorizationFormHtmlParser htmlParser, ICaptchaSolver captchaSolver)
			: base(restClient, htmlParser)
		{
			_captchaSolver = captchaSolver;
		}

		/// <inheritdoc />
		public override ImplicitFlowPageType GetPageType() => ImplicitFlowPageType.Captcha;

		/// <inheritdoc />
		protected override void FillFormFields(VkHtmlFormResult form, IApiAuthParams authParams)
		{
			if (_captchaSolver == null)
			{
				throw new VkAuthorizationException("Необходимо определить решатель капчи реализовав интерфейс " + nameof(ICaptchaSolver));
			}

			if (form.Fields.ContainsKey(AuthorizationFormFields.Email))
			{
				form.Fields[AuthorizationFormFields.Email] = authParams.Login;
			}

			if (form.Fields.ContainsKey(AuthorizationFormFields.Password))
			{
				form.Fields[AuthorizationFormFields.Password] = authParams.Password;
			}

			var captchaKey = _captchaSolver.Solve(form.UrlToCaptcha);

			if (form.Fields.ContainsKey(AuthorizationFormFields.CaptchaKey))
			{
				form.Fields[AuthorizationFormFields.CaptchaKey] = captchaKey;
			}
		}
	}
}