using System;
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
		[ApiVersion("5.44")]
		public ReadOnlyCollection<App> GetCatalog(out long totalCount, AppGetCatalogParams @params)
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
		/// После успешного выполнения возвращает объект приложения.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/apps.get" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<App> Get(out long totalCount, AppGetParams @params)
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
		/// В случае удачного выполнения метод возвращает идентификатор созданного запроса, например: 
		/// 10013.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/apps.sendRequest" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public long SendRequest(AppSendRequestParams @params)
		{
			return _vk.Call("apps.sendRequest", @params); 
		}

		/// <summary>
		/// Удаляет все уведомления о запросах, отправленных из текущего приложения.
		/// </summary>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/apps.deleteAppRequests" />.
		/// </remarks>
		[ApiVersion("5.44")]
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
		/// <param name="fields">Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание. </param>
		/// <returns>
		/// После успешного выполнения возвращает список пользователей.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/apps.getFriendsList" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<User> GetFriendsList(out long totalCount, AppRequestType type, bool? extended = null, long? count = null, long? offset = null, UsersFields fields = null)
		{
			var parameters = new VkParameters
			{
				{ "extended", extended },
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
			return result["items"].ToReadOnlyCollectionOf<User>(x => fields == null ? new User {Id = x} : x);
		}

		/// <summary>
		/// Возвращает рейтинг пользователей в игре.
		/// </summary>
		/// <param name="type">Level — рейтинг по уровням, 
		/// points — рейтинг по очкам, начисленным за выполнение миссий. 
		/// score — рейтинг по очкам, начисленным напрямую (apps.getScore). строка, обязательный параметр (Строка, обязательный параметр).</param>
		/// <param name="global">1 — глобальный рейтинг по всем игрокам, 
		/// 0 — рейтинг по друзьям пользователя флаг, может принимать значения 1 или 0, по умолчанию 1 (Флаг, может принимать значения 1 или 0, по умолчанию 1).</param>
		/// <param name="extended">1 — дополнительно возвращает информацию о пользователе. флаг, может принимать значения 1 или 0, по умолчанию 0 (Флаг, может принимать значения 1 или 0, по умолчанию 0).</param>
		/// <returns>
		/// После успешного выполнения возвращает список друзей с текущим уровнем и количеством очков в игре, отсортированный по убыванию текущего уровня или количества очков.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/apps.getLeaderboard" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool GetLeaderboard(AppRatingType type, bool? global = null, bool? extended = null)
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
		/// <param name="userId">Идентификатор пользователя. положительное число, по умолчанию идентификатор текущего пользователя, обязательный параметр (Положительное число, по умолчанию идентификатор текущего пользователя, обязательный параметр).</param>
		/// <returns>
		/// После успешного выполнения возвращает число очков для пользователя.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/apps.getScore" />.
		/// </remarks>
		[ApiVersion("5.44")]
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
