using System;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы с лайками.
	/// </summary>
	public interface ILikesCategoryAsync
	{
		/// <summary>
		/// Получает список идентификаторов пользователей или сообществ, которые добавили
		/// заданный объект в свой список Мне
		/// нравится.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <param name="skipAuthorization"> Если <c> true </c>, то пропустить авторизацию </param>
		/// <returns>
		/// Возвращает список идентификаторов пользователей или сообществ, которые добавили
		/// заданный объект в свой список Мне
		/// нравится.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/likes.getList
		/// </remarks>
		Task<VkCollection<long>> GetListAsync(LikesGetListParams @params, bool skipAuthorization = false);

		/// <summary>
		/// Получает список идентификаторов пользователей или сообществ, которые добавили
		/// заданный объект в свой список Мне
		/// нравится.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// Возвращает список пользователей и сообществ, которые добавили заданный объект в
		/// свой список Мне нравится.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/likes.getList
		/// </remarks>
		Task<UserOrGroup> GetListExAsync(LikesGetListParams @params);

		/// <summary>
		/// Добавляет указанный объект в список Мне нравится текущего пользователя.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// В случае успеха возвращает объект с полем likes, в котором находится текущее
		/// количество пользователей, которые
		/// добавили данный объект в свой список Мне нравится.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/likes.add
		/// </remarks>
		Task<long> AddAsync(LikesAddParams @params);

		/// <summary>
		/// Удаляет указанный объект из списка Мне нравится текущего пользователя
		/// </summary>
		/// <param name="type"> Тип объекта LikeObjectType </param>
		/// <param name="itemId">
		/// Идентификатор объекта. положительное число, обязательный
		/// параметр
		/// </param>
		/// <param name="ownerId">
		/// Идентификатор владельца объекта. целое число, по умолчанию идентификатор
		/// текущего пользователя
		/// </param>
		/// <returns>
		/// В случае успеха возвращает объект с полем likes, в котором находится текущее
		/// количество пользователей, которые
		/// добавили данный объект в свой список Мне нравится.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/likes.delete
		/// </remarks>
		Task<long> DeleteAsync(LikeObjectType type, long itemId, long? ownerId = null);

		/// <inheritdoc cref="ILikesCategoryAsync.DeleteAsync(LikeObjectType,long,long?)" />
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		Task<long> DeleteAsync(LikeObjectType type, long itemId, long? ownerId = null, long? captchaSid = null, string captchaKey = null);

		/// <summary>
		/// Проверяет, находится ли объект в списке Мне нравится заданного пользователя.
		/// </summary>
		/// <param name="type"> Тип объекта LikeObjectType </param>
		/// <param name="itemId">
		/// Идентификатор объекта. положительное число, обязательный
		/// параметр
		/// </param>
		/// <param name="userId">
		/// Идентификатор пользователя, у которого необходимо проверить наличие объекта в
		/// списке «Мне
		/// нравится». Если параметр не задан, то считается, что он равен идентификатору
		/// текущего пользователя. положительное
		/// число, по умолчанию идентификатор текущего пользователя
		/// </param>
		/// <param name="ownerId">
		/// Идентификатор владельца Like-объекта. Если параметр не задан, то считается, что
		/// он равен
		/// идентификатору текущего пользователя. целое число, по умолчанию идентификатор
		/// текущего пользователя
		/// </param>
		/// <returns>
		/// В случае успеха возвращает одно из следующих числовых значений:
		/// false — указанный Like-объект не входит в список Мне нравится пользователя с
		/// идентификатором user_id.
		/// true — указанный Like-объект находится в списке Мне нравится пользователя с
		/// идентификатором user_id.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/likes.isLiked
		/// </remarks>
		Task<bool> IsLikedAsync(LikeObjectType type, long itemId, long? userId = null, long? ownerId = null);
	}
}