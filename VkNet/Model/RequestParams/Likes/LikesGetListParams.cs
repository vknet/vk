using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса likes.getList
	/// </summary>
	[Serializable]
	public struct LikesGetListParams
	{
		/// <summary>
		/// Тип объекта.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public LikeObjectType Type { get; set; }

		/// <summary>
		/// Идентификатор владельца Like-объекта: id пользователя, id сообщества (со знаком
		/// «минус») или id приложения. Если
		/// параметр type равен sitepage, то в качестве owner_id необходимо передавать id
		/// приложения. Если параметр не задан,
		/// то считается, что он равен либо идентификатору текущего пользователя, либо
		/// идентификатору текущего приложения (если
		/// type равен sitepage).
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор Like-объекта. Если type равен sitepage, то параметр item_id может
		/// содержать значение параметра
		/// page_id, используемый при инициализации виджета «Мне нравится».
		/// </summary>
		public long ItemId { get; set; }

		/// <summary>
		/// Uri страницы, на которой установлен виджет «Мне нравится». Используется вместо
		/// параметра item_id, если при
		/// размещении виджета не был указан page_id.
		/// </summary>
		public Uri PageUrl { get; set; }

		/// <summary>
		/// Указывает, следует ли вернуть всех пользователей, добавивших объект в список
		/// "Мне нравится" или только тех, которые
		/// рассказали о нем друзьям. Параметр может принимать следующие значения:строка.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public LikesFilter Filter { get; set; }

		/// <summary>
		/// Указывает, необходимо ли возвращать только пользователей, которые являются
		/// друзьями текущего пользователя.
		/// </summary>
		public bool? FriendsOnly { get; set; }

		/// <summary>
		/// Смещение, относительно начала списка, для выборки определенного подмножества.
		/// Если параметр не задан, то считается,
		/// что он равен 0.
		/// </summary>
		public uint? Offset { get; set; }

		/// <summary>
		/// Количество возвращаемых идентификаторов пользователей.
		/// </summary>
		public uint? Count { get; set; }

		/// <summary>
		/// Не возвращать самого пользователя.
		/// </summary>
		public bool? SkipOwn { get; set; }

		/// <summary>
		/// 1 — возвращать расширенную информацию о пользователях и сообществах из списка
		/// поставивших отметку «Мне нравится»
		/// или сделавших репост. По умолчанию — 0.
		/// </summary>
		public bool? Extended { get; set; }
	}
}