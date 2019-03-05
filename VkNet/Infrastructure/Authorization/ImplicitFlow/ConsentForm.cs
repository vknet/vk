using Flurl.Http.Configuration;
using VkNet.Enums;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	public class ConsentForm : AbstractAuthorizationForm
	{
		public ConsentForm(IAuthorizationFormHtmlParser htmlParser, DefaultHttpClientFactory httpClientFactory)
			: base(htmlParser, httpClientFactory)
		{
		}

		/// <inheritdoc />
		public override ImplicitFlowPageType GetPageType() => ImplicitFlowPageType.Consent;

		/// <inheritdoc />
		protected override void FillFormFields(VkHtmlFormResult form)
		{
		}
	}
}