using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Ошибка при вызове метода exeute
	/// </summary>
	[Serializable]
	public class ExecuteError
	{
		/// <summary>
		/// Метод в котором произошла ошибка
		/// </summary>
		[JsonProperty("method")]
		public string Method { get; set; }

		/// <summary>
		/// Код ошибки
		/// </summary>
		[JsonProperty("error_code")]
		public int ErrorCode { get; set; }

		/// <summary>
		/// Сообщение об ошибке
		/// </summary>
		[JsonProperty("error_msg")]
		public string ErrorMessage { get; set; }
	}
}