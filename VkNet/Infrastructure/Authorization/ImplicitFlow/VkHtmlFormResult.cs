using System.Collections.Generic;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <summary>
	/// Результат отправки формы
	/// </summary>
	public class VkHtmlFormResult
	{
		/// <summary>
		/// Метод для отправки формы
		/// </summary>
		public string Method { get; set; }

		/// <summary>
		/// URL для отправки формы
		/// </summary>
		public string Action { get; set; }

		/// <summary>
		/// Поля формы
		/// </summary>
		public Dictionary<string, string> Fields { get; set; }
	}
}