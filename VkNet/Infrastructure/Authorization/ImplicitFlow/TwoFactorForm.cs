using System;
using System.Threading.Tasks;
using Flurl;
using VkNet.Enums;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	public class TwoFactorForm: IAuthorizationForm
	{
		/// <inheritdoc />
		public ImplicitFlowPageType GetPageType() => ImplicitFlowPageType.TwoFactor;

		/// <inheritdoc />
		public Task<AuthorizationFormResult> ExecuteAsync(Url authorizeUrl)
		{
			throw new NotImplementedException();
		}
	}
}