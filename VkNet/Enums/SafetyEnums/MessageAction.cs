﻿using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Действия для сообщений
/// </summary>
public class MessageAction : SafetyEnum<MessageAction>
{
	/// <summary>
	/// обновлена фотография беседы;
	/// </summary>
	[EnumMember(Value = "chat_photo_update")]
	public static readonly MessageAction ChatPhotoUpdate = RegisterPossibleValue(value: "chat_photo_update");

	/// <summary>
	/// удалена фотография беседы;
	/// </summary>
	[EnumMember(Value = "chat_photo_remove")]
	public static readonly MessageAction ChatPhotoRemove = RegisterPossibleValue(value: "chat_photo_remove");

	/// <summary>
	/// создана беседа;
	/// </summary>
	[EnumMember(Value = "chat_create")]
	public static readonly MessageAction ChatCreate = RegisterPossibleValue(value: "chat_create");

	/// <summary>
	/// обновлено название беседы;
	/// </summary>
	[EnumMember(Value = "chat_title_update")]
	public static readonly MessageAction ChatTitleUpdate = RegisterPossibleValue(value: "chat_title_update");

	/// <summary>
	/// приглашен пользователь;
	/// </summary>
	[EnumMember(Value = "chat_invite_user")]
	public static readonly MessageAction ChatInviteUser = RegisterPossibleValue(value: "chat_invite_user");

	/// <summary>
	/// исключен пользователь.
	/// </summary>
	[EnumMember(Value = "chat_kick_user")]
	public static readonly MessageAction ChatKickUser = RegisterPossibleValue(value: "chat_kick_user");

	/// <summary>
	/// закреплено сообщение;
	/// </summary>
	[EnumMember(Value = "chat_pin_message")]
	public static readonly MessageAction ChatPinMessage = RegisterPossibleValue(value: "chat_pin_message");

	/// <summary>
	/// откреплено сообщение.
	/// </summary>
	[EnumMember(Value = "chat_unpin_message")]
	public static readonly MessageAction ChatUnpinMessage = RegisterPossibleValue(value: "chat_unpin_message");

	/// <summary>
	/// пользователь присоединился к беседе по ссылке.
	/// </summary>
	[EnumMember(Value = "chat_invite_user_by_link")]
	public static readonly MessageAction ChatInviteUserByLink = RegisterPossibleValue(value: "chat_invite_user_by_link");

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator MessageAction(VkResponse response) => response?.HasToken() != null
		? FromJson(response: response)
		: null;
}