using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип актиновсти в диалоге.
	/// </summary>
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