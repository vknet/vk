using System;
using System.Text;
using System.Threading.Tasks;
using VkNet.Abstractions.Utils;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow.Forms
{
	/// <inheritdoc />
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
		public async Task<AuthorizationFormResult> ExecuteAsync(Uri url, IApiAuthParams authParams)
		{
			var form = await _htmlParser.GetFormAsync(url).ConfigureAwait(false);

			FillFormFields(form, authParams);

			var response = await _restClient.PostAsync(new Uri(form.Action), form.Fields, Encoding.GetEncoding(1251)).ConfigureAwait(false);

			if (!response.IsSuccess)
			{
				throw new VkAuthorizationException(response.Message);
			}

			return new AuthorizationFormResult
			{
				RequestUrl = response.RequestUri,
				ResponseUrl = response.ResponseUri
			};
		}

		/// <summary>
		/// Заполнение полей формы
		/// </summary>
		/// <param name="form"> Форма </param>
		/// <param name="authParams">Параметры авторизации.</param>
		protected abstract void FillFormFields(VkHtmlFormResult form, IApiAuthParams authParams);
	}
}