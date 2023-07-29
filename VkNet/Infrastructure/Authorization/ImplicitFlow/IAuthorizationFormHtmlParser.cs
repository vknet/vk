using System;
using System.Threading;
using System.Threading.Tasks;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow;

/// <summary>
/// Authorization Form Html Parser
/// </summary>
public interface IAuthorizationFormHtmlParser
{
	/// <summary>
	/// Get form data
	/// </summary>
	/// <param name="url">URL</param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>Результат с данными формы</returns>
	Task<VkHtmlFormResult> GetFormAsync(Uri url, CancellationToken token = default);
}