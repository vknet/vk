using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions.Utils;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow.Forms;

/// <inheritdoc cref="IAuthorizationForm" />
public abstract class AbstractAuthorizationForm : IAuthorizationForm
{
	private readonly IRestClient _restClient;

	private readonly IAuthorizationFormHtmlParser _htmlParser;

	/// <inheritdoc cref="AbstractAuthorizationForm"/>
	protected AbstractAuthorizationForm(IRestClient restClient, IAuthorizationFormHtmlParser htmlParser)
	{
		_restClient = restClient;
		_htmlParser = htmlParser;
	}

	/// <inheritdoc />
	public abstract ImplicitFlowPageType GetPageType();

	/// <inheritdoc />
	public async Task<AuthorizationFormResult> ExecuteAsync(Uri url, IApiAuthParams authParams, CancellationToken token = default)
	{
		var form = await _htmlParser.GetFormAsync(url, token)
			.ConfigureAwait(false);

		await FillFormFieldsAsync(form, authParams, token);
		token.ThrowIfCancellationRequested();
		var response = await _restClient.PostAsync(new(form.Action), form.Fields, Encoding.UTF8, form.Headers, token)
			.ConfigureAwait(false);

		if (!response.IsSuccess)
		{
			throw new VkAuthorizationException(response.Message);
		}

		return new()
		{
			RequestUrl = response.RequestUri
		};
	}

	/// <summary>
	/// Заполнение полей формы
	/// </summary>
	/// <param name="form"> Форма </param>
	/// <param name="authParams">Параметры авторизации.</param>
	/// <param name="token">Токен отмены операции</param>
	protected abstract Task FillFormFieldsAsync(VkHtmlFormResult form, IApiAuthParams authParams, CancellationToken token = default);
}