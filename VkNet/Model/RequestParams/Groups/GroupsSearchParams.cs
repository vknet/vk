using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода groups.search
	/// </summary>
	public struct GroupsSearchParams
	{
		/// <summary>
		/// Параметры метода groups.search
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public GroupsSearchParams(bool gag = true)
		{
			Query = null;
			Type = null;
			CountryId = null;
			CityId = null;
			Future = null;
			Sort = GroupSort.Normal;
			Offset = null;
			Count = null;
		}


		/// <summary>
		/// Текст поискового запроса. строка, обязательный параметр.
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// Тип сообщества. Возможные значения: group, page, event. строка.
		/// </summary>
		public GroupType Type { get; set; }

		/// <summary>
		/// Идентификатор страны. положительное число.
		/// </summary>
		public long? CountryId { get; set; }

		/// <summary>
		/// Идентификатор города. При передаче этого параметра поле country_id игнорируется. положительное число.
		/// </summary>
		public long? CityId { get; set; }

		/// <summary>
		/// При передаче значения 1 будут выведены предстоящие события. Учитывается только при передаче в качестве type значения event. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? Future { get; set; }

		/// <summary>
		/// 0 — сортировать по умолчанию (аналогично результатам поиска в полной версии сайта);
		/// 1 — сортировать по скорости роста;
		/// 2 — сортировать по отношению дневной посещаемости к количеству пользователей;
		/// 3 — сортировать по отношению количества лайков к количеству пользователей;
		/// 4 — сортировать по отношению количества комментариев к количеству пользователей;
		/// 5 — сортировать по отношению количества записей в обсуждениях к количеству пользователей.
		/// целое число.
		/// </summary>
		public GroupSort Sort { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определённого подмножества результатов поиска. По умолчанию — 0. положительное число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Количество результатов поиска, которое необходимо вернуть. Обратите внимание — даже при использовании параметра offset для получения информации доступны только первые 1000 результатов.
		///  положительное число, по умолчанию 20, максимальное значение 1000.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(GroupsSearchParams p)
		{
			var parameters = new VkParameters
			{
				{ "q", p.Query },
				{ "type", p.Type },
				{ "country_id", p.CountryId },
				{ "city_id", p.CityId },
				{ "future", p.Future },
				{ "sort", p.Sort },
				{ "offset", p.Offset },
				{ "count", p.Count }
			};

			return parameters;
		}
	}
}