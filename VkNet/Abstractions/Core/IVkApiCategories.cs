using VkNet.Abstractions.Category;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Категории api
	/// </summary>
	public interface IVkApiCategories
	{
		/// <summary>
		/// API для работы с пользователями.
		/// </summary>
		IUsersCategory Users { get; }

		/// <summary>
		/// API для работы с друзьями.
		/// </summary>
		IFriendsCategory Friends { get; }

		/// <summary>
		/// API для работы со статусом пользователя или сообщества.
		/// </summary>
		IStatusCategory Status { get; }

		/// <summary>
		/// API для работы с сообщениями.
		/// </summary>
		IMessagesCategory Messages { get; }

		/// <summary>
		/// API для работы с группами.
		/// </summary>
		IGroupsCategory Groups { get; }

		/// <summary>
		/// API для работы с аудио записями.
		/// </summary>
		IAudioCategory Audio { get; }

		/// <summary>
		/// API для получения справочной информации (страны, города, школы, учебные
		/// заведения и т.п.).
		/// </summary>
		IDatabaseCategory Database { get; }

		/// <summary>
		/// API для работы со служебными методами.
		/// </summary>
		IUtilsCategory Utils { get; }

		/// <summary>
		/// API для работы со стеной пользователя.
		/// </summary>
		IWallCategory Wall { get; }

		/// <summary>
		/// API для работы со темами групп.
		/// </summary>
		IBoardCategory Board { get; }

		/// <summary>
		/// API для работы с закладками.
		/// </summary>
		IFaveCategory Fave { get; }

		/// <summary>
		/// API для работы с видео файлами.
		/// </summary>
		IVideoCategory Video { get; }

		/// <summary>
		/// API для работы с аккаунтом пользователя.
		/// </summary>
		IAccountCategory Account { get; }

		/// <summary>
		/// API для работы с фотографиями
		/// </summary>
		IPhotoCategory Photo { get; }

		/// <summary>
		/// API для работы с документами
		/// </summary>
		IDocsCategory Docs { get; }

		/// <summary>
		/// API для работы с лайками
		/// </summary>
		ILikesCategory Likes { get; }

		/// <summary>
		/// API для работы с wiki.
		/// </summary>
		IPagesCategory Pages { get; }

		/// <summary>
		/// API для работы с приложениями.
		/// </summary>
		IAppsCategory Apps { get; }

		/// <summary>
		/// API для работы с новостной лентой.
		/// </summary>
		INewsFeedCategory NewsFeed { get; }

		/// <summary>
		/// API для работы со статистикой.
		/// </summary>
		IStatsCategory Stats { get; }

		/// <summary>
		/// API для работы с подарками.
		/// </summary>
		IGiftsCategory Gifts { get; }

		/// <summary>
		/// API для работы с товарами.
		/// </summary>
		IMarketsCategory Markets { get; }

		/// <summary>
		/// API для работы с Авторизацией.
		/// </summary>
		IAuthCategory Auth { get; }

		/// <summary>
		/// API для работы с универсальным методом.
		/// </summary>
		IExecuteCategory Execute { get; }

		/// <summary>
		/// API для работы с опросами.
		/// </summary>
		IPollsCategory PollsCategory { get; }

		/// <summary>
		/// API для работы с поиском.
		/// </summary>
		ISearchCategory Search { get; }

		/// <summary>
		/// Storage Методы для работы с переменными в приложении.
		/// </summary>
		IStorageCategory Storage { get; }

		/// <summary>
		/// Методы этого класса позволяют производить действия с рекламными кабинетам
		/// пользователя.
		/// </summary>
		IAdsCategory Ads { get; }

		/// <summary>
		/// Notifications
		/// </summary>
		INotificationsCategory Notifications { get; }

		/// <summary>
		/// Widgets
		/// </summary>
		IWidgetsCategory Widgets { get; }

		/// <summary>
		/// Leads
		/// </summary>
		ILeadsCategory Leads { get; }

		/// <summary>
		/// Streaming
		/// </summary>
		IStreamingCategory Streaming { get; }

		/// <summary>
		/// Places
		/// </summary>
		IPlacesCategory Places { get; }

		/// <summary>
		/// Notes
		/// </summary>
		INotesCategory Notes { get; set; }

		/// <summary>
		/// AppWidgets
		/// </summary>
		IAppWidgetsCategory AppWidgets { get; set; }

		/// <summary>
		/// Orders
		/// </summary>
		IOrdersCategory Orders { get; set; }

		/// <summary>
		/// Secure
		/// </summary>
		ISecureCategory Secure { get; set; }

		/// <summary>
		/// Stories
		/// </summary>
		IStoriesCategory Stories { get; set; }

		/// <summary>
		/// Lead Forms
		/// </summary>
		ILeadFormsCategory LeadForms { get; set; }

		/// <summary>
		/// Pretty Cards
		/// </summary>
		IPrettyCardsCategory PrettyCards { get; set; }

		/// <summary>
		/// Podcasts
		/// </summary>
		IPodcastsCategory Podcasts { get; set; }

		/// <summary>
		/// Donut
		/// </summary>
		IDonutCategory Donut { get; }

		/// <summary>
		/// Donut
		/// </summary>
		IDownloadedGamesCategory DownloadedGames { get; }
	}
}