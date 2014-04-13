using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы этого класса позволяют производить действия с аккаунтом пользователя.
	/// </summary>
	public class AccountCategory
	{
		private readonly VkApi _vk;

		internal AccountCategory(VkApi vk)
		{
			_vk = vk;
		}
		/// <summary>
		/// Устанавливает короткое название приложения (до 17 символов), которое выводится пользователю в левом меню.
		/// Это происходит только в том случае, если пользователь добавил приложение в левое меню со страницы приложения, списка приложений или настроек. 
		/// </summary>
		/// <param name="name">Короткое название приложения (до 17 символов).</param>
		/// <returns>Возвращает результат установки короткого названия.</returns>
		/// <remarks>Если пользователь не установил приложение в левое меню, метод вернет ошибку 148 (Access to the menu of the user denied).</remarks>
		public bool SetNameInMenu([NotNull] string name)
		{
			VkErrors.ThrowIfNullOrEmpty(() => name);
			var parameters = new VkParameters { { "name", name } };
			return _vk.Call("account.setNameInMenu", parameters);
		}

		/// <summary>
		/// Помечает текущего пользователя как online на 15 минут. 
		/// </summary>
		/// <returns>Возвращает значение, показывающее, успешно ли выполнился метод.</returns>
		public bool SetOnline(bool? voip = null)
		{
			var parameters = new VkParameters { { "voip", voip } };
			return _vk.Call("account.setOnline", parameters);
		}

		/// <summary>
		/// Помечает текущего пользователя как offline.
		/// </summary>
		/// <returns>Возвращает значение, показывающее, успешно ли выполнился метод.</returns>
		public bool SetOffline()
		{
			return _vk.Call("account.setOffline", VkParameters.Empty);
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
		/// Отписывает устройство от Push уведомлений. 
		/// </summary>
		/// <param name="token">Идентификатор устройства.</param>
		/// <returns>Возвращает результат выполнения метода.</returns>
		public bool UnregisterDevice([NotNull] string token)
		{
			VkErrors.ThrowIfNullOrEmpty(() => token);

			var parameters = new VkParameters
							{
								{"token", token}
							};

			return _vk.Call("account.unregisterDevice", parameters);
		}


		/// <summary>
		/// Отключает push-уведомления на заданный промежуток времени.
		/// </summary>
		/// <param name="token">Идентификатор устройства для сервиса push уведомлений.</param>
		/// <param name="time">Время в секундах на которое требуется отключить уведомления. (-1 - отключить навсегда)</param>
		/// <param name="chatID">Идентификатор чата, для которого следует отключить уведомления.</param>
		/// <param name="userID">Идентификатор пользователя, для которого следует отключить уведомления.</param>
		/// <param name="sound">Включить звук в данном диалоге. (параметр работает только если указан <paramref name="userID"/> или <paramref name="chatID"/> )</param>
		/// <returns>Возвращает результат выполнения метода.</returns>
		public bool SetSilenceMode([NotNull] string token, int? time = null, int? chatID = null, int? userID = null, bool? sound = null)
		{
			VkErrors.ThrowIfNullOrEmpty(() => token);

			var parameters = new VkParameters
							{
								{"token", token},
								{"time", time},
								{"chat_id", chatID},
								{"user_id", userID}
							};
			if(sound.HasValue)
				parameters.Add("sound", sound.Value);  // Cause Add(string, bool?) deletes parameter whem bool? value equals to false.

			return _vk.Call("account.setSilenceMode", parameters);
		}

		/// <summary>
		/// Добавляет пользователя в черный список. 
		/// </summary>
		/// <param name="userID">Идентификатор пользователя, которого нужно добавить в черный список. (положительное число)</param>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>Если указанный пользователь является другом текущего пользователя или имеет от него входящую или исходящую заявку в друзья, то для добавления пользователя в черный список Ваше приложение должно иметь права: <see cref="Settings.Friends"/>.</remarks>
		public bool BanUser(int userID)
		{
			if(userID <= 0)
				throw new ArgumentException("User ID should be greater than 0.", "userID");
			return _vk.Call("account.banUser", new VkParameters() { { "user_id", userID } });
		}

		/// <summary>
		/// Убирает пользователя из черного списка. 
		/// </summary>
		/// <param name="userID">Идентификатор пользователя, которого нужно убрать из черного списка. (положительное число)</param>
		/// <returns>Возвращает результат выполнения метода.</returns>
		public bool UnbanUser(int userID)
		{
			if (userID <= 0)
				throw new ArgumentException("User ID should be greater than 0.", "userID");
			return _vk.Call("account.unbanUser", new VkParameters() { { "user_id", userID } });
		}


		/// <summary>
		/// Возвращает список пользователей, находящихся в черном списке. 
		/// </summary>
		/// <param name="total">Возвращает общее количество находящихся в черном списке пользователей.</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества черного списка. (положительное число) </param>
		/// <param name="count">Количество записей, которое необходимо вернуть. (положительное число, по умолчанию - 20, максимальное значение - 200) </param>
		/// <returns>Возвращает набор объектов пользователей, находящихся в черном списке. </returns>
		[Pure]
		public IEnumerable<User> GetBanned(out int total, int? offset = null, int? count = null)
		{
			VkErrors.ThrowIfNumberIsNegative(offset, "offset");
			VkErrors.ThrowIfNumberIsNegative(count, "count");

			var parameters = new VkParameters()
								{
									{"offset", offset},
									{"count", count}
								};
			var response = _vk.Call("account.getBanned", parameters);

			total = response["count"];

			return response["items"].ToListOf<User>(vkResponse => vkResponse);
		}

		/// <summary>
		/// Возвращает информацию о текущем аккаунте. 
		/// </summary>
		[Pure]
		public AccountInfo GetInfo()
		{
			return _vk.Call("account.getInfo", VkParameters.Empty);
		}


		/// <summary>
		/// Позволяет редактировать информацию о текущем аккаунте. 
		/// </summary>
		/// <param name="intro">Битовая маска, отвечающая за прохождение обучения в мобильных клиентах. (положительное число)</param>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>Если параметр <paramref name="intro"/> не установлен, он сбрасывается на 0.</remarks>
		public bool SetInfo(int? intro = null)
		{
			VkErrors.ThrowIfNumberIsNegative(intro, "intro");
			return _vk.Call("account.setInfo", new VkParameters(){{"intro", intro}});
		}


		/// <summary>
		/// Возвращает информацию о текущем профиле.
		/// </summary>
		/// <returns>Информация о текущем профиле в виде <see cref="Model.User"/></returns>
		[Pure]
		public User GetProfileInfo()
		{
			var info = _vk.Call("account.getProfileInfo", VkParameters.Empty);
			
			//TODO: проверить эту гадость на корректность работы во разных ситуациях, или убрать, заменив в User свойство Id на Nullable
			// Внедрение Id пользователя в ответ с сервера
			if (!(info.ContainsKey("uid") || info.ContainsKey("id")) && _vk.UserId.HasValue)
			{
				string modifiedAnswer = Regex.Replace(info.RawJson, @"'response': {", @"'response': { id: " + _vk.UserId.Value + @", ", RegexOptions.IgnoreCase & RegexOptions.Multiline);
				Trace.WriteLine(Utilities.PreetyPrintJson(info.RawJson));
				JObject json = JObject.Parse(modifiedAnswer);
				var rawResponse = json["response"];
			    return new VkResponse(rawResponse) { RawJson = modifiedAnswer };
			}

			return info;
		}


		/// <summary>
		/// Редактирует информацию текущего профиля. 
		/// </summary>
		/// <param name="cancelRequestId">Идентификатор заявки на смену имени, которую необходимо отменить.</param>
		/// <returns>Результат отмены заявки.</returns>
		/// <remarks>Метод вынесен как отдельный, потому что если в запросе передан параметр <paramref name="cancelRequestId"/>, все остальные параметры игнорируются.</remarks>
		public bool SaveProfileInfo(int cancelRequestId)
		{
			VkErrors.ThrowIfNumberIsNegative(cancelRequestId, "cancelRequestId");
			return _vk.Call("account.saveProfileInfo", new VkParameters() { { "cancel_request_id", cancelRequestId } })["changed"]
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
		public bool SaveProfileInfo(string firstName = null, string lastName = null, string maidenName = null, Sex? sex = null,
			RelationType? relation = null, long? relationPartnerId = null, DateTime? birthDate = null, BirthdayVisibility? birthDateVisibility = null,
			string homeTown = null, long? countryId = null, long? cityId = null)
		{
			ChangeNameRequest request;
			return SaveProfileInfo(out request, firstName, lastName, maidenName, sex, relation, relationPartnerId, birthDate, birthDateVisibility,
				homeTown,countryId, cityId);
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
		public bool SaveProfileInfo(out ChangeNameRequest changeNameRequest, string firstName = null, string lastName = null, string maidenName = null, Sex? sex = null,
			RelationType? relation = null, long? relationPartnerId = null, DateTime? birthDate = null, BirthdayVisibility? birthDateVisibility = null,
			string homeTown = null, long? countryId = null, long? cityId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(relationPartnerId, "relationPartnerId");
			VkErrors.ThrowIfNumberIsNegative(countryId, "countryId");
			VkErrors.ThrowIfNumberIsNegative(cityId, "cityId");
			
			changeNameRequest = null;
			
			VkParameters parameters = new VkParameters
									{
										{"first_name", firstName},
										{"last_name", lastName},
										{"maiden_name", maidenName},
										{"sex", ((sex ?? Sex.Unknown) ==  Sex.Unknown) ? null : sex},
										{"relation", relation},
										{"relation_partner_id", relationPartnerId},
										{"bdate", birthDate != null ? birthDate.Value.ToString("dd.MM.yyyy") : null},
										{"bdate_visibility", birthDateVisibility},
										{"home_town", homeTown},
										{"country_id", countryId},
										{"city_id", cityId}
									};

			var response = _vk.Call("account.saveProfileInfo", parameters);

			changeNameRequest = response["name_request"];
			return response["changed"];

		}

	}
}