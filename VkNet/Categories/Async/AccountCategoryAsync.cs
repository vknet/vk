using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	public partial class AccountCategory
	{
		/// <summary>
		/// Возвращает ненулевые значения счетчиков пользователя.
		/// </summary>
		/// <param name="filter">
		/// Счетчики, информацию о которых нужно вернуть Async(friends, messages, photos,
		/// videos, notes, gifts, events, groups,
		/// notifications, sdk, app_requests).
		/// sdk - возвращает количество запросов в приложениях.
		/// app_requests - возвращает количество непрочитанных запросов в приложениях.
		/// список слов, разделенных через запятую
		/// Async(Список слов, разделенных через запятую).
		/// </param>
		/// <returns>
		/// Возвращает объект, который может содержать поля friends, messages, photos,
		/// videos, notes, gifts, events, groups,
		/// notifications, sdk, app_requests.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.getCounters
		/// </remarks>
		public async Task<Counters> GetCountersAsync(CountersFilter filter)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.GetCounters(filter: filter));
		}

		/// <summary>
		/// Устанавливает короткое название приложения Async(до 17 символов), которое
		/// выводится пользователю в левом меню.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя. положительное число, по умолчанию идентификатор
		/// текущего пользователя,
		/// обязательный параметр Async(Положительное число, по умолчанию идентификатор
		/// текущего пользователя, обязательный
		/// параметр).
		/// </param>
		/// <param name="name"> Короткое название приложения. строка Async(Строка). </param>
		/// <returns>
		/// Возвращает 1 в случае успешной установки короткого названия.
		/// Если пользователь не установил приложение в левое меню, метод вернет ошибку 148
		/// Async(Access to the menu of the
		/// user denied). Избежать этой ошибки можно с помощью метода
		/// account.getAppPermissions.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.setNameInMenu
		/// </remarks>
		public async Task<bool> SetNameInMenuAsync(string name, long? userId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.SetNameInMenu(name: name, userId: userId));
		}

		/// <summary>
		/// Помечает текущего пользователя как online на 15 минут.
		/// </summary>
		/// <param name="voip">
		/// Возможны ли видеозвонки для данного устройства флаг, может принимать значения 1
		/// или 0 Async(Флаг,
		/// может принимать значения 1 или 0).
		/// </param>
		/// <returns>
		/// В случае успешного выполнения метода будет возвращён код 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.setOnline
		/// </remarks>
		public async Task<bool> SetOnlineAsync(bool? voip = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.SetOnline(voip: voip));
		}

		/// <summary>
		/// Помечает текущего пользователя как offline.
		/// </summary>
		/// <returns>
		/// В случае успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.setOffline
		/// </remarks>
		public async Task<bool> SetOfflineAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.SetOffline());
		}

		/// <summary>
		/// Подписывает устройство на базе iOS, Android или Windows Phone на получение
		/// Push-уведомлений.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// Возвращает 1 в случае успешного выполнения метода.
		/// На iOS и Windows Phone push-уведомления будут отображены без какой либо
		/// обработки.
		/// На Android будут приходить события в следующем формате.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.registerDevice
		/// </remarks>
		public async Task<bool> RegisterDeviceAsync(AccountRegisterDeviceParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.RegisterDevice(@params: @params));
		}

		/// <summary>
		/// Отписывает устройство от Push уведомлений.
		/// </summary>
		/// <param name="deviceId">
		/// Уникальный идентификатор устройства. строка, доступен начиная с версии 5.31
		/// Async(Строка,
		/// доступен начиная с версии 5.31).
		/// </param>
		/// <param name="sandbox">
		/// Флаг предназначен для iOS устройств. 1 — отписать устройство, использующего
		/// sandbox сервер для
		/// отправки push-уведомлений, 0 — отписать устройство, не использующее sandbox
		/// сервер флаг, может принимать значения 1
		/// или 0, по умолчанию 0 Async(Флаг, может принимать значения 1 или 0, по
		/// умолчанию 0).
		/// </param>
		/// <returns>
		/// Возвращает <c> true </c> в случае успешного выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.unregisterDevice
		/// </remarks>
		public async Task<bool> UnregisterDeviceAsync(string deviceId, bool? sandbox = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.UnregisterDevice(deviceId: deviceId, sandbox: sandbox));
		}

		/// <summary>
		/// Отключает push-уведомления на заданный промежуток времени.
		/// </summary>
		/// <param name="deviceId"> Идентификатор устройства для сервиса push уведомлений. </param>
		/// <param name="time">
		/// Время в секундах на которое требуется отключить уведомления. Async(-1 -
		/// отключить навсегда)
		/// </param>
		/// <param name="peerId">
		/// Идентификатор чата, для которого следует отключить
		/// уведомления.
		/// </param>
		/// <param name="sound">
		/// 1 - включить звук в данном диалоге, 0 - отключить звук Async(параметр работает
		/// только если указан в
		/// peer_id передан идентификатор групповой беседы или пользователя)
		/// </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.setSilenceMode
		/// </remarks>
		public async Task<bool> SetSilenceModeAsync(string deviceId, int? time = null, int? peerId = null, bool? sound = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Account.SetSilenceMode(deviceId: deviceId, time: time, peerId: peerId, sound: sound));
		}

		/// <summary>
		/// Позволяет получать настройки Push уведомлений.
		/// </summary>
		/// <param name="deviceId">
		/// Уникальный идентификатор устройства. строка, доступен начиная с версии 5.31
		/// Async(Строка,
		/// доступен начиная с версии 5.31).
		/// </param>
		/// <returns>
		/// Возвращает объект, содержащий поля:
		/// disabled — отключены ли уведомления.
		/// disabled_until — unixtime-значение времени, до которого временно отключены
		/// уведомления.
		/// conversations — список, содержащий настройки конкретных диалогов, и их
		/// количество первым элементом.
		/// settings — объект с настройками Push-уведомлений в специальном формате.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.getPushSettings
		/// </remarks>
		public async Task<AccountPushSettings> GetPushSettingsAsync(string deviceId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.GetPushSettings(deviceId: deviceId));
		}

		/// <summary>
		/// Изменяет настройку Push-уведомлений.
		/// </summary>
		/// <param name="deviceId">
		/// Уникальный идентификатор устройства. строка, обязательный параметр
		/// Async(Строка, обязательный
		/// параметр).
		/// </param>
		/// <param name="settings">
		/// Сериализованный JSON-объект, описывающий настройки уведомлений в специальном
		/// формате данные в
		/// формате JSON Async(Данные в формате JSON).
		/// </param>
		/// <param name="key"> Ключ уведомления. строка Async(Строка). </param>
		/// <param name="value">
		/// Новое значение уведомления в специальном формате. список слов, разделенных
		/// через запятую
		/// Async(Список слов, разделенных через запятую).
		/// </param>
		/// <returns>
		/// Возвращает 1 в случае успешного выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.setPushSettings
		/// </remarks>
		public async Task<bool> SetPushSettingsAsync(string deviceId, PushSettings settings, string key, List<string> value)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Account.SetPushSettings(deviceId: deviceId, settings: settings, key: key, value: value));
		}

		/// <summary>
		/// Получает настройки текущего пользователя в данном приложении.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, информацию о настройках которого необходимо
		/// получить. По умолчанию —
		/// текущий пользователь. положительное число, по умолчанию идентификатор текущего
		/// пользователя, обязательный параметр
		/// Async(Положительное число, по умолчанию идентификатор текущего пользователя,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает битовую маску настроек текущего
		/// пользователя в данном приложении.
		/// Пример Если Вы хотите получить права на Доступ к друзьям и Доступ к статусам
		/// пользователя, то Ваша битовая маска
		/// будет равна: 2   1024 = 1026.
		/// Если, имея битовую маску 1026, Вы хотите проверить, имеет ли она доступ к
		/// друзьям — Вы можете сделать 1026 &amp; 2.
		/// Например alertAsync(1026 &amp; 2);
		/// см. Список возможных настроек прав доступа.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.getAppPermissions
		/// </remarks>
		public async Task<long> GetAppPermissionsAsync(long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.GetAppPermissions(userId: userId));
		}

		/// <summary>
		/// Возвращает список активных рекламных предложений Async(офферов), выполнив
		/// которые пользователь сможет получить
		/// соответствующее количество голосов на свой счёт внутри приложения.
		/// </summary>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества офферов.
		/// положительное число, по
		/// умолчанию 0 Async(Положительное число, по умолчанию 0).
		/// </param>
		/// <param name="count">
		/// Количество офферов, которое необходимо получить положительное число, по
		/// умолчанию 100, максимальное
		/// значение 100 Async(Положительное число, по умолчанию 100, максимальное значение
		/// 100).
		/// </param>
		/// <returns>
		/// Возвращает массив, состоящий из общего количества старгетированных на текущего
		/// пользователя специальных предложений
		/// Async(первый элемент), и списка объектов с информацией о предложениях.
		/// В случае, если на пользователя не старгетировано ни одного специального
		/// предложения, массив будет содержать элемент
		/// 0 Async(количество специальных предложений).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.getActiveOffers
		/// </remarks>
		public async Task<InformationAboutOffers> GetActiveOffersAsync(ulong? offset = null, ulong? count = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.GetActiveOffers(offset: offset, count: count));
		}

		/// <summary>
		/// Добавляет пользователя в черный список.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, которого нужно добавить в черный список.
		/// положительное число,
		/// обязательный параметр Async(Положительное число, обязательный параметр).
		/// </param>
		/// <returns>
		/// В случае успеха метод вернет <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.banUser
		/// </remarks>
		public async Task<bool> BanUserAsync(long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.BanUser(userId: userId));
		}

		/// <summary>
		/// Убирает пользователя из черного списка.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, которого нужно убрать из черного списка.
		/// положительное число,
		/// обязательный параметр Async(Положительное число, обязательный параметр).
		/// </param>
		/// <returns>
		/// В случае успеха метод вернет <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.unbanUser
		/// </remarks>
		public async Task<bool> UnbanUserAsync(long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.UnbanUser(userId: userId));
		}

		/// <summary>
		/// Возвращает список пользователей, находящихся в черном списке.
		/// </summary>
		/// <param name="offset">
		/// Смещение необходимое для выборки определенного подмножества черного списка.
		/// положительное число
		/// Async(Положительное число).
		/// </param>
		/// <param name="count">
		/// Количество записей, которое необходимо вернуть. положительное число, по
		/// умолчанию 20, максимальное
		/// значение 200 Async(Положительное число, по умолчанию 20, максимальное значение
		/// 200).
		/// </param>
		/// <returns>
		/// Возвращает набор объектов пользователей, находящихся в черном списке.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.getBanned
		/// </remarks>
		public async Task<VkCollection<User>> GetBannedAsync(int? offset = null, int? count = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.GetBanned(offset: offset, count: count));
		}

		/// <summary>
		/// Возвращает информацию о текущем аккаунте.
		/// </summary>
		/// <param name="fields">
		/// Список полей, которые необходимо вернуть. Возможные значения: Async(country,
		/// http_required,
		/// own_posts_default, no_wall_replies, intro, lang, По умолчанию будут возвращены
		/// все поля. список слов, разделенных
		/// через запятую Async(Список слов, разделенных через запятую).
		/// </param>
		/// <returns>
		/// Метод возвращает объект, содержащий следующие поля:
		/// country – строковой код страны, определенный по IP адресу, с которого сделан
		/// запрос;
		/// https_required – 1 - пользователь установил на сайте настройку "Всегда
		/// использовать безопасное соединение"; 0 -
		/// безопасное соединение не требуется;
		/// own_posts_default – 1 - на стене пользователя по-умолчанию должны отображаться
		/// только собственные записи.
		/// Соответствует настройке на сайте "Показывать только мои записи", 0 - на стене
		/// пользователя должны отображаться все
		/// записи;
		/// no_wall_replies – 1 - пользователь отключил комментирование записей на стене, 0
		/// - комментирование записей
		/// разрешено;
		/// intro – битовая маска отвечающая за прохождение обучения использованию
		/// приложения;
		/// lang – числовой идентификатор текущего языка пользователя.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.getInfo
		/// </remarks>
		public async Task<AccountInfo> GetInfoAsync(AccountFields fields = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.GetInfo(fields: fields));
		}

		/// <summary>
		/// Позволяет редактировать информацию о текущем аккаунте.
		/// </summary>
		/// <param name="name"> Имя настройки. </param>
		/// <param name="value"> Значение настройки. </param>
		/// <returns>
		/// В результате успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.setInfo
		/// </remarks>
		public async Task<bool> SetInfoAsync(string name, string value)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.SetInfo(name: name, value: value));
		}

		/// <summary>
		/// Позволяет сменить пароль пользователя после успешного восстановления доступа к
		/// аккаунту через СМС, используя метод
		/// auth.restore.
		/// </summary>
		/// <param name="restoreSid">
		/// Идентификатор сессии, полученный при восстановлении доступа используя метод
		/// auth.restore.
		/// Async(В случае если пароль меняется сразу после восстановления доступа) строка
		/// Async(Строка).
		/// </param>
		/// <param name="changePasswordHash">
		/// Хэш, полученный при успешной OAuth авторизации по коду полученному по СМС
		/// Async(В
		/// случае если пароль меняется сразу после восстановления доступа) строка
		/// Async(Строка).
		/// </param>
		/// <param name="oldPassword"> Текущий пароль пользователя. строка Async(Строка). </param>
		/// <param name="newPassword">
		/// Новый пароль, который будет установлен в качестве текущего. строка, минимальная
		/// длина 6,
		/// обязательный параметр Async(Строка, минимальная длина 6, обязательный
		/// параметр).
		/// </param>
		/// <returns>
		/// В результате выполнения этого метода будет возвращен объект с полем token,
		/// содержащим новый токен, и полем secret в
		/// случае, если токен был nohttps.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.changePassword
		/// </remarks>
		public async Task<AccountChangePasswordResult> ChangePasswordAsync(string oldPassword
																			, string newPassword
																			, string restoreSid = null
																			, string changePasswordHash = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.ChangePassword(oldPassword: oldPassword
					, newPassword: newPassword
					, restoreSid: restoreSid
					, changePasswordHash: changePasswordHash));
		}

		/// <summary>
		/// Возвращает информацию о текущем профиле.
		/// </summary>
		/// <returns> Информация о текущем профиле в виде Model.User </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.getProfileInfo
		/// </remarks>
		public async Task<AccountSaveProfileInfoParams> GetProfileInfoAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.GetProfileInfo());
		}

		/// <summary>
		/// Редактирует информацию текущего профиля.
		/// </summary>
		/// <param name="cancelRequestId">
		/// Идентификатор заявки на смену имени, которую
		/// необходимо отменить.
		/// </param>
		/// <returns> Результат отмены заявки. </returns>
		/// <remarks>
		/// Метод вынесен как отдельный, потому что если в запросе передан параметр
		/// <paramref name="cancelRequestId" />,
		/// все остальные параметры игнорируются.
		/// </remarks>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.saveProfileInfo
		/// </remarks>
		public async Task<bool> SaveProfileInfoAsync(int cancelRequestId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Account.SaveProfileInfo(cancelRequestId: cancelRequestId));
		}

		/// <summary>
		/// Редактирует информацию текущего профиля.
		/// </summary>
		/// <param name="params"> The parameters. </param>
		/// <returns>
		/// Результат отмены заявки.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/account.saveProfileInfo
		/// </remarks>
		public async Task<bool> SaveProfileInfoAsync(AccountSaveProfileInfoParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Account.SaveProfileInfo(changeNameRequest: out var _, @params: @params));
		}
	}
}