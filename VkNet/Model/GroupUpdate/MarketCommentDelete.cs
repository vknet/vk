using System;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Удаление комментария к товару (<c>MarketCommentDelete</c>)
	/// </summary>
	[Serializable]
	public class MarketCommentDelete : IGroupUpdate
	{
		/// <summary>
		/// Идентификатор комментария
		/// </summary>
		public ulong? Id { get; set; }

		/// <summary>
		/// Идентификатор товара
		/// </summary>
		public ulong? ItemId { get; set; }

		/// <summary>
		/// Идентификатор владельца товара
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор автора комментария
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор пользователя, который удалил комментарий
		/// </summary>
		public long? DeleterId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static MarketCommentDelete FromJson(VkResponse response)
		{
			return new MarketCommentDelete
			{
				Id = response["id"],
				ItemId = response["item_id"],
				OwnerId = response["owner_id"],
				UserId = response["user_id"],
				DeleterId = response["deleter_id"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="MarketCommentDelete" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="Message" /> </returns>
		public static implicit operator MarketCommentDelete(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}