using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Типы действий, которые должны произойти после нажатия на кнопку
	/// </summary>
	[Serializable]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public class MessageEventType : SafetyEnum<MessageEventType>
	{
		/// <summary>
		/// показать исчезающее сообщение.
		/// </summary>
		public static readonly MessageEventType SnowSnackbar = RegisterPossibleValue("show_snackbar");

		/// <summary>
		/// открыть ссылку. Осуществляется переход по указанному адресу.
		/// </summary>
		public static readonly MessageEventType OpenLink = RegisterPossibleValue("open_link");

		/// <summary>
		/// открыть VK Mini App. Происходит переход в мини-приложение.
		/// </summary>
		public static readonly MessageEventType OpenApp = RegisterPossibleValue("open_app");
	}
}