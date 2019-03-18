using Flurl.Http.Configuration;
using JetBrains.Annotations;
using VkNet.Enums;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	[UsedImplicitly]
	public sealed class ConsentForm : AbstractAuthorizationForm
	{
		/// <inheritdoc />
		public ConsentForm(IAuthorizationFormHtmlParser htmlParser, DefaultHttpClientFactory httpClientFactory, IFlurlClientFactory _factory)
			: base(htmlParser, httpClientFactory, _factory)
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