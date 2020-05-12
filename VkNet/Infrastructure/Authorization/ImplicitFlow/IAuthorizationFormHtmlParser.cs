using System;
using System.Threading.Tasks;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <summary>
	/// Authorization Form Html Parser
	/// </summary>
	public interface IAuthorizationFormHtmlParser
	{
		/// <summary>
		/// Get form data
		/// </summary>
		/// <param name="url">URL</param>
		/// <returns>Результат с данными формы</returns>
		Task<VkHtmlFormResult> GetFormAsync(Uri url);
	}
}