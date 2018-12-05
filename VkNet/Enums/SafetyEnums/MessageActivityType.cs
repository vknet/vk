using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	[Serializable]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public class MessageActivityType : SafetyEnum<MessageActivityType>
	{
		/// <summary>
		/// Пользователь начал набирать текст.
		/// </summary>
		public static readonly MessageActivityType Typing = RegisterPossibleValue("typing");

		/// <summary>
		/// Пользователь записывает голосовое сообщение.
		/// </summary>
		public static readonly MessageActivityType AudioMessage = RegisterPossibleValue("audiomessage");
	}
}