using System;
using System.Net;
using System.Threading;
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
			return ValidateAsync(validateUrl, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public async Task<AuthorizationResult> ValidateAsync(string validateUrl, CancellationToken cancellationToken = default)
		{
			if (string.IsNullOrWhiteSpace(validateUrl))
			{
				throw new ArgumentException("Не задан адрес валидации!");
			}

			if (string.IsNullOrWhiteSpace(_authParams.Phone))
			{
				throw new ArgumentException("Не задан номер телефона!");
			}

			var validateUrlResult = await WebCall.MakeCallAsync(validateUrl, _proxy, cancellationToken).ConfigureAwait(false);

			var codeForm = WebForm.From(validateUrlResult)
				.WithField("code")
				.FilledWith(_authParams.Phone.Substring(1, 8));

			var codeFormPostResult = await WebCall.PostAsync(codeForm, _proxy, cancellationToken).ConfigureAwait(false);

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