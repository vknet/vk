using JetBrains.Annotations;
using VkNet.Enums;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	[UsedImplicitly]
	public sealed class ConsentForm : AbstractAuthorizationForm
	{
		/// <inheritdoc />
		public ConsentForm(IAuthorizationFormHtmlParser htmlParser)
			: base(htmlParser)
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