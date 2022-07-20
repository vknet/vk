using System;
using Newtonsoft.Json;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода groups.search
	/// </summary>
	[Serializable]
	public class GroupsSearchParams
	{
		/// <summary>
		/// Текст поискового запроса. строка, обязательный параметр.
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// Тип сообщества. Возможные значения: group, page, event. строка.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public GroupType Type { get; set; }

		/// <summary>
		/// Идентификатор страны. положительное число.
		/// </summary>
		public long? CountryId { get; set; }

		/// <summary>
		/// Идентификатор города. При передаче этого параметра поле country_id
		/// игнорируется. положительное число.
		/// </summary>
		public long? CityId { get; set; }

		/// <summary>
		/// При передаче значения 1 будут выведены предстоящие события. Учитывается только
		/// при передаче в качестве type
		/// значения event. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? Future { get; set; }

		/// <summary>
		/// при передаче значения 1 будут выведены сообщества с включенными товарами.
		/// </summary>
		[JsonProperty(propertyName: "market")]
		public bool? Market { get; set; }

		/// <summary>
		/// 0 — сортировать по умолчанию (аналогично результатам поиска в полной версии
		/// сайта);
		/// 1 — сортировать по скорости роста;
		/// 2 — сортировать по отношению дневной посещаемости к количеству пользователей;
		/// 3 — сортировать по отношению количества лайков к количеству пользователей;
		/// 4 — сортировать по отношению количества комментариев к количеству
		/// пользователей;
		/// 5 — сортировать по отношению количества записей в обсуждениях к количеству
		/// пользователей.
		/// целое число.
		/// </summary>
		public GroupSort Sort { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определённого подмножества результатов
		/// поиска. По умолчанию — 0. положительное
		/// число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Количество результатов поиска, которое необходимо вернуть. Обратите внимание —
		/// даже при использовании параметра
		/// offset для получения информации доступны только первые 1000 результатов.
		/// положительное число, по умолчанию 20, максимальное значение 1000.
		/// </summary>
		public long? Count { get; set; }
	}
}