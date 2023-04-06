using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using VkNet.Abstractions.Utils;
using VkNet.Model;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow.Forms;

/// <inheritdoc />
[UsedImplicitly]
public sealed class ImplicitFlowLoginForm : AbstractAuthorizationForm
{
	/// <inheritdoc />
	public ImplicitFlowLoginForm(IRestClient restClient, IAuthorizationFormHtmlParser htmlParser)
		: base(restClient, htmlParser)
	{
	}

	/// <inheritdoc />
	public override ImplicitFlowPageType GetPageType() => ImplicitFlowPageType.LoginPassword;

	/// <inheritdoc />
	protected override Task FillFormFieldsAsync(VkHtmlFormResult form, IApiAuthParams authParams, CancellationToken token = default)
	{
		if (form.Fields.ContainsKey(AuthorizationFormFields.Email))
		{
			form.Fields[AuthorizationFormFields.Email] = authParams.Login;
		}

		if (form.Fields.ContainsKey(AuthorizationFormFields.Password))
		{
			form.Fields[AuthorizationFormFields.Password] = authParams.Password;
		}

		form.Headers = new()
		{
			{ "content-type", "application/x-www-form-urlencoded" },
			{ "origin", "https://oauth.vk.com" },
			{ "referer", "https://oauth.vk.com/" }
		};

		return Task.CompletedTask;
	}
}