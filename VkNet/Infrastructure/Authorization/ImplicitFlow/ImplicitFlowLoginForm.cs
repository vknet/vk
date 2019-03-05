using Flurl.Http.Configuration;
using VkNet.Enums;
using VkNet.Model;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	public class ImplicitFlowLoginForm : AbstractAuthorizationForm
	{
		private readonly IApiAuthParams _authorizationParameters;

		/// <inheritdoc />
		public ImplicitFlowLoginForm(DefaultHttpClientFactory httpClientFactory, IAuthorizationFormHtmlParser htmlParser,
									IApiAuthParams authorizationParameters) : base(htmlParser, httpClientFactory)
		{
			_authorizationParameters = authorizationParameters;
		}

		/// <inheritdoc />
		public override ImplicitFlowPageType GetPageType() => ImplicitFlowPageType.LoginPassword;

		/// <inheritdoc />
		protected override void FillFormFields(VkHtmlFormResult form)
		{
			if (form.Fields.ContainsKey("email"))
			{
				form.Fields["email"] = _authorizationParameters.Login;
			}

			if (form.Fields.ContainsKey("pass"))
			{
				form.Fields["pass"] = _authorizationParameters.Password;
			}
		}
	}
}