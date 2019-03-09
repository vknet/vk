using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	public abstract class AbstractAuthorizationForm : IAuthorizationForm
	{
		private readonly IAuthorizationFormHtmlParser _htmlParser;

		private readonly DefaultHttpClientFactory _httpClientFactory;

		/// <inheritdoc />
		protected AbstractAuthorizationForm(IAuthorizationFormHtmlParser htmlParser, DefaultHttpClientFactory httpClientFactory)
		{
			_htmlParser = htmlParser;
			_httpClientFactory = httpClientFactory;
		}

		/// <inheritdoc />
		public abstract ImplicitFlowPageType GetPageType();

		/// <inheritdoc />
		public async Task<AuthorizationFormResult> ExecuteAsync(Url url)
		{
			var form = await _htmlParser.GetFormAsync(url).ConfigureAwait(false);

			FillFormFields(form);

			using (var cli = new FlurlClient(form.Action).EnableCookies())
			{
				if (_httpClientFactory != null)
				{
					cli.Configure(s => s.HttpClientFactory = _httpClientFactory);
				}

				var responseMessage = await cli.Request()
					.PostMultipartAsync(mp => mp.Add(new FormUrlEncodedContent(form.Fields)))
					.ConfigureAwait(false);

				if (!responseMessage.IsSuccessStatusCode)
				{
					throw new VkAuthorizationException(responseMessage.ReasonPhrase);
				}

				return new AuthorizationFormResult
				{
					RequestUrl = url,
					ResponseUrl = responseMessage.Headers.Location,
					Cookies = new Cookies()
				};
			}
		}

		/// <summary>
		/// Заполнение полей формы
		/// </summary>
		/// <param name="form">Форма</param>
		protected abstract void FillFormFields(VkHtmlFormResult form);
	}
}