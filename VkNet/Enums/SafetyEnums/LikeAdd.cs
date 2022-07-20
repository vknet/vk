using System;
using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Событие о новой отметке "Мне нравится"
	/// </summary>
	[Serializable]
	public class LikeAdd : IGroupUpdate
	{
		/// <summary>
		/// Идентификатор пользователя, который поставил отметку.
		/// </summary>
		[JsonProperty("liker_id")]
		public long? LikerId { get; set; }

		/// <summary>
		/// Тип материала.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		[JsonProperty("object_type")]
		public LikeObjectType ObjectType { get; set; }

		/// <summary>
		/// Идентификатор владельца материала.
		/// </summary>
		[JsonProperty("object_owner_id")]
		public long? ObjectOwnerId { get; set; }

        /// <summary>
		/// Идентификатор материала.
		/// </summary>
		[JsonProperty("object_id")]
		public long? ObjectId { get; set; }

        /// <summary>
		/// Идентификатор родительского комментария/записи.
		/// </summary>
		[JsonProperty("thread_reply_id")]
		public long? ThreadReplyId { get; set; }

        /// <summary>
		/// Идентификатор записи (возвращается для комментария, оставленного под записью).
		/// </summary>
		[JsonProperty("post_id")]
		public long? PostId { get; set; }


		#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static LikeAdd FromJson(VkResponse response)
		{
			return new LikeAdd
			{
				LikerId = response["liker_id"],
				ObjectType = response["object_type"],
				ObjectOwnerId = response["object_owner_id"],
                ObjectId= response["object_id"],
                ThreadReplyId= response["thread_reply_id"],
                PostId= response["post_id"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="LikeAdd" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="LikeAdd" /></returns>
		public static implicit operator LikeAdd(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}

		#endregion
	}
}