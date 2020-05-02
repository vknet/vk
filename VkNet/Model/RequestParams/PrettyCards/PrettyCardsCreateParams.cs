using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{

	/// <summary>
	/// Список параметров для метода prettyCards.create
	/// </summary>
	[Serializable]
	public class PrettyCardsCreateParams
	{
		/// <summary>
		/// Идентификатор сообщества.
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Фотография карточки.
		/// Используйте значение, полученное после загрузки фотографии на сервер.См. метод prettyCards.getUploadURL.
		/// Также можно переиспользовать существующую фотографию из другой карточки.
		/// Используйте значение поля photo, которое возвращает метод prettyCards.get или prettyCards.getById.
		/// </summary>
		[JsonProperty("photo")]
		public string Photo { get; set; }

		/// <summary>
		/// Заголовок.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Ссылка.
		/// Кроме http(s)-ссылок также допускается указание телефонных номеров в виде tel:+79111234567
		/// </summary>
		[JsonProperty("link")]
		public string Link { get; set; }

		/// <summary>
		/// Цена.
		/// «0» будет отображён как «Бесплатно».
		/// Не передавайте этот параметр, чтобы не указывать цену.
		/// </summary>
		[JsonProperty("price")]
		public string Price { get; set; }

		/// <summary>
		/// Старая цена. Отображается зачёркнутой.
		/// «0» будет отображён как «Бесплатно».
		/// Не передавайте этот параметр, чтобы не указывать старую цену.
		/// </summary>
		[JsonProperty("price_old")]
		public string PriceOld { get; set; }

		/// <summary>
		/// Кнопка.
		/// Не передавайте этот параметр, чтобы не использовать кнопку.
		/// </summary>
		[JsonProperty("button")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public Enums.SafetyEnums.Button Button { get; set; }
	}
}