using System;
using Newtonsoft.Json;
using VkNet.Infrastructure;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры настройки уведомлений о событиях в Callback API.
	/// </summary>
	[Serializable]
	public class CallbackServerParams
	{
		/// <summary>
		/// идентификатор сообщества.
		/// </summary>
		[JsonProperty(propertyName: "group_id")]
		public ulong? GroupId { get; set; }

		/// <summary>
		/// идентификатор сервера.
		/// </summary>
		[JsonProperty(propertyName: "server_id")]
		public long? ServerId { get; set; }

		/// <summary>
		/// Версия Callback API.
		/// </summary>
		[JsonProperty(propertyName: "api_version")]
		public VkApiVersionManager ApiVersion { get; set; }

		/// <summary>
		/// Настройки уведомлений
		/// </summary>
		[JsonProperty(propertyName: "callback_settings")]
		public CallbackSettings CallbackSettings { get; set; }
	}
}