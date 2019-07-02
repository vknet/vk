using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Настройка
	/// </summary>
	[Serializable]
	public class TokenPermission
	{
		/// <summary>
		/// Битовая маска права доступа
		/// </summary>
		[JsonProperty("setting")]
		public long Setting { get; set; }

		/// <summary>
		/// Название права доступа.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}