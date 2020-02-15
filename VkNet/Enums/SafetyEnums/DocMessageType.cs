namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// тип документа
	/// </summary>
	public class DocMessageType : SafetyEnum<DocMessageType>
	{
		/// <summary>
		/// DocMessageType
		/// </summary>
		public static readonly DocMessageType Doc = RegisterPossibleValue(value: "doc");

		/// <summary>
		/// голосовое сообщение
		/// </summary>
		public static readonly DocMessageType AudioMessage = RegisterPossibleValue(value: "audio_message");

		/// <summary>
		/// Граффити
		/// </summary>
		public static readonly DocMessageType Graffiti = RegisterPossibleValue(value: "graffiti");
	}
}