using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Ответ метода Storage.Get
	/// </summary>
	[Serializable]
	public class StorageObject
	{
		/// <summary>
		/// Ключ
		/// </summary>
		[JsonProperty(propertyName: "key")]
		public string Key { get; set; }

		/// <summary>
		/// Значение
		/// </summary>
		[JsonProperty(propertyName: "value")]
		public string Value { get; set; }
	}
}