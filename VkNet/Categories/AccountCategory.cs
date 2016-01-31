using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Categories
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Text.RegularExpressions;
	using JetBrains.Annotations;
	using Newtonsoft.Json.Linq;

	using Enums;
	using Model;
    using Model.RequestParams;
	using Utils;

	/// <summary>
	/// Методы этого класса позволяют производить действия с аккаунтом пользователя.
	/// </summary>
	public class AccountCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с аккаунтом пользователя.
		/// </summary>
		/// <param name="vk">API.</param>
		internal AccountCategory(VkApi vk)
		{
			_vk = vk;
		}


		/// <summary>
		/// Возвращает ненулевые значения счетчиков пользователя.
		/// </summary>
		/// <param name="filter">Счетчики, информацию о которых нужно вернуть.</param>
		/// <returns>Возвращает объект, который содержит ненулевые значения счетчиков, или null, если все значения нулевые. Равные нулю счетчики не устанавливаются независимо от их наличия в <paramref name="filter"/>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.getCounters" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.40")]
		public Counters GetCounters(CountersFilter filter)
		{
			return _vk.Call("account.getCounters", new VkParameters { { "filter", filter } });
		}


		/// <summary>
		/// Устанавливает короткое название приложения (до 17 символов), которое выводится пользователю в левом меню.
		/// Это происходит только в том случае, если пользователь добавил приложение в левое меню со страницы приложения, списка приложений или настроек.
		/// </summary>
		/// <param name="name">Короткое название приложения (до 17 символов).</param>
		/// <param name="userId">Идентификатор пользователя, по умолчанию идентификатор текущего пользователя.</param>
		/// <returns>
		/// Возвращает результат установки короткого названия.
		/// </returns>
		/// <remarks>
		/// Если пользователь не установил приложение в левое меню, метод вернет ошибку 148 (Access to the menu of the user denied).
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.setNameInMenu" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool SetNameInMenu([NotNull] string name, long? userId = null)
		{
			VkErrors.ThrowIfNullOrEmpty(() => name);
			var parameters = new VkParameters
			{
				{ "name", name },
				{ "user_id", userId}
			};
			return _vk.Call("account.setNameInMenu", parameters);
		}

		/// <summary>
		/// Помечает текущего пользователя как online на 15 минут.
		/// </summary>
		/// <param name="voip">Возможны ли видеозвонки для данного устройства.</param>
		/// <returns>
		/// Возвращает значение, показывающее, успешно ли выполнился метод.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.setOnline" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool SetOnline(bool? voip = null)
		{
			var parameters = new VkParameters { { "voip", voip } };
			return _vk.Call("account.setOnline", parameters);
		}

		/// <summary>
		/// Помечает текущего пользователя как offline.
		/// </summary>
		/// <returns>Возвращает значение, показывающее, успешно ли выполнился метод.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.setOffline" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool SetOffline()
		{
			return _vk.Call("account.setOffline", VkParameters.Empty);
		}

		/// <summary>
		/// Позволяет искать пользователей ВКонтакте, используя телефонные номера, email-адреса, и идентификаторы пользователей в других сервисах.
		/// Найденные пользователи могут быть также в дальнейшем получены методом friends.getSuggestions.
		/// </summary>
		/// <param name="contacts">Список контактов, разделенных через запятую. список строк, разделенных через запятую.</param>
		/// <param name="service">Строковой идентификатор сервиса, по контактам которого производится поиск. строка, обязательный параметр.</param>
		/// <param name="mycontact">Контакт текущего пользователя в заданном сервисе. строка.</param>
		/// <param name="returnAll">1 – возвращать также контакты, найденные ранее с использованием этого сервиса, 0 – возвращать только контакты, найденные с использованием поля contacts. флаг, может принимать значения 1 или 0.</param>
		/// <param name="fields">Список дополнительных полей, которые необходимо вернуть. список строк, разделенных через запятую.</param>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.lookupContacts" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public LookupContactsResult LookupContacts(List<string> contacts, Services service, string mycontact, bool? returnAll, UsersFields fields)
		{
			var parameters = new VkParameters
			{
				{ "contacts", contacts },
				{ "service", service },
				{ "mycontact", mycontact },
				{ "return_all", returnAll },
				{ "fields", fields }
			};
			return _vk.Call("account.lookupContacts", parameters);
		}

		/// <summary>
		/// Подписывает устройство на базе iOS, Android или Windows Phone на получение Push-уведомлений.
		/// </summary>
		/// <param name="token">Идентификатор устройства, используемый для отправки уведомлений. (для mpns идентификатор должен представлять из себя URL для отправки уведомлений)</param>
		/// <param name="deviceModel">Строковое название модели устройства.</param>
		/// <param name="systemVersion">Строковая версия операционной системы устройства.</param>
		/// <param name="noText">Не передавать текст сообщения в push уведомлении. (по умолчанию текст передается)</param>
		/// <param name="subscribe">Список типов уведомлений, которые следует присылать. По умолчанию присылаются: <see cref="SubscribeFilter.Message"/>, <see cref="SubscribeFilter.Friend"/>.</param>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.registerDevice" />.
		/// </remarks>
		[ApiVersion("5.21")]
		[Obsolete("Функция устарела. Пожалуйста используйте функцию RegisterDevice(AccountRegisterDevice @params)")]
		public bool RegisterDevice([NotNull]string token, string deviceModel, string systemVersion, bool? noText = null, SubscribeFilter subscribe = null)
		{
			VkErrors.ThrowIfNullOrEmpty(() => token);

			var parameters = new VkParameters
							{
								{"token", token},
								{"device_model", deviceModel},
								{"system_version", systemVersion},
								{"no_text", noText},
								{"subscribe", subscribe}
							};

			return _vk.Call("account.registerDevice", parameters);
		}
		/// <summary>
		/// Подписывает устройство на базе iOS, Android или Windows Phone на получение Push-уведомлений.
		/// </summary>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.registerDevice" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool RegisterDevice(AccountRegisterDeviceParams @params)
		{
			VkErrors.ThrowIfNullOrEmpty(() => @params.Token);

			var parameters = new VkParameters
			{
				{ "token", @params.Token },
				{ "device_model", @params.DeviceModel },
				{ "device_year", @params.DeviceYear },
				{ "device_id", @params.DeviceId },
				{ "system_version", @params.SystemVersion },
				{ "settings", @params.Settings },
				{ "sandbox", @params.Sandbox }
			};

			return _vk.Call("account.registerDevice", parameters);
		}

		/// <summary>
		/// Отписывает устройство от Push уведомлений.
		/// </summary>
		/// <param name="deviceId">Уникальный идентификатор устройства.</param>
		/// <param name="sandbox">Флаг предназначен для iOS устройств. 1 — отписать устройство, использующего sandbox сервер для отправки push-уведомлений, 0 — отписать устройство, не использующее sandbox сервер.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.unregisterDevice" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool UnregisterDevice(string deviceId, bool? sandbox = null)
		{
			VkErrors.ThrowIfNullOrEmpty(() => deviceId);

			var parameters = new VkParameters
			{
				{ "device_id", deviceId },
				{ "sandbox", sandbox }
			};

			return _vk.Call("account.unregisterDevice", parameters);
		}


		/// <summary>
		/// Отключает push-уведомления на заданный промежуток времени.
		/// </summary>
		/// <param name="deviceId">Идентификатор устройства для сервиса push уведомлений.</param>
		/// <param name="time">Время в секундах на которое требуется отключить уведомления. (-1 - отключить навсегда)</param>
		/// <param name="chatId">Идентификатор чата, для которого следует отключить уведомления.</param>
		/// <param name="userId">Идентификатор пользователя, для которого следует отключить уведомления.</param>
		/// <param name="sound">Включить звук в данном диалоге. (параметр работает только если указан <paramref name="userId" /> или <paramref name="chatId" /> )</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.setSilenceMode" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool SetSilenceMode([NotNull] string deviceId, int? time = null, int? chatId = null, int? userId = null, bool? sound = null)
		{
			VkErrors.ThrowIfNullOrEmpty(() => deviceId);

			var parameters = new VkParameters
			{
				{ "device_id", deviceId },
				{ "time", time },
				{ "chat_id", chatId },
				{ "user_id", userId },
				{ "sound", sound }
			};

			return _vk.Call("account.setSilenceMode", parameters);
		}

		/// <summary>
		/// Позволяет получать настройки Push уведомлений.
		/// </summary>
		/// <param name="deviceId">Уникальный идентификатор устройства.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.getPushSettings" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public AccountPushSettings GetPushSettings(string deviceId)
		{
			var parameters = new VkParameters
			{
				{ "device_id", deviceId }
			};
			return _vk.Call("account.getPushSettings", parameters);
		}

		/// <summary>
		/// Изменяет настройку Push-уведомлений.
		/// </summary>
		/// <param name="deviceId">Уникальный идентификатор устройства.</param>
		/// <param name="settings">Сериализованный JSON-объект, описывающий настройки уведомлений в специальном формате.</param>
		/// <param name="key">Ключ уведомления.</param>
		/// <param name="value">Новое значение уведомления в специальном формате.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.setPushSettings" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool SetPushSettings(string deviceId, PushSettings settings, string key, List<string> value)
		{
			var parameters = new VkParameters
			{
				{ "device_id", deviceId },
				{ "settings", settings },
				{ "key", key },
				{ "value", value }
			};
			return _vk.Call("account.setPushSettings", parameters);
		}

		/// <summary>
		/// Получает настройки текущего пользователя в данном приложении.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя, информацию о настройках которого необходимо получить. По умолчанию — текущий пользователь.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.getAppPermissions" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public long GetAppPermissions(long userId)
		{
			var parameters = new VkParameters
			{
				{ "user_id", userId}
			};
			return _vk.Call("account.getAppPermissions", parameters);
		}

		/// <summary>
		/// Возвращает список активных рекламных предложений (офферов), выполнив которые пользователь сможет получить соответствующее количество голосов на свой счёт внутри приложения.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.getActiveOffers" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public InformationAboutOffers GetActiveOffers(ulong? offset = null, ulong? count = null)
		{
			var parameters = new VkParameters
			{
				{ "offset", offset },
				{ "count", count }
			};
			return _vk.Call("account.getActiveOffers", parameters);
		}

		/// <summary>
		/// Добавляет пользователя в черный список.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя, которого нужно добавить в черный список. (положительное число)</param>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>Если указанный пользователь является другом текущего пользователя или имеет от него входящую или исходящую заявку в друзья, то для добавления пользователя в черный список Ваше приложение должно иметь права: <see cref="Settings.Friends"/>.</remarks>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.banUser" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool BanUser(int userId)
		{
			if (userId <= 0)
			{
				throw new ArgumentException("User ID should be greater than 0.", "userId");
			}

			return _vk.Call("account.banUser", new VkParameters { { "user_id", userId } });
		}

		/// <summary>
		/// Убирает пользователя из черного списка.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя, которого нужно убрать из черного списка. (положительное число)</param>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.unbanUser" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool UnbanUser(int userId)
		{
			if (userId <= 0)
			{
				throw new ArgumentException("User ID should be greater than 0.", "userId");
			}
			return _vk.Call("account.unbanUser", new VkParameters { { "user_id", userId } });
		}


		/// <summary>
		/// Возвращает список пользователей, находящихся в черном списке.
		/// </summary>
		/// <param name="total">Возвращает общее количество находящихся в черном списке пользователей.</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества черного списка. (положительное число) </param>
		/// <param name="count">Количество записей, которое необходимо вернуть. (положительное число, по умолчанию - 20, максимальное значение - 200) </param>
		/// <returns>Возвращает набор объектов пользователей, находящихся в черном списке. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.getBanned" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.40")]
		public IEnumerable<User> GetBanned(out int total, int? offset = null, int? count = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => offset);
			VkErrors.ThrowIfNumberIsNegative(() => count);

			var parameters = new VkParameters
			{
				{ "offset", offset },
				{ "count", count }
			};
			var response = _vk.Call("account.getBanned", parameters);

			total = response["count"];

			return response["items"].ToListOf<User>(vkResponse => vkResponse);
		}

		/// <summary>
		/// Возвращает информацию о текущем аккаунте.
		/// </summary>
		/// <param name="fields">Список полей, которые необходимо вернуть. По умолчанию будут возвращены все поля.</param>
		/// <returns>
		/// Возвращает информацию об аккаунте или null, если сервер присылает пустой ответ.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.getInfo" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.40")]
		public AccountInfo GetInfo(AccountFields fields = null)
		{
			return _vk.Call("account.getInfo", new VkParameters { { "fields", fields } });
		}


		/// <summary>
		/// Позволяет редактировать информацию о текущем аккаунте.
		/// </summary>
		/// <param name="intro">Битовая маска, отвечающая за прохождение обучения в мобильных клиентах. (положительное число)</param>
		/// <param name="ownPostsDefault">1 – на стене пользователя по-умолчанию должны отображаться только собственные записи;
		/// 0 – на стене пользователя должны отображаться все записи.</param>
		/// <param name="noWallReplies">1 – отключить комментирование записей на стене;
		/// 0 – разрешить комментирование.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Если параметр <paramref name="intro" /> не установлен, он сбрасывается на 0.
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.setInfo" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool SetInfo(int? intro = null, bool ownPostsDefault = true, bool noWallReplies = true)
		{
			VkErrors.ThrowIfNumberIsNegative(() => intro);
			var parameters = new VkParameters
			{
				{ "intro", intro },
				{ "own_posts_default", ownPostsDefault },
				{ "no_wall_replies", noWallReplies }
			};
			return _vk.Call("account.setInfo", parameters);
		}

		/// <summary>
		/// Позволяет сменить пароль пользователя после успешного восстановления доступа к аккаунту через СМС, используя метод auth.restore.
		/// </summary>
		/// <param name="oldPassword">Текущий пароль пользователя.</param>
		/// <param name="newPassword">Новый пароль, который будет установлен в качестве текущего. </param>
		/// <param name="restoreSid">Идентификатор сессии, полученный при восстановлении доступа используя метод <see cref="AuthCategory.Restore"/>. (В случае если пароль меняется сразу после восстановления доступа) </param>
		/// <param name="changePasswordHash">Хэш, полученный при успешной OAuth авторизации по коду полученному по СМС (В случае если пароль меняется сразу после восстановления доступа).</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.сhangePassword" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool ChangePassword(string oldPassword, string newPassword, string restoreSid = null, string changePasswordHash = null)
		{
			var parameters = new VkParameters
			{
				{ "restore_sid", restoreSid },
				{ "change_password_hash", changePasswordHash },
				{ "old_password", oldPassword },
				{ "new_password", newPassword }
			};
			return _vk.Call("account.сhangePassword", parameters);
		}


		/// <summary>
		/// Возвращает информацию о текущем профиле.
		/// </summary>
		/// <returns>Информация о текущем профиле в виде <see cref="Model.User"/></returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.getProfileInfo" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.40")]
		public User GetProfileInfo()
		{
			return _vk.Call("account.getProfileInfo", VkParameters.Empty);
		}

		/// <summary>
		/// Редактирует информацию текущего профиля.
		/// </summary>
		/// <param name="cancelRequestId">Идентификатор заявки на смену имени, которую необходимо отменить.</param>
		/// <returns>Результат отмены заявки.</returns>
		/// <remarks>Метод вынесен как отдельный, потому что если в запросе передан параметр <paramref name="cancelRequestId"/>, все остальные параметры игнорируются.</remarks>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.saveProfileInfo" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool SaveProfileInfo(int cancelRequestId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => cancelRequestId);
			return _vk.Call("account.saveProfileInfo", new VkParameters { { "cancel_request_id", cancelRequestId } })["changed"]
			;
		}

		/// <summary>
		///  Редактирует информацию текущего профиля.
		/// </summary>
		/// <param name="firstName">Имя пользователя</param>
		/// <param name="lastName">Фамилия пользователя</param>
		/// <param name="maidenName">Девичья фамилия пользователя</param>
		/// <param name="sex">Пол пользователя</param>
		/// <param name="relation">Семейное положение пользователя</param>
		/// <param name="relationPartnerId">Идентификатор пользователя, с которым связано семейное положение</param>
		/// <param name="birthDate">Дата рождения пользователя</param>
		/// <param name="birthDateVisibility">Видимость даты рождения</param>
		/// <param name="homeTown">Родной город пользователя</param>
		/// <param name="countryId">Идентификатор страны пользователя</param>
		/// <param name="cityId">Идентификатор города пользователя</param>
		/// <returns>Результат выполнения операции.</returns>
		/// <remarks> Если передаются <paramref name="firstName"/> или <paramref name="lastName"/>, рекомендуется
		/// использовать перегрузку с соотвествующим out параметром типа <see cref="ChangeNameRequest"/> для получения объекта заявки на смену имени.</remarks>
		[ApiVersion("5.21")]
		[Obsolete("Данный метод устарел, пожалуйста используйте метод SaveProfileInfo(out ChangeNameRequest changeNameRequest, AccountSaveInfo @params)")]
		public bool SaveProfileInfo(string firstName = null, string lastName = null, string maidenName = null, Sex? sex = null,
			RelationType? relation = null, long? relationPartnerId = null, DateTime? birthDate = null, BirthdayVisibility? birthDateVisibility = null,
			string homeTown = null, long? countryId = null, long? cityId = null)
		{
			ChangeNameRequest request;
			var parameters = new AccountSaveInfoParams
			{
				FirstName = firstName,
				LastName = lastName,
				MaidenName = maidenName,
				Sex = sex.Value,
				Relation = relation.Value,
				RelationPartnerId = relationPartnerId,
				BirthDate = birthDate,
				BirthDateVisibility = birthDateVisibility.Value,
				HomeTown = homeTown,
				CountryId = countryId,
				CityId = cityId
			};
			return SaveProfileInfo(out request, parameters);
		}

		/// <summary>
		///  Редактирует информацию текущего профиля.
		/// </summary>
		/// <param name="changeNameRequest">Если в параметрах передавалось имя или фамилия пользователя,
		/// в этом параметре будет возвращен объект типа <see cref="ChangeNameRequest"/>, содержащий информацию о заявке на смену имени.</param>
		/// <param name="firstName">Имя пользователя</param>
		/// <param name="lastName">Фамилия пользователя</param>
		/// <param name="maidenName">Девичья фамилия пользователя</param>
		/// <param name="sex">Пол пользователя</param>
		/// <param name="relation">Семейное положение пользователя</param>
		/// <param name="relationPartnerId">Идентификатор пользователя, с которым связано семейное положение</param>
		/// <param name="birthDate">Дата рождения пользователя</param>
		/// <param name="birthDateVisibility">Видимость даты рождения</param>
		/// <param name="homeTown">Родной город пользователя</param>
		/// <param name="countryId">Идентификатор страны пользователя</param>
		/// <param name="cityId">Идентификатор города пользователя</param>
		/// <returns>Результат выполнения операции.</returns>
		[ApiVersion("5.21")]
		[Obsolete("Данный метод устарел, пожалуйста используйте метод SaveProfileInfo(out ChangeNameRequest changeNameRequest, AccountSaveInfo @params)")]
		public bool SaveProfileInfo(out ChangeNameRequest changeNameRequest, string firstName = null, string lastName = null, string maidenName = null, Sex? sex = null,
			RelationType? relation = null, long? relationPartnerId = null, DateTime? birthDate = null, BirthdayVisibility? birthDateVisibility = null,
			string homeTown = null, long? countryId = null, long? cityId = null)
		{
			var parameters = new AccountSaveInfoParams
			{
				FirstName = firstName,
				LastName = lastName,
				MaidenName = maidenName,
				Sex = sex.Value,
				Relation = relation.Value,
				RelationPartnerId = relationPartnerId,
				BirthDate = birthDate,
				BirthDateVisibility = birthDateVisibility.Value,
				HomeTown = homeTown,
				CountryId = countryId,
				CityId = cityId
			};

			return SaveProfileInfo(out changeNameRequest, parameters);

		}

		/// <summary>
		/// Редактирует информацию текущего профиля.
		/// </summary>
		/// <param name="changeNameRequest">Если в параметрах передавалось имя или фамилия пользователя,
		/// в этом параметре будет возвращен объект типа <see cref="ChangeNameRequest" />, содержащий информацию о заявке на смену имени.</param>
		/// <param name="params">The parameters.</param>
		/// <returns>
		/// Результат отмены заявки.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.saveProfileInfo" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool SaveProfileInfo(out ChangeNameRequest changeNameRequest, AccountSaveInfoParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(() => @params.RelationPartnerId);
			VkErrors.ThrowIfNumberIsNegative(() => @params.CountryId);
			VkErrors.ThrowIfNumberIsNegative(() => @params.CityId);

			var response = _vk.Call("account.saveProfileInfo", @params);

			changeNameRequest = response["name_request"];
			return response["changed"];
		}
	}
}