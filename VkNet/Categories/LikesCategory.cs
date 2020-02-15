using System;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// API для работы с лайками.
	/// </summary>
	public partial class LikesCategory : ILikesCategory
	{
		/// <summary>
		/// API
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// API для работы с лайками.
		/// </summary>
		/// <param name="vk"> The vk. </param>
		public LikesCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

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
		public VkCollection<long> GetList(LikesGetListParams @params, bool skipAuthorization = false)
		{
			@params.Extended = false;

			return _vk.Call("likes.getList", @params, skipAuthorization)
				.ToVkCollectionOf<long>(selector: x => x);
		}

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
		public UserOrGroup GetListEx(LikesGetListParams @params)
		{
			@params.Extended = true;

			return _vk.Call("likes.getList", @params, true);
		}

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
		public long Add(LikesAddParams @params)
		{
			var response = _vk.Call("likes.add", @params);

			return response[key: "likes"];
		}

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
		/// <param name="captchaSid"> Идентификатор капчи </param>
		/// <param name="captchaKey"> Текст, который ввел пользователь </param>
		/// <returns>
		/// В случае успеха возвращает объект с полем likes, в котором находится текущее
		/// количество пользователей, которые
		/// добавили данный объект в свой список Мне нравится.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/likes.delete
		/// </remarks>
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public long Delete(LikeObjectType type, long itemId, long? ownerId = null, long? captchaSid = null, string captchaKey = null)
		{
			return Delete(type, itemId, ownerId);
		}

		/// <inheritdoc />
		public long Delete(LikeObjectType type, long itemId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "type", type },
				{ "item_id", itemId },
				{ "owner_id", ownerId }
			};

			var response = _vk.Call("likes.delete", parameters);

			return response[key: "likes"];
		}

		/// <summary>
		/// Проверяет, находится ли объект в списке Мне нравится заданного пользователя.
		/// </summary>
		/// <param name="copied"> Сделан ли репост текущим пользователем. </param>
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
		public bool IsLiked(out bool copied, LikeObjectType type, long itemId, long? userId = null, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "type", type },
				{ "item_id", itemId },
				{ "user_id", userId },
				{ "owner_id", ownerId }
			};

			var resp = _vk.Call("likes.isLiked", parameters);

			copied = resp[key: "copied"];

			return resp[key: "liked"];
		}
	}
}