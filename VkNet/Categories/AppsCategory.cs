using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с приложениями.
	/// </summary>
	public class AppsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с приложениями.
		/// </summary>
		/// <param name="vk">API.</param>
		internal AppsCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает список приложений, доступных для пользователей сайта через каталог приложений.
		/// </summary>
		/// <param name="totalCount">Количество приложений.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает общее число найденных приложений и массив объектов приложений.
		/// </returns>
		/// <remarks>
		/// К методу можно делать не более 60 запросов в минуту с одного IP или id.
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/apps.getCatalog" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public IEnumerable<App> GetCatalog(out int totalCount, AppGetCatalogParams @params)
		{
			var response = _vk.Call("apps.getCatalog", @params, !@params.ReturnFriends);
			totalCount = response["count"];

			return response["items"].ToReadOnlyCollectionOf<App>(x => x);
		}

		/// <summary>
		/// Возвращает данные о запрошенном приложении на платформе ВКонтакте
		/// </summary>
		/// <param name="totalCount">Количество приложений.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/apps.get" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public IEnumerable<App> Get(out int totalCount, AppGetParams @params)
		{
			var result = _vk.Call("apps.get", @params);
			totalCount = result["count"];

			return result["items"].ToReadOnlyCollectionOf<App>(x => x);
		}

		/// <summary>
		/// Позволяет отправить запрос другому пользователю в приложении, использующем авторизацию ВКонтакте.
		/// </summary>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/apps.sendRequest" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public ulong SendRequest(AppSendRequestParams @params)
		{
			return _vk.Call("apps.sendRequest", @params); 
		}

		/// <summary>
		/// Удаляет все уведомления о запросах, отправленных из текущего приложения
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/apps.deleteAppRequests" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool DeleteAppRequests()
		{
			var parameters = new VkParameters();
			return _vk.Call("apps.deleteAppRequests", parameters);
		}

		/// <summary>
		/// Создает список друзей, который будет использоваться при отправке пользователем приглашений в приложение.
		/// </summary>
		/// <param name="totalCount">Количество приложений.</param>
		/// <param name="count">Количество пользователей в создаваемом списке.</param>
		/// <param name="offset">Смещение относительно первого пользователя для выборки определенного подмножества.</param>
		/// <param name="type">Tип создаваемого списка друзей.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/apps.getFriendsList" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public ReadOnlyCollection<long> GetFriendsList(out int totalCount, AppRequestType type, int count = 20, int offset = 0)
		{
			var parameters = new VkParameters
			{
				{ "extended", false },
				{ "offset", offset },
				{ "type", type }
			};
			if (count <= 5000)
			{
				parameters.Add("count", count);
			}
			var result = _vk.Call("apps.getFriendsList", parameters);
			totalCount = result["count"];
			VkResponseArray items = result["items"];
			return items.ToReadOnlyCollectionOf<long>(x => x);
		}

		/// <summary>
		/// Создает список друзей, который будет использоваться при отправке пользователем приглашений в приложение.
		/// </summary>
		/// <param name="totalCount">Количество приложений.</param>
		/// <param name="count">Количество пользователей в создаваемом списке.</param>
		/// <param name="offset">Смещение относительно первого пользователя для выборки определенного подмножества.</param>
		/// <param name="type">Tип создаваемого списка друзей.</param>
		/// <param name="fields">Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание. </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/apps.getFriendsList" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public ReadOnlyCollection<User> GetFriendsListEx(out int totalCount, AppRequestType type, int count = 20, int offset = 0, UsersFields fields = null)
		{
			var parameters = new VkParameters
			{
				{ "extended", true },
				{ "offset", offset },
				{ "type", type },
				{ "fields", fields }
			};
			if (count <= 5000)
			{
				parameters.Add("count", count);
			}
			var result = _vk.Call("apps.getFriendsList", parameters);
			totalCount = result["count"];
			return result["items"].ToReadOnlyCollectionOf<User>(x => x);
		}

		/// <summary>
		/// Возвращает рейтинг пользователей в игре.
		/// </summary>
		/// <param name="type">
		/// level — рейтинг по уровням, 
		/// points — рейтинг по очкам
		/// </param>
		/// <param name="global">
		/// <c>true</c> — глобальный рейтинг по всем игрокам, 
		/// <c>false</c> — рейтинг по друзьям пользователя 
		/// </param>
		/// <param name="extended"><c>true</c> — дополнительно возвращает информацию о пользователе.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <exception cref="System.NotImplementedException"></exception>
		/// <remarks>
		/// Метод доступен только приложениям, размещенным в игровом каталоге. 
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/apps.getLeaderboard" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool GetLeaderboard(AppRatingType type, bool global = true, bool extended = false)
		{
			//var parameters = new VkParameters
			//{
			//	{ "type", type },
			//	{ "global", global },
			//	{ "extended", extended }
			//};
			//return _vk.Call("apps.getLeaderboard", parameters);
			throw new NotImplementedException(); // TODO: Методы доступны только приложениям, размещенным в игровом каталоге. 
		}

		/// <summary>
		/// Метод возвращает количество очков пользователя в этой игре.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Метод доступен только приложениям, размещенным в игровом каталоге.
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/apps.getScore" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public long GetScore(long userId)
		{
            VkErrors.ThrowIfNumberIsNegative(() => userId);
            var parameters = new VkParameters
			{
				{ "user_id", userId }
			};
			return _vk.Call("apps.getScore", parameters);
		}
	}
}
