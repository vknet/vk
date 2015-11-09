using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.RequestParams.App
{
	/// <summary>
	/// Параметры запроса для приложений
	/// </summary>
	public class GetCatalogParams
	{
		/// <summary>
		/// Параметры запроса для приложений.
		/// </summary>
		public GetCatalogParams()
		{
			Sort = AppSort.PopularToday;
			Offset = 0;
			Count = 100;
			Platform = AppPlatforms.Web;
			Extended = false;
			ReturnFriends = false;
		}

		/// <summary>
		/// Способ сортировки приложений
		/// </summary>
		public AppSort Sort
		{ get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества приложений.
		/// </summary>
		public uint Offset
		{ get; set; }

		/// <summary>
		/// Количество приложений, информацию о которых необходимо вернуть. 
		/// </summary>
		public uint Count
		{ get; set; }

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
		/// Поисковая строка для поиска по каталогу приложений..
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
	}
}
