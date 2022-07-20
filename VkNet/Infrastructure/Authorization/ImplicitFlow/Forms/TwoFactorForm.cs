using JetBrains.Annotations;
using VkNet.Abstractions.Utils;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow.Forms
{
	/// <inheritdoc />
	[UsedImplicitly]
	public sealed class TwoFactorForm : AbstractAuthorizationForm
	{
		/// <inheritdoc />
		public TwoFactorForm(IRestClient restClient, IAuthorizationFormHtmlParser htmlParser)
			: base(restClient, htmlParser)
		{
		}

		/// <inheritdoc />
		public override ImplicitFlowPageType GetPageType() => ImplicitFlowPageType.TwoFactor;

		/// <inheritdoc />
		protected override void FillFormFields(VkHtmlFormResult form, IApiAuthParams authParams)
		{
			if (authParams.TwoFactorAuthorization == null)
			{
				throw new VkAuthorizationException("Двухфакторная авторизация должна быть установлена в " + nameof(IApiAuthParams));
			}

			if (form.Fields.ContainsKey(AuthorizationFormFields.Code))
			{
				form.Fields[AuthorizationFormFields.Code] = authParams.TwoFactorAuthorization.Invoke();
			}
		}
	}
}