using System;
using System.Net;
using System.Threading.Tasks;
using VkNet.Abstractions.Core;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Infrastructure
{
	/// <inheritdoc />
	public class NeedValidationHandler : INeedValidationHandler
	{
		private readonly IWebProxy _proxy;

		private readonly IApiAuthParams _authParams;

		public NeedValidationHandler(IApiAuthParams authParams, IWebProxy proxy)
		{
			_authParams = authParams;
			_proxy = proxy;
		}

		/// <inheritdoc />
		public AuthorizationResult Validate(string validateUrl, string phoneNumber)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public AuthorizationResult Validate(string validateUrl)
		{
			var result = ValidateAsync(validateUrl);
			Task.WaitAll(result);

			return result.GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public async Task<AuthorizationResult> ValidateAsync(string validateUrl)
		{
			if (string.IsNullOrWhiteSpace(validateUrl))
			{
				throw new ArgumentException("Не задан адрес валидации!");
			}

			if (string.IsNullOrWhiteSpace(_authParams.Phone))
			{
				throw new ArgumentException("Не задан номер телефона!");
			}

			var validateUrlResult = await WebCall.MakeCallAsync(validateUrl, _proxy).ConfigureAwait(false);

			var codeForm = WebForm.From(validateUrlResult)
				.WithField("code")
				.FilledWith(_authParams.Phone.Substring(1, 8));

			var codeFormPostResult = await WebCall.PostAsync(codeForm, _proxy).ConfigureAwait(false);

			var result = VkAuthorization2.From(codeFormPostResult.ResponseUrl.ToString());

			return new AuthorizationResult
			{
				AccessToken = result.AccessToken,
				State = result.State,
				UserId = result.UserId,
				ExpiresIn = result.ExpiresIn
			};
		}
	}
}