using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип родственных связей.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum PrivacyKey
{
	/// <summary>
	/// Дата рождения
	/// </summary>
	BdateVisibility,

	/// <summary>
	/// Отображение фото
	/// </summary>
	PhotosWith,

	/// <summary>
	/// Отображение сохраненные фото
	/// </summary>
	PhotosSaved,

	/// <summary>
	/// Группы
	/// </summary>
	Groups,

	/// <summary>
	/// Аудио
	/// </summary>
	Audios,

	/// <summary>
	/// Подарки
	/// </summary>
	Gifts,

	/// <summary>
	/// Места
	/// </summary>
	Places,

	/// <summary>
	/// Скрытые друзья
	/// </summary>
	HiddenFriends,

	/// <summary>
	/// Стена
	/// </summary>
	Wall,

	/// <summary>
	/// Отправленное со стены
	/// </summary>
	WallSend,

	/// <summary>
	/// Просмотр ответов
	/// </summary>
	RepliesView,

	/// <summary>
	/// Статус ответов
	/// </summary>
	StatusReplies,

	/// <summary>
	/// Отмеченные на фото
	/// </summary>
	PhotosTagme,

	/// <summary>
	/// Отправленные сообщения
	/// </summary>
	MailSend,

	/// <summary>
	/// Звонки
	/// </summary>
	Calls,

	/// <summary>
	/// Звонки из приложения
	/// </summary>
	Appscall,

	/// <summary>
	/// Приглашения в группы
	/// </summary>
	GroupsInvite,

	/// <summary>
	/// Приглашения в приложение
	/// </summary>
	AppsInvite,

	/// <summary>
	/// Запросы дружбы
	/// </summary>
	FriendsRequests,

	/// <summary>
	/// Поиск по номеру телефона
	/// </summary>
	SearchByRegPhone,

	/// <summary>
	/// Истории
	/// </summary>
	Stories,

	/// <summary>
	/// Ответы к историям
	/// </summary>
	StoriesReplies,

	/// <summary>
	/// Вопросы к историям
	/// </summary>
	StoriesQuestions,

	/// <summary>
	/// Пожелания на день рождения к историям
	/// </summary>
	StoriesBirthdayWishes,

	/// <summary>
	/// Лайвы
	/// </summary>
	Lives,

	/// <summary>
	/// Ответы к лайвам
	/// </summary>
	LivesReplies,

	/// <summary>
	/// Онлайн статус
	/// </summary>
	Online,

	/// <summary>
	/// Приглашения в чат
	/// </summary>
	ChatInviteUser,

	/// <summary>
	/// Запросы в сообщения
	/// </summary>
	MessageRequests,

	/// <summary>
	/// Шаги запуска ВК
	/// </summary>
	VkRunSteps,

	/// <summary>
	/// Лента игр
	/// </summary>
	GamesFeed,

	/// <summary>
	/// Мини приложения
	/// </summary>
	MiniApps,

	/// <summary>
	/// IP звонки
	/// </summary>
	CallsIp,

	/// <summary>
	/// Вопросы
	/// </summary>
	Questions,

	/// <summary>
	/// Страницы доступа
	/// </summary>
	PageAccess,

	/// <summary>
	/// Сообщения компании
	/// </summary>
	CompanyMessages,

	/// <summary>
	/// Закрытый профиль
	/// </summary>
	ClosedProfile,

	/// <summary>
	/// Определение моего фото включено
	/// </summary>
	IsRecognizePhotoMeEnabled,

	/// <summary>
	/// Аватар контакта
	/// </summary>
	ContactAvatar,

	/// <summary>
	/// Звонки от сообществ
	/// </summary>
	CallsFromCommunity,

	/// <summary>
	/// Звонки с сообщений
	/// </summary>
	CallsHasMessages,

	/// <summary>
	/// Звонки с контактами
	/// </summary>
	CallsInContacts,

	/// <summary>
	/// Мобильные номера
	/// </summary>
	Mobile,

	/// <summary>
	/// Домашние
	/// </summary>
	Home
}