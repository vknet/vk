using System;
using System.Net;
using System.Threading.Tasks;
using VkNet.Abstractions.Utils;
using VkNet.Enums;
using VkNet.Exception;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
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
		public async Task<AuthorizationFormResult> ExecuteAsync(Uri url)
		{
			var form = await _htmlParser.GetFormAsync(url).ConfigureAwait(false);

			FillFormFields(form);

			var response = await _restClient.PostAsync(new Uri(form.Action), form.Fields);

			if (!response.IsSuccess)
			{
				throw new VkAuthorizationException(response.StatusCode.ToString());
			}

			var cookieContainer = new CookieContainer();

			// foreach (var pair in cli.Cookies)
			// {
			// 	cookieContainer.Add(pair.Value);
			// }

			return new AuthorizationFormResult
			{
				RequestUrl = url,
				ResponseUrl = url,
				Cookies = cookieContainer
			};
		}

		/// <summary>
		/// Заполнение полей формы
		/// </summary>
		/// <param name="form"> Форма </param>
		protected abstract void FillFormFields(VkHtmlFormResult form);
	}
}