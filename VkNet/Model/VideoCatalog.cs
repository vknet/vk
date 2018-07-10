using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Данные для отображения блока видеокаталога
	/// </summary>
	[Serializable]
	public class VideoCatalog
	{
		/// <summary>
		/// Список элементов блока видеокаталога
		/// </summary>
		public ReadOnlyCollection<VideoCatalogItem> Items { get; set; }

		/// <summary>
		/// Идентификатор блока. Возвращается строка для предопределенных блоков. Для
		/// других возвращается число.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Заголовок блока.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Параметр для получения следующей страницы результатов. Необходимо передать его
		/// значение в from в следующем вызове,
		/// чтобы получить содержимое каталога, следующее за полученным в текущем вызове.
		/// </summary>
		public string Next { get; set; }

		/// <summary>
		/// предпочтительный способ отображения контента
		/// </summary>
		[JsonProperty(propertyName: "view")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public VideoView View { get; set; }

		/// <summary>
		/// Наличие возможности скрыть блок.
		/// </summary>
		public bool? CanHide { get; set; }

		/// <summary>
		/// Тип блока.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public VideoCatalogType Type { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static VideoCatalog FromJson(VkResponse response)
		{
			var item = new VideoCatalog
			{
					Id = response[key: "id"]
					, Name = response[key: "name"]
					, CanHide = response[key: "can_hide"]
					, Type = response[key: "type"]
					, Next = response[key: "next"]
					, Items = response[key: "items"].ToReadOnlyCollectionOf<VideoCatalogItem>(selector: x => x)
					, View = response[key: "view"]
			};

			return item;
		}
	}
}