using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using VkNet.Enums;
using VkNet.Exception;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	public abstract class AbstractAuthorizationForm : IAuthorizationForm
	{
		private readonly IAuthorizationFormHtmlParser _htmlParser;

		/// <inheritdoc cref="AbstractAuthorizationForm"/>
		protected AbstractAuthorizationForm(IAuthorizationFormHtmlParser htmlParser)
		{
			_htmlParser = htmlParser;
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
				var responseMessage = await cli.Request()
					.PostMultipartAsync(mp => mp.Add(new FormUrlEncodedContent(form.Fields)))
					.ConfigureAwait(false);

				if (!responseMessage.IsSuccessStatusCode)
				{
					throw new VkAuthorizationException(responseMessage.ReasonPhrase);
				}

				var cookieContainer = new CookieContainer();

				foreach (var pair in cli.Cookies)
				{
					cookieContainer.Add(pair.Value);
				}

				return new AuthorizationFormResult
				{
					RequestUrl = url,
					ResponseUrl = responseMessage.Headers.Location ?? url,
					Cookies = cookieContainer
				};
			}
		}

		/// <summary>
		/// Заполнение полей формы
		/// </summary>
		/// <param name="form"> Форма </param>
		protected abstract void FillFormFields(VkHtmlFormResult form);
	}
}