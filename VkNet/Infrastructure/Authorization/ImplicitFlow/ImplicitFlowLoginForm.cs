using JetBrains.Annotations;
using VkNet.Abstractions.Utils;
using VkNet.Enums;
using VkNet.Model;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	[UsedImplicitly]
	public sealed class ImplicitFlowLoginForm : AbstractAuthorizationForm
	{
		private readonly IApiAuthParams _authorizationParameters;

		/// <inheritdoc />
		public ImplicitFlowLoginForm(IRestClient restClient, IAuthorizationFormHtmlParser htmlParser,
									IApiAuthParams authorizationParameters)
			: base(restClient, htmlParser)
		{
			_authorizationParameters = authorizationParameters;
		}

		/// <inheritdoc />
		public override ImplicitFlowPageType GetPageType() => ImplicitFlowPageType.LoginPassword;

		/// <inheritdoc />
		protected override void FillFormFields(VkHtmlFormResult form)
		{
			if (form.Fields.ContainsKey(AuthorizationFormFields.Email))
			{
				form.Fields[AuthorizationFormFields.Email] = _authorizationParameters.Login;
			}

			if (form.Fields.ContainsKey(AuthorizationFormFields.Password))
			{
				form.Fields[AuthorizationFormFields.Password] = _authorizationParameters.Password;
			}
		}
	}
}