using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о сервисном действии с чатом.
	/// </summary>
	[Serializable]
	public class MessageActionObject
	{
		/// <summary>
		/// Информация о сервисном действии с чатом.
		/// </summary>
		[JsonProperty("type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public MessageAction Type { get; set; }

		/// <summary>
		/// Идентификатор пользователя, которого пригласили или исключили
		/// (для служебных сообщений с type = chat_invite_user, chat_invite_user_by_link или chat_kick_user).
		/// Идентификатор пользователя, который закрепил/открепил сообщение для action = chat_pin_message или chat_unpin_message.
		/// </summary>
		[JsonProperty("member_id")]
		public long? MemberId { get; set; }

		/// <summary>
		/// Название беседы (для служебных сообщений с type = chat_create или chat_title_update).
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Id сообщения, с которым произведено действие (для служебных сообщений с type = chat_pin_message или chat_unpin_message).
		/// </summary>
		[JsonProperty("conversation_message_id")]
		public long? ConversationMessageId { get; set; }

		/// <summary>
		/// Текст сообщения с которым произведено действие (для служебных сообщений с type = chat_pin_message).
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }

		/// <summary>
		/// Email, который пригласили или исключили (для служебных сообщений с type = chat_invite_user или chat_kick_user и отрицательным member_id).
		/// </summary>
		[JsonProperty("email")]
		public string Email { get; set; }

		/// <summary>
		/// Изображение-обложка чата.
		/// </summary>
		[JsonProperty("photo")]
		public Photo Photo { get; set; }

		/// <summary>
		/// Преобразование из <see cref="VkResponse"/> в <see cref="MessageActionObject"/>
		/// </summary>
		/// <param name="response">Ответ вк</param>
		/// <returns></returns>
		public static MessageActionObject FromJson(VkResponse response)
		{
			var action = new MessageActionObject
			{
				Type = response["type"],
				MemberId = response["member_id"],
				Text = response["text"],
				ConversationMessageId = response["conversation_message_id"],
				Message = response["message"],
				Email = response["email"],
				Photo = response["photo"]
			};

			return action;
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator MessageActionObject(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken() ? FromJson(response) : null;
		}
	}
}