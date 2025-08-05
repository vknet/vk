namespace VkNet.Utils;

/// <summary>
/// Список кодов ошибок.
/// </summary>
public static class VkErrorCode
{
	/// <summary>
	/// Произошла неизвестная ошибка.
	/// Попробуйте повторить запрос позже.
	/// </summary>
	public const int Unknown = 1;

	/// <summary>
	/// Приложение выключено.
	/// Необходимо включить приложение в настройках https://vk.com/editapp?id={Ваш
	/// API_ID} или использовать тестовый режим
	/// (test_mode=1)
	/// </summary>
	public const int AppOff = 2;

	/// <summary>
	/// Передан неизвестный метод.
	/// Проверьте, правильно ли указано название вызываемого метода:
	/// http://vk.com/dev/methods.
	/// </summary>
	public const int UnknownMethod = 3;

	/// <summary>
	/// Неверная подпись.
	/// Проверьте правильность формирования подписи запроса:
	/// https://vk.com/dev/api_nohttps
	/// </summary>
	public const int InvalidSignature = 4;

	/// <summary>
	/// Авторизация пользователя не удалась.
	/// Убедитесь, что Вы используете верную схему авторизации. Для работы с методами
	/// без префикса secure Вам нужно
	/// авторизовать пользователя одним из этих способов: http://vk.com/dev/auth_sites,
	/// http://vk.com/dev/auth_mobile.
	/// </summary>
	public const int AuthorizationFailed = 5;

	/// <summary>
	/// Слишком много запросов в секунду.
	/// Задайте больший интервал между вызовами или используйте метод execute.
	/// Подробнее об ограничениях на частоту вызовов
	/// см. на странице http://vk.com/dev/api_requests.
	/// </summary>
	public const int TooManyRequestsPerSecond = 6;

	/// <summary>
	/// Нет прав для выполнения этого действия.
	/// Проверьте, получены ли нужные права доступа при авторизации. Это можно сделать
	/// с помощью метода
	/// account.getAppPermissions.
	/// </summary>
	public const int PermissionToPerformThisAction = 7;

	/// <summary>
	/// Неверный запрос.
	/// Проверьте синтаксис запроса и список используемых параметров (его можно найти
	/// на странице с описанием метода).
	/// </summary>
	public const int InvalidRequest = 8;

	/// <summary>
	/// Слишком много однотипных действий.
	/// Нужно сократить число однотипных обращений. Для более эффективной работы Вы
	/// можете использовать execute или JSONP.
	/// </summary>
	public const int TooMuchOfTheSameTypeOfAction = 9;

	/// <summary>
	/// Произошла внутренняя ошибка сервера.
	/// Попробуйте повторить запрос позже.
	/// </summary>
	public const int PublicServerError = 10;

	/// <summary>
	/// В тестовом режиме приложение должно быть выключено или пользователь должен быть
	/// залогинен.
	/// Выключите приложение в настройках https://vk.com/editapp?id={Ваш API_ID}
	/// </summary>
	public const int OffAppOrLogin = 11;

	/// <summary>
	/// Невозможно скомпилировать код.
	/// Проверьте код на ошибки.
	/// </summary>
	public const int ImpossibleToCompileCode = 12;

	/// <summary>
	/// Ошибка выполнения кода.
	/// Дополнительные сведения будут содержаться в сообщении об ошибке.
	/// </summary>
	public const int ErrorExecutingCode = 13;

	/// <summary>
	/// Требуется ввод кода с картинки (Captcha).
	/// Процесс обработки этой ошибки подробно описан на отдельной странице.
	/// </summary>
	public const int CaptchaNeeded = 14;

	/// <summary>
	/// Доступ запрещён.
	/// Убедитесь, что Вы используете верные идентификаторы, и доступ к контенту для
	/// текущего пользователя есть в полной
	/// версии сайта.
	/// </summary>
	public const int AccessDenied = 15;

	/// <summary>
	/// Требуется выполнение запросов по протоколу HTTPS, т.к. пользователь включил
	/// настройку, требующую работу через
	/// безопасное соединение.
	/// Чтобы избежать появления такой ошибки, в Standalone-приложении Вы можете
	/// предварительно проверять состояние этой
	/// настройки у пользователя методом account.getInfo.
	/// </summary>
	public const int NeedHttps = 16;

	/// <summary>
	/// Требуется валидация пользователя.
	/// Действие требует подтверждения — необходимо перенаправить пользователя на
	/// служебную страницу для валидации.
	/// </summary>
	public const int NeedValidationOfUser = 17;

	/// <summary>
	/// Пользователь не найден, удален или заблокирован
	/// </summary>
	public const int UserDeletedOrBanned = 18;

	/// <summary>
	/// Контент недоступен.
	/// </summary>
	public const int ContentDenied = 19;

	/// <summary>
	/// Данное действие запрещено для не Standalone приложений.
	/// Если ошибка возникает несмотря на то, что Ваше приложение имеет тип Standalone,
	/// убедитесь, что при авторизации Вы
	/// используете redirect_uri=https://oauth.vk.com/blank.html. Подробнее см.
	/// http://vk.com/dev/auth_mobile.
	/// </summary>
	public const int NonStandaloneApplications = 20;

	/// <summary>
	/// Данное действие разрешено только для Standalone и Open API приложений.
	/// </summary>
	public const int OnlyStandaloneOrOpenApi = 21;

	/// <summary>
	/// Ошибка загрузки документа.
	/// </summary>
	public const int LoadingError = 22;

	/// <summary>
	/// Метод был выключен.
	/// Все актуальные методы ВК API, которые доступны в настоящий момент, перечислены
	/// здесь: http://vk.com/dev/methods.
	/// </summary>
	public const int MethodHasBeenSwitchedOff = 23;

	/// <summary>
	/// Требуется подтверждение со стороны пользователя.
	/// </summary>
	public const int ConfirmationUser = 24;

	/// <summary>
	/// Ключ доступа сообщества недействителен.
	/// </summary>
	public const int GroupKeyInvalid = 27;

	/// <summary>
	/// Ключ доступа приложения недействителен.
	/// </summary>
	public const int AppKeyInvalid = 28;

	/// <summary>
	/// Достигнут количественный лимит на вызов метода
	/// </summary>
	public const int RateLimitReached = 29;

	/// <summary>
	/// Один из необходимых параметров был не передан или неверен.
	/// Проверьте список требуемых параметров и их формат на странице с описанием
	/// метода.
	/// </summary>
	public const int ParameterMissingOrInvalid = 100;

	/// <summary>
	/// Неверный API ID приложения.
	/// Найдите приложение в списке администрируемых на странице
	/// http://vk.com/apps?act=settings и укажите в запросе верный
	/// API_ID (идентификатор приложения).
	/// </summary>
	public const int InvalidAppId = 101;

	/// <summary>
	/// Выход за пределы.
	/// </summary>
	public const int OutOfLimits = 103;

	/// <summary>
	/// Неверный идентификатор пользователя.
	/// Убедитесь, что Вы используете верный идентификатор. Получить ID по короткому
	/// имени можно методом
	/// utils.resolveScreenName.
	/// </summary>
	public const int InvalidUserId = 113;

	/// <summary>
	/// Недопустимый сервер загрузки.
	/// </summary>
	public const int InvalidServer = 118;

	/// <summary>
	/// Неверный параметр.
	/// </summary>
	public const int InvalidParameter = 120;

	/// <summary>
	/// Неверный хэш.
	/// </summary>
	public const int InvalidHash = 121;

	/// <summary>
	/// Неверный идентификатор сообщества.
	/// </summary>
	public const int InvalidGroupId = 125;

	/// <summary>
	/// Доступ к меню запрещен.
	/// </summary>
	public const int AccessToMenuDenied = 148;

	/// <summary>
	/// Неверный timestamp.
	/// Получить актуальное значение Вы можете методом utils.getServerTime.
	/// </summary>
	public const int InvalidTimestamp = 150;

	/// <summary>
	/// Доступ к пользователю запрещён.
	/// </summary>
	public const int UserAccessDenied = 170;

	/// <summary>
	/// Недопустимый идентификатор списка.
	/// </summary>
	public const int ListIdInvalid = 171;

	/// <summary>
	/// Создано максимальное количество списков.
	/// </summary>
	public const int ListAmountMaximum = 173;

	/// <summary>
	/// Невозможно добавить в друзья самого себя.
	/// </summary>
	public const int CannotAddYourself = 174;

	/// <summary>
	/// Невозможно добавить в друзья пользователя, который занес Вас в свой черный
	/// список.
	/// </summary>
	public const int CannotAddYouBlacklisted = 175;

	/// <summary>
	/// Невозможно добавить в друзья пользователя, который занесен в Ваш черный список.
	/// </summary>
	public const int CannotAddUserBlacklisted = 176;

	/// <summary>
	/// Невозможно добавить в друзья пользователя, т.к. он не найден.
	/// </summary>
	public const int CannotAddUserNotFound = 177;

	/// <summary>
	/// Доступ к альбому запрещён.
	/// Убедитесь, что Вы используете верные идентификаторы (для пользователей owner_id
	/// положительный, для сообществ —
	/// отрицательный), и доступ к запрашиваемому контенту для текущего пользователя
	/// есть в полной версии сайта.
	/// </summary>
	public const int AlbumAccessDenied = 200;

	/// <summary>
	/// Доступ к аудио запрещён.
	/// Убедитесь, что Вы используете верные идентификаторы (для пользователей owner_id
	/// положительный, для сообществ —
	/// отрицательный), и доступ к запрашиваемому контенту для текущего пользователя
	/// есть в полной версии сайта.
	/// </summary>
	public const int AudioAccessDenied = 201;

	/// <summary>
	/// Доступ к группе запрещён.
	/// Убедитесь, что текущий пользователь является участником или руководителем
	/// сообщества (для закрытых и частных групп
	/// и встреч).
	/// </summary>
	public const int GroupAccessDenied = 203;

	/// <summary>
	/// Нет доступа к видео.
	/// </summary>
	public const int VideoAccessDenied = 204;

	/// <summary>
	/// Нет доступа к записи.
	/// </summary>
	public const int PostAccessDenied = 210;

	/// <summary>
	/// Нет доступа к комментариям на этой стене.
	/// </summary>
	public const int CommentsWallAccessDenied = 211;

	/// <summary>
	/// Нет доступа к комментариям записи.
	/// </summary>
	public const int CommentsPostAccessDenied = 212;

	/// <summary>
	/// Нет доступа к комментированию записи
	/// </summary>
	public const int AccessToCommentDenied = 213;

	/// <summary>
	/// Публикация запрещена. Превышен лимит на число публикаций в сутки, либо на
	/// указанное время уже запланирована другая
	/// запись, либо для текущего пользователя недоступно размещение записи на этой
	/// стене.
	/// </summary>
	public const int AccessToAddingPostDenied = 214;

	/// <summary>
	/// Рекламный пост уже недавно публиковался.
	/// </summary>
	public const int AdsRecentlyPosted = 219;

	/// <summary>
	/// Доступ к статусу запрещён.
	/// </summary>
	public const int StatusAccessDenied = 220;

	/// <summary>
	/// Пользователь отключил вещание названия трека.
	/// </summary>
	public const int UserDisabledTrackNameBroadcast = 221;

	/// <summary>
	/// Запрещено размещать ссылки.
	/// </summary>
	public const int PostLinksDenied = 222;

	/// <summary>
	/// Превышен лимит комментариев на стене
	/// </summary>
	public const int CommentsLimitReached = 223;

	/// <summary>
	/// Превышен лимит комментариев на стене
	/// </summary>
	public const int TooManyAdsPosts = 224;

	/// <summary>
	/// Превышен лимит друзей
	/// </summary>
	public const int TooManyFriends = 242;

	/// <summary>
	/// Доступ к списку групп запрещен из-за настроек конфиденциальности пользователя.
	/// </summary>
	public const int GroupsListAccessDenied = 260;

	/// <summary>
	/// Альбом переполнен.
	/// Перед продолжением работы нужно удалить лишние объекты из альбома или
	/// использовать другой альбом.
	/// </summary>
	public const int AlbumIsFull = 300;

	/// <summary>
	/// Альбом видео переполнен.
	/// Перед продолжением работы нужно удалить лишние объекты из альбома или
	/// использовать другой альбом.
	/// </summary>
	public const int VideoAlbumIsFull = 302;

	/// <summary>
	/// Действие запрещено. Вы должны включить переводы голосов в настройках
	/// приложения.
	/// Проверьте настройки приложения: http://vk.com/editapp?id={Ваш API_ID}&amp;
	/// section=payments
	/// </summary>
	public const int PermissionDenied = 500;

	/// <summary>
	/// Нет прав на выполнение данных операций с рекламным кабинетом.
	/// </summary>
	public const int AdsAccessDenied = 600;

	/// <summary>
	/// Произошла ошибка при работе с рекламным кабинетом.
	/// </summary>
	public const int ErrorWorkWithAds = 603;

	/// <summary>
	/// Это видео уже добавлено.
	/// </summary>
	public const int VideoAlreadyAdded = 800;

	/// <summary>
	/// Комментарии к этому видео закрыты
	/// </summary>
	public const int VideoCommentsClosed = 801;

	/// <summary>
	/// Нельзя отправлять сообщение пользователю из черного списка.
	/// </summary>
	public const int CannotSendBlacklisted = 900;

	/// <summary>
	/// Нельзя первым писать пользователю от имени сообщества.
	/// </summary>
	public const int CannotSendToUserFirstly = 901;

	/// <summary>
	/// Нельзя отправлять сообщения этому пользователю в связи с настройками
	/// приватности.
	/// </summary>
	public const int CannotSendDuePrivacy = 902;

	/// <summary>
	/// Формат клавиатуры недействителен.
	/// </summary>
	public const int KeyboardFormatIsInvalid = 911;
	
	/// <summary>
	/// Это функция чат-бота, измените этот статус в настройках.
	/// </summary>
	public const int ThisIsAChatBotFeatureChangeThisStatusInSettings = 912;
	
	/// <summary>
	/// Слишком много пересланных сообщений.
	/// </summary>
	public const int TooMuchSentMessages = 913;

	/// <summary>
	/// Сообщение слишком длинное.
	/// </summary>
	public const int MessageIsTooLong = 914;

	/// <summary>
	/// Нет доступа к беседе
	/// </summary>
	public const int ConversationAccessDenied = 917;
	
	/// <summary>
	/// Нельзя переслать эти сообщения.
	/// </summary>
	public const int CannotForwardMessages = 921;
	
	/// <summary>
	/// Вы покинули этот чат.
	/// </summary>
	public const int YouLeftThisChat = 922;

	/// <summary>
	/// Вы не администратор в данном чате
	/// </summary>
	public const int YouAreNotAdminOfThisChat = 925;

	/// <summary>
	/// Пользователя нет в чате
	/// </summary>
	public const int UserNotFoundInChat = 935;

	/// <summary>
	/// Контакт не найден
	/// </summary>
	public const int ContactNotFound = 936;

	/// <summary>
	/// Слишком много постов в сообщениях
	/// </summary>
	public const int TooManyPostsInMessages = 940;

	/// <summary>
	/// Не удается использовать этот intent
	/// </summary>
	public const int CannotUseThisIntent = 943;

	/// <summary>
	/// Превышение лимитов для этого intent
	/// </summary>
	public const int LimitsOverflowForThisIntent = 944;

	/// <summary>
	/// Чат был отключен
	/// </summary>
	public const int ChatWasDisabled = 945;

	/// <summary>
	/// Чат не поддерживается
	/// </summary>
	public const int ChatNotSupported = 946;
	
	/// <summary>
	/// Не удается отправить сообщение, время ответа истекло
	/// </summary>
	public const int CannotSendMessageReplyTimedOut = 950;
	
	/// <summary>
	/// Вы не можете получить доступ к донат чату без подписки
	/// </summary>
	public const int YouСanеAccessDonutChatWithoutSubscription = 962;

	/// <summary>
	/// Сообщение не может быть переслано
	/// </summary>
	public const int MessageCannotBeForwarded = 969;

	/// <summary>
	/// Действие приложения ограничено для бесед с сообществами
	/// </summary>
	public const int AppActionIsRestrictedForConversationsWithCommunities = 979;
	
	/// <summary>
	/// Вам запрещено писать в чат
	/// </summary>
	public const int YouAreRestrictedToWriteToAChat = 983;
	
	/// <summary>
	/// У вас есть ограничение на отправку из-за спама
	/// </summary>
	public const int YouHasSpamRestriction = 984;
	
	/// <summary>
	/// Невозможно писать в группы только с уведомлениями
	/// </summary>
	public const int CannotWriteToNotificationsOnlyGroups = 985;
	
	/// <summary>
	/// Требуется роль edu
	/// </summary>
	public const int NeedEduRole = 986;
	
	/// <summary>
	/// Требуется запрос сообщения
	/// </summary>
	public const int NeedMessageRequest = 987;
	
	/// <summary>
	/// Запрос сообщения ожидает подтверждения
	/// </summary>
	public const int PendingMessageRequest = 988;
	
	/// <summary>
	/// Отложенные сообщения для этого peer не поддерживаются
	/// </summary>
	public const int DelayedMessagesForThisPeerNotSupported = 991;
	
	/// <summary>
	/// Достигнут лимит отложенных сообщений для этого peerId
	/// </summary>
	public const int DelayedMessagesLimitForThisPeerIdReached = 992;
	
	/// <summary>
	/// Написание сообщений в этом чате отключено
	/// </summary>
	public const int WritingIsDisabledForThisChat = 1012;
	
	/// <summary>
	/// Неверный тип аккаунта — не должен быть edu
	/// </summary>
	public const int InvalidAccountTypeShouldNotBeEdu = 1016;

	/// <summary>
	/// Неверный файл
	/// </summary>
	public const int InvalidFile = 4611;
}
