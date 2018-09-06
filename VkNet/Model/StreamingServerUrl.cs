using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Данные для подключения к Streaming API.
	/// </summary>
	[Serializable]
	public class StreamingServerUrl
	{
		/// <summary>
		/// Хост для подключения к серверу;
		/// </summary>
		[JsonProperty(propertyName: "endpoint")]
		public string Endpoint { get; set; }

		/// <summary>
		/// Ключ доступа. Ключ бессрочный и прекращает действовать только после получения
		/// нового ключа.
		/// </summary>
		[JsonProperty(propertyName: "key")]
		public string Key { get; set; }
	}
}