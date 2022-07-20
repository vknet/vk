using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JetBrains.Annotations;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы с информацией о пользователях.
	/// </summary>
	public interface IUsersCategoryAsync
	{
		/// <summary>
		/// Возвращает список пользователей в соответствии с заданным критерием поиска.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов пользователей, найденных
		/// в соответствии с заданными
		/// критериями.
		/// </returns>
		/// <exception cref="ArgumentException"> Query can not be <c> null </c> or empty. </exception>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.search
		/// </remarks>
		Task<VkCollection<User>> SearchAsync(UserSearchParams @params);

		/// <summary>
		/// Возвращает информацию о том, установил ли пользователь приложение.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя. целое число, по умолчанию идентификатор текущего
		/// пользователя (Целое
		/// число, по умолчанию идентификатор текущего пользователя).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1 в случае, если пользователь установил у
		/// себя данное приложение, иначе 0.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.isAppUser
		/// </remarks>
		Task<bool> IsAppUserAsync(long? userId);

		/// <summary>
		/// Возвращает расширенную информацию о пользователях. Метод не требует авторизацию
		/// </summary>
		/// <param name="userIds">
		/// Идентификаторы пользователей, о которых необходимо
		/// получить информацию.
		/// </param>
		/// <param name="fields"> Поля профилей, которые необходимо возвратить. </param>
		/// <param name="nameCase"> Падеж для склонения имени и фамилии пользователя </param>
		/// <returns> Список объектов с запрошенной информацией о пользователях. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.get
		/// </remarks>
		Task<ReadOnlyCollection<User>> GetAsync([NotNull]
												IEnumerable<long> userIds
												, ProfileFields fields = null
												, NameCase nameCase = null);

		/// <summary>
		/// Возвращает расширенную информацию о пользователях.
		/// </summary>
		/// <param name="screenNames">
		/// Короткие имена пользователей, о которых необходимо
		/// получить информацию.
		/// </param>
		/// <param name="fields"> Поля профилей, которые необходимо возвратить. </param>
		/// <param name="nameCase"> Падеж для склонения имени и фамилии пользователя </param>
		/// <returns> Список объектов с запрошенной информацией о пользователях. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.get
		/// </remarks>
		Task<ReadOnlyCollection<User>> GetAsync([NotNull]
												IEnumerable<string> screenNames
												, ProfileFields fields = null
												, NameCase nameCase = null);

		/// <summary>
		/// Возвращает список идентификаторов пользователей и групп, которые входят в
		/// список подписок пользователя.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, подписки которого необходимо
		/// получить
		/// </param>
		/// <param name="count"> Количество подписок, которые необходимо вернуть </param>
		/// <param name="offset">
		/// Смещение необходимое для выборки определенного
		/// подмножества подписок
		/// </param>
		/// <param name="fields">
		/// Список дополнительных полей для объектов user и group, которые необходимо
		/// вернуть.
		/// </param>
		/// <returns>
		/// Пока возвращается только список групп.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.getSubscriptions
		/// </remarks>
		Task<VkCollection<Group>> GetSubscriptionsAsync(long? userId = null
														, int? count = null
														, int? offset = null
														, GroupsFields fields = null);

		/// <summary>
		/// Возвращает список идентификаторов пользователей, которые являются подписчиками
		/// пользователя.
		/// </summary>
		/// <param name="userId"> Идентификатор пользователя </param>
		/// <param name="count">
		/// Количество подписчиков, информацию о которых нужно
		/// получить
		/// </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного
		/// подмножества подписчиков
		/// </param>
		/// <param name="fields"> Список дополнительных полей, которые необходимо вернуть </param>
		/// <param name="nameCase"> Падеж для склонения имени и фамилии пользователя </param>
		/// <returns> Список подписчиков </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.getFollowers
		/// </remarks>
		Task<VkCollection<User>> GetFollowersAsync(long? userId = null
													, int? count = null
													, int? offset = null
													, ProfileFields fields = null
													, NameCase nameCase = null);

		/// <summary>
		/// Позволяет пожаловаться на пользователя.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, на которого осуществляется
		/// жалоба
		/// </param>
		/// <param name="type"> Тип жалобы </param>
		/// <param name="comment"> Комментарий к жалобе на пользователя </param>
		/// <returns> В случае успешной жалобы метод вернет true. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.report
		/// </remarks>
		Task<bool> ReportAsync(long userId, ReportType type, string comment = "");

		/// <summary>
		/// Индексирует текущее местоположение пользователя и возвращает список
		/// пользователей, которые находятся вблизи.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов user.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.getNearby
		/// </remarks>
		Task<VkCollection<User>> GetNearbyAsync(UsersGetNearbyParams @params);
	}
}