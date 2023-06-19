using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using VkNet.Abstractions.Utils;
using VkNet.Model;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow.Forms;

/// <inheritdoc />
[UsedImplicitly]
public sealed class ConsentForm : AbstractAuthorizationForm
{
	/// <inheritdoc />
	public ConsentForm(IRestClient restClient, IAuthorizationFormHtmlParser htmlParser)
		: base(restClient, htmlParser)
	{
	}

	/// <inheritdoc />
	public override ImplicitFlowPageType GetPageType() => ImplicitFlowPageType.Consent;

	/// <inheritdoc />
	protected override Task FillFormFieldsAsync(VkHtmlFormResult form, IApiAuthParams authParams)
	{
		return Task.CompletedTask;
	}
}