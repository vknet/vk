using System;
using System.Threading.Tasks;
using Flurl;
using VkNet.Enums;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	public class ImplicitFlowCaptchaLoginForm: IAuthorizationForm
	{
		/// <inheritdoc />
		public ImplicitFlowPageType GetPageType() => ImplicitFlowPageType.Captcha;

		/// <inheritdoc />
		public Task<AuthorizationFormResult> ExecuteAsync(Url authorizeUrl)
		{
			throw new NotImplementedException();
		}
	}
}