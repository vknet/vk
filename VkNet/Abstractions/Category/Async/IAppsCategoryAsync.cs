using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с методами приложений.
/// </summary>
public interface IAppsCategoryAsync
{
	/// <summary>
	/// Возвращает список приложений, доступных для пользователей сайта через каталог
	/// приложений.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="skipAuthorization"> Если <c> true </c>, то пропустить авторизацию </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает общее число найденных приложений и массив
	/// объектов приложений.
	/// </returns>
	/// <remarks>
	/// К методу можно делать не более 60 запросов в минуту с одного IP или id.
	/// Страница документации ВКонтакте http://vk.com/dev/apps.getCatalog
	/// </remarks>
	Task<VkCollection<App>> GetCatalogAsync(AppGetCatalogParams @params,
											bool skipAuthorization = false,
											CancellationToken token = default);

	/// <summary>
	/// Возвращает данные о запрошенном приложении на платформе ВКонтакте
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="skipAuthorization"> Если <c> true </c>, то пропустить авторизацию </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает объект приложения.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/apps.get
	/// </remarks>
	Task<AppGetObject> GetAsync(AppGetParams @params,
								bool skipAuthorization = false,
								CancellationToken token = default);

	/// <summary>
	/// Позволяет отправить запрос другому пользователю в приложении, использующем
	/// авторизацию ВКонтакте.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// В случае удачного выполнения метод возвращает идентификатор созданного запроса,
	/// например:
	/// 10013.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/apps.sendRequest
	/// </remarks>
	Task<long> SendRequestAsync(AppSendRequestParams @params,
								CancellationToken token);

	/// <summary>
	/// Удаляет все уведомления о запросах, отправленных из текущего приложения.
	/// </summary>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// В случае успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/apps.deleteAppRequests
	/// </remarks>
	Task<bool> DeleteAppRequestsAsync(CancellationToken token);

	/// <summary>
	/// Создает список друзей, который будет использоваться при отправке пользователем
	/// приглашений в приложение.
	/// </summary>
	/// <param name="type"> Tип создаваемого списка друзей. </param>
	/// <param name="extended">
	/// Параметр, определяющий необходимость возвращать расширенную информацию о
	/// пользователях.
	/// 0 — возвращаются только идентификаторы;
	/// 1 — будут дополнительно возвращены имя и фамилия. флаг, может принимать
	/// значения 1 или 0, по умолчанию 0
	/// Async(Флаг, может принимать значения 1 или 0, по умолчанию 0).
	/// </param>
	/// <param name="count"> Количество пользователей в создаваемом списке. </param>
	/// <param name="offset">
	/// Смещение относительно первого пользователя для выборки определенного
	/// подмножества.
	/// </param>
	/// <param name="fields">
	/// Список дополнительных полей профилей, которые необходимо вернуть. См. подробное
	/// описание.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список пользователей.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/apps.getFriendsList
	/// </remarks>
	Task<VkCollection<User>> GetFriendsListAsync(AppRequestType type,
												bool? extended = true,
												long? count = null,
												long? offset = null,
												UsersFields fields = null,
												CancellationToken token = default);

	/// <summary>
	/// Создает список друзей, который будет использоваться при отправке пользователем
	/// приглашений в приложение.
	/// </summary>
	/// <param name="type"> Tип создаваемого списка друзей. </param>
	/// <param name="count"> Количество пользователей в создаваемом списке. </param>
	/// <param name="offset">
	/// Смещение относительно первого пользователя для выборки определенного
	/// подмножества.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <param name="fields">
	/// Список дополнительных полей профилей, которые необходимо вернуть. См. подробное
	/// описание.
	/// </param>
	/// <returns>
	/// После успешного выполнения возвращает список пользователей.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/apps.getFriendsList
	/// </remarks>
	Task<VkCollection<long>> GetFriendsListAsync(AppRequestType type,
												long? count = null,
												long? offset = null,
												UsersFields fields = null,
												CancellationToken token = default);

	/// <summary>
	/// Возвращает рейтинг пользователей в игре.
	/// </summary>
	/// <param name="type">
	/// Level — рейтинг по уровням,
	/// points — рейтинг по очкам, начисленным за выполнение миссий.
	/// score — рейтинг по очкам, начисленным напрямую Async(apps.getScore). строка,
	/// обязательный параметр Async(Строка,
	/// обязательный параметр).
	/// </param>
	/// <param name="global">
	/// 1 — глобальный рейтинг по всем игрокам,
	/// 0 — рейтинг по друзьям пользователя флаг, может принимать значения 1 или 0, по
	/// умолчанию 1 Async(Флаг, может
	/// принимать значения 1 или 0, по умолчанию 1).
	/// </param>
	/// <param name="extended">
	/// 1 — дополнительно возвращает информацию о пользователе. флаг, может принимать
	/// значения 1 или 0,
	/// по умолчанию 0 Async(Флаг, может принимать значения 1 или 0, по умолчанию 0).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список друзей с текущим уровнем и
	/// количеством очков в игре, отсортированный
	/// по убыванию текущего уровня или количества очков.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/apps.getLeaderboard
	/// </remarks>
	Task<LeaderboardResult> GetLeaderboardAsync(AppRatingType type,
												bool? global = null,
												bool? extended = null,
												CancellationToken token = default);

	/// <summary>
	/// Метод возвращает количество очков пользователя в этой игре.
	/// </summary>
	/// <param name="userId">
	/// Идентификатор пользователя. положительное число, по умолчанию идентификатор
	/// текущего пользователя,
	/// обязательный параметр Async(Положительное число, по умолчанию идентификатор
	/// текущего пользователя, обязательный
	/// параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает число очков для пользователя.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/apps.getScore
	/// </remarks>
	Task<long> GetScoreAsync(long userId, CancellationToken token);

	/// <summary>
	/// Возвращает данные о политике конфиденциальности запрошенного приложения
	/// </summary>
	/// <param name="appId"> Идентификатор приложения </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает объект политики конфиденциальности.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/apps.getMiniAppPolicies
	/// </remarks>
	Task<MiniAppPolicies> GetMiniAppPoliciesAsync(ulong appId,
												CancellationToken token);

	/// <summary>
	/// Возвращает данные о правах пользователя
	/// </summary>
	/// <param name="type"> Тип. По умолчанию user </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает массив scopes.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/apps.getScopes
	/// </remarks>
	Task<AppGetScopesResult> GetScopesAsync(string type = "user",
											CancellationToken token = default);

	/// <summary>
	/// Проверяет есть ли у пользователя подарок в игре.
	/// </summary>
	/// <param name="promoId"> Идентификатор промо-акции </param>
	/// <param name="userId"> Идентификатор пользователя. Используется только при запросе с сервисным токеном. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает
	/// 1 - у пользователя есть активный подарок, нужно выдать подарок пользователю в игре и затем погасить его используя метод apps.promoUseGift.
	/// 0 - у пользователя нет активного подарка в вашей игре.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/apps.promoHasActiveGift
	/// </remarks>
	Task<bool> PromoHasActiveGiftAsync(ulong promoId,
										ulong? userId = null,
										CancellationToken token = default);

	/// <summary>
	/// Использовать подарок, полученный пользователем в промо-акции.
	/// </summary>
	/// <param name="promoId"> Идентификатор промо-акции </param>
	/// <param name="userId"> Идентификатор пользователя. Используется только при запросе с сервисным токеном. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает
	/// 1 - успех операции.
	/// 0 - неудача.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/apps.promoUseGift
	/// </remarks>
	Task<bool> PromoUseGiftAsync(ulong promoId,
								ulong? userId = null,
								CancellationToken token = default);
}