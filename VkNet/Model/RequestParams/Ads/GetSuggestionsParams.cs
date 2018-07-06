using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Параметры запроса ads.getSuggestions
	/// </summary>
	[Serializable]
	public class GetSuggestionsParams
	{
		/// <summary>
		/// Раздел, по которому запрашиваются подсказки.
		/// Поддерживаются следующие значения:
		/// countries — страны;
		/// q — необязательный параметр;
		/// 1 — возвращается полный список стран;
		/// не задан — возвращается краткий список стран;
		/// regions — регионы;
		/// country — обязательный параметр;
		/// q — обязательный параметр;
		/// cities — города.
		/// country — обязательный параметр;
		/// q — необязательный параметр;
		/// districts — районы
		/// cities — обязательный параметр;
		/// stations — станции метро
		/// cities — обязательный параметр;
		/// streets — улицы
		/// cities — обязательный параметр;
		/// q — обязательный параметр;
		/// schools — учебные заведения: школы, университеты, факультеты, кафедры
		/// cities — обязательный параметр;
		/// q — обязательный параметр;
		/// interest_categories_v2 — категории интересов;
		/// interest_categories — устаревшие категории интересов;
		/// positions — должности (профессии);
		/// q — необязательный параметр;
		/// religions — религиозные взгляды;
		/// user_devices — устройства;
		/// user_os — операционные системы;
		/// user_browsers — интернет-браузеры.
		/// обязательный параметр, строка
		/// </summary>
		[JsonProperty("section")]
		public string Section { get; set; }

		/// <summary>
		/// ID объектов, разделённые запятыми. Служит для расшифровки ID, возвращаемых в методе ads.getAdsTargeting. Если задан этот параметр, то параметры q, country, cities не должны передаваться, таким образом отменяется их обязательность для конкретного раздела. Объекты возвращаются в том же порядке, в каком они были заданы в этом параметре. строка
		/// </summary>
		[JsonProperty("ids")]
		public string Ids { get; set; }

		/// <summary>
		/// Строка-фильтр запроса строка
		/// </summary>
		[JsonProperty("q")]
		public string Q { get; set; }

		/// <summary>
		/// ID городов, в которых ищутся объекты, разделенные запятыми. строка
		/// </summary>
		[JsonProperty("cities")]
		public string Cities { get; set; }

		/// <summary>
		/// Язык возвращаемых строковых значений. Поддерживаемые языки:
		/// ru — русский;
		/// ua — украинский;
		/// en — английский.
		/// строка
		/// </summary>
		[JsonProperty("lang")]
		public string Lang { get; set; }

		/// <summary>
		/// ID страны, в которой ищутся объекты. целое число
		/// </summary>
		[JsonProperty("country")]
		public long Country { get; set; }
	}
}