using System;
using System.Threading.Tasks;
using Flurl;
using VkNet.Enums;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	public class ConsentForm: IAuthorizationForm
	{
		/// <inheritdoc />
		public ImplicitFlowPageType GetPageType() => ImplicitFlowPageType.Consent;

		/// <inheritdoc />
		public Task<AuthorizationFormResult> ExecuteAsync(Url authorizeUrl)
		{
			throw new NotImplementedException();
		}
	}
}