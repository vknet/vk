using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Версия страницы
	/// </summary>
	[Serializable]
	public class PageVersion
	{
		/// <summary>
		/// идентификатор версии страницы;
		/// </summary>
		[JsonProperty(propertyName: "id")]
		public string Id { get; set; }

		/// <summary>
		/// длина версии страницы в байтах;
		/// </summary>
		[JsonProperty(propertyName: "length")]
		public string Length { get; set; }

		/// <summary>
		/// дата редактирования страницы;
		/// </summary>
		[JsonProperty(propertyName: "edited")]
		public string Edited { get; set; }

		/// <summary>
		/// идентификатор редактора;
		/// </summary>
		[JsonProperty(propertyName: "editor_id")]
		public string EditorId { get; set; }

		/// <summary>
		/// имя редактора.
		/// </summary>
		[JsonProperty(propertyName: "editor_name")]
		public string EditorName { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static PageVersion FromJson(VkResponse response)
		{
			return new PageVersion
			{
					Id = response[key: "id"]
					, Length = response[key: "length"]
					, Edited = response[key: "edited"]
					, EditorId = response[key: "editor_id"]
					, EditorName = response[key: "editor_name"]
			};
		}

	#endregion
	}
}