using System;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// VkApi Authorization
/// </summary>
public interface IVkApiAuthAsync : IVkApiAuth
{
	/// <inheritdoc cref="IVkApiAuth.Authorize(VkNet.Model.IApiAuthParams)"/>
	Task AuthorizeAsync(IApiAuthParams @params, CancellationToken token = default);

	/// <inheritdoc cref="IVkApiAuth.RefreshToken()"/>
	Task RefreshTokenAsync(Func<string> code = null, CancellationToken token = default);

	/// <inheritdoc cref="IVkApiAuth.RefreshToken"/>
	Task RefreshTokenAsync(Task<string> code = null, CancellationToken token = default);

	/// <inheritdoc cref="IVkApiAuth.LogOut"/>
	Task LogOutAsync(CancellationToken token = default);
}