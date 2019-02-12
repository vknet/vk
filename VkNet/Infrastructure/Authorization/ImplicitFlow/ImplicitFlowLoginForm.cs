using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using VkNet.Exception;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	public class ImplicitFlowLoginForm : IImplicitFlowLoginForm
	{
		/// <inheritdoc />
		public async Task<AuthorizationFormResult> ExecuteAsync(Url authorizeUrl)
		{
			var httpResponseMessage = await authorizeUrl.GetAsync().ConfigureAwait(false);

			if (!httpResponseMessage.IsSuccessStatusCode)
			{
				throw new VkAuthorizationException(httpResponseMessage.ReasonPhrase);
			}

			return new AuthorizationFormResult
			{
				Content = httpResponseMessage.Content,
				RequestUrl = httpResponseMessage.RequestMessage.RequestUri,
				ResponseUrl = authorizeUrl
			};
		}
	}
}