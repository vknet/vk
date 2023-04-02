using System;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;

namespace VkNet.Abstractions;

/// <inheritdoc cref="IVkApiAuth"/>
public interface IVkApiAuthAsync : IVkApiAuth
{
	/// <inheritdoc cref="IVkApiAuth.Authorize(VkNet.Model.IApiAuthParams)"/>
	Task AuthorizeAsync(IApiAuthParams @params, CancellationToken token = default);

	/// <inheritdoc cref="IVkApiAuth.RefreshToken"/>
	Task RefreshTokenAsync(Func<string> code = null, Func<Task<string>> codeAsync = null, CancellationToken token = default);

	/// <inheritdoc cref="IVkApiAuth.LogOut"/>
	Task LogOutAsync(CancellationToken token = default);
}