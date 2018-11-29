using System.Threading.Tasks;
using VkNet.Abstractions.Authorization;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IVkApiAuth"/>
	public interface IVkApiAuthAsync : IVkApiAuth
	{
		/// <inheritdoc cref="IVkApiAuth.Authorize"/>
		Task AuthorizeAsync(IAuthorizationFlow authorizationFlow);

		/// <inheritdoc cref="IVkApiAuth.LogOut"/>
		Task LogOutAsync();
	}
}