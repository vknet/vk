using System;
using System.Threading.Tasks;
using VkNet.Abstractions.Core;
using VkNet.Model;

namespace VkNet.Infrastructure
{
	/// <inheritdoc />
	public class NeedValidationHandler : INeedValidationHandler
	{
		/// <inheritdoc />
		public AuthorizationResult Validate(string validateUrl, string phoneNumber)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public AuthorizationResult Validate(string validateUrl)
		{
			return ValidateAsync(validateUrl).ConfigureAwait(false).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public Task<AuthorizationResult> ValidateAsync(string validateUrl)
		{
			/*if (string.IsNullOrWhiteSpace(validateUrl))
			{
				throw new ArgumentException("Не задан адрес валидации!");
			}

			if (string.IsNullOrWhiteSpace(_authParams.Phone))
			{
				throw new ArgumentException("Не задан номер телефона!");
			}

			var validateUrlResult = await _restClient.GetAsync(new Uri(validateUrl), Enumerable.Empty<KeyValuePair<string, string>>());

			var codeForm = WebForm.From(validateUrlResult)
				.WithField("code")
				.FilledWith(_authParams.Phone.Substring(1, 8));

			var codeFormPostResult = await _restClient.PostAsync(new Uri(codeForm.ActionUrl), codeForm.GetFormFields());

			var result = VkAuthorization2.From(codeFormPostResult.ResponseUri.ToString());

			return new AuthorizationResult
			{
				AccessToken = result.AccessToken,
				State = result.State,
				UserId = result.UserId,
				ExpiresIn = result.ExpiresIn
			};*/
			throw new NotImplementedException();
		}
	}
}