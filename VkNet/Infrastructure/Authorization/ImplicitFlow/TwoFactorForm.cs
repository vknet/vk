using JetBrains.Annotations;
using VkNet.Abstractions.Utils;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	[UsedImplicitly]
	public sealed class TwoFactorForm : AbstractAuthorizationForm
	{
		private readonly IApiAuthParams _authorizationParameters;

		/// <inheritdoc />
		public TwoFactorForm(IRestClient restClient, IApiAuthParams authorizationParameters, IAuthorizationFormHtmlParser htmlParser)
			: base(restClient, htmlParser)
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
				throw new VkAuthorizationException("Двухфакторная авторизация должна быть установлена в " + nameof(IApiAuthParams));
			}

			if (form.Fields.ContainsKey(AuthorizationFormFields.Code))
			{
				form.Fields[AuthorizationFormFields.Code] = _authorizationParameters.TwoFactorAuthorization.Invoke();
			}
		}
	}
}