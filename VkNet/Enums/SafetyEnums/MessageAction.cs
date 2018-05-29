using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Действия для сообщений
	/// </summary>
	public class MessageAction : SafetyEnum<MessageAction>
	{
		/// <summary>
		/// обновлена фотография беседы;
		/// </summary>
		public static readonly MessageAction ChatPhotoUpdate = RegisterPossibleValue(value: "chat_photo_update");

		/// <summary>
		/// удалена фотография беседы;
		/// </summary>
		public static readonly MessageAction ChatPhotoRemove = RegisterPossibleValue(value: "chat_photo_remove");

		/// <summary>
		/// создана беседа;
		/// </summary>
		public static readonly MessageAction ChatCreate = RegisterPossibleValue(value: "chat_create");

		/// <summary>
		/// обновлено название беседы;
		/// </summary>
		public static readonly MessageAction ChatTitleUpdate = RegisterPossibleValue(value: "chat_title_update");

		/// <summary>
		/// приглашен пользователь;
		/// </summary>
		public static readonly MessageAction ChatInviteUser = RegisterPossibleValue(value: "chat_invite_user");

		/// <summary>
		/// исключен пользователь.
		/// </summary>
		public static readonly MessageAction ChatKickUser = RegisterPossibleValue(value: "chat_kick_user");

		/// <summary>
		/// закреплено сообщение;
		/// </summary>
		public static readonly MessageAction ChatPinMessage = RegisterPossibleValue(value: "chat_pin_message");

		/// <summary>
		/// откреплено сообщение.
		/// </summary>
		public static readonly MessageAction ChatUnpinMessage = RegisterPossibleValue(value: "chat_unpin_message");

		/// <summary>
		/// пользователь присоединился к беседе по ссылке.
		/// </summary>
		public static readonly MessageAction ChatInviteUserByLink = RegisterPossibleValue(value: "chat_invite_user_by_link");

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator MessageAction(VkResponse response)
		{
			return response?.HasToken() != null ? FromJson(response: response) : null;
		}
	}
}