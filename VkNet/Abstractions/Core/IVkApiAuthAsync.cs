using System;
using System.Threading.Tasks;
using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IVkApiAuth"/>
	public interface IVkApiAuthAsync : IVkApiAuth
	{
		/// <inheritdoc cref="IVkApiAuth.Authorize(VkNet.Model.IApiAuthParams)"/>
		Task AuthorizeAsync(IApiAuthParams @params);

		/// <inheritdoc cref="IVkApiAuth.RefreshToken"/>
		Task RefreshTokenAsync(Func<string> code = null);

		/// <inheritdoc cref="IVkApiAuth.LogOut"/>
		Task LogOutAsync();
	}
}