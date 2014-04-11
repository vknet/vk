using System;
using System.Collections.Generic;
using JetBrains.Annotations;
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
		[Pure]
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
		[Pure]
		public bool SetOnline(bool? voip = null)
		{
			var parameters = new VkParameters { { "voip", voip } };
			return _vk.Call("account.setOnline", parameters);
		}

		/// <summary>
		/// Помечает текущего пользователя как offline.
		/// </summary>
		/// <returns>Возвращает значение, показывающее, успешно ли выполнился метод.</returns>
		[Pure]
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
		[Pure]
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
		[Pure]
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
		[Pure]
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
		[Pure]
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
		[Pure]
		public bool SetInfo(int? intro = null)
		{
			VkErrors.ThrowIfNumberIsNegative(intro, "intro");
			return _vk.Call("account.setInfo", new VkParameters(){{"intro", intro}});
		}

	}
}