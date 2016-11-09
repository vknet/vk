using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса для приложений
	/// </summary>
	public struct AppGetCatalogParams
	{
		/// <summary>
		/// Параметры запроса для приложений.
		/// </summary>
		public AppGetCatalogParams(bool gog = true)
		{
			Sort = AppSort.PopularToday;
			Offset = 0;
			Count = 100;
			Platform = AppPlatforms.Web;
			Extended = false;
			ReturnFriends = false;
			Fields = null;
			NameCase = null;
			Query = null;
			GenreId = null;
			Filter = null;
		}
		/// <summary>
		/// Способ сортировки приложений
		/// </summary>
		public AppSort Sort { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества приложений.
		/// </summary>
		public uint Offset
		{ get; set; }

		/// <summary>
		/// Количество приложений, информацию о которых необходимо вернуть.
		/// </summary>
		public uint Count { get; set; }

		/// <summary>
		/// Платформа для которой необходимо вернуть приложения, принимает значения: ios, android, winphone, web. По умолчанию используется web.
		/// </summary>
		public AppPlatforms Platform
		{ get; set; }

		/// <summary>
		/// Позволяет получить дополнительные поля: screenshots, MAU (количество уникальных посетителей в месяц),
		/// catalog_position, international (отображается ли приложение в каталоге у иностранных пользователей).
		/// По умолчанию возвращает только основные поля приложений. Если указан extended – count не должен быть больше 100.
		/// </summary>
		public bool Extended
		{ get; set; }

		/// <summary>
		/// <c>true</c> – возвращает список друзей, установивших это приложение.
		/// (Данный параметр работает только, если пользователь передал валидный access_token)
		/// <c>false</c> – не возвращать список друзей, по умолчанию.
		/// </summary>
		public bool ReturnFriends
		{ get; set; }

		/// <summary>
		/// Список дополнительных полей, которые необходимо вернуть для профилей пользователей.
		/// </summary>
		public UsersFields Fields
		{ get; set; }

		/// <summary>
		/// Падеж для склонения имени и фамилии пользователей.
		/// </summary>
		public NameCase NameCase
		{ get; set; }
		/// <summary>
		/// Поисковая строка для поиска по каталогу приложений.
		/// </summary>
		public string Query
		{ get; set; }
		/// <summary>
		/// Идентификатор жанра.
		/// </summary>
		public uint? GenreId
		{ get; set; }
		/// <summary>
		/// Фильтр.
		/// </summary>
		public AppFilter Filter
		{ get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		public static VkParameters ToVkParameters(AppGetCatalogParams p)
		{
			var parameters = new VkParameters
			{
				{ "sort", p.Sort },
				{ "offset", p.Offset },
				{ "count", p.Count },
				{ "platform", p.Platform },
				{ "extended", p.Extended },
				{ "return_friends", p.ReturnFriends },
				{ "fields", p.Fields },
				{ "name_case", p.NameCase },
				{ "q", p.Query },
				{ "genre_id", p.GenreId },
				{ "filter", p.Filter }
			};

			return parameters;
		}
	}
}
