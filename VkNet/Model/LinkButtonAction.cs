using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Действие кнопки
	/// </summary>
	[Serializable]
	public class LinkButtonAction
	{
		/// <summary>
		/// Тип действия. Возможные значения.
		/// </summary>
		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }

		/// <summary>
		/// Ссылка на которую ведет кнопка.
		/// </summary>
		[JsonProperty(propertyName: "url")]
		public Uri Uri { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "target")]
		public string Target { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "group_id")]
		public long? GroupId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static LinkButtonAction FromJson(VkResponse response)
		{
			return new LinkButtonAction
			{
					Type = response[key: "type"]
					, Uri = response[key: "url"]
					, Target = response[key: "target"]
					, GroupId = response[key: "group_id"]
			};
		}
	}
}