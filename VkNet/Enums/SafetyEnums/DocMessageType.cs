namespace VkNet.Enums.SafetyEnums
{
    /// <summary>
    /// тип документа
    /// </summary>
    public class DocMessageType: SafetyEnum<DocMessageType>
    {
        /// <summary>
        /// DocMessageType
        /// </summary>
        public static readonly DocMessageType Doc = RegisterPossibleValue("doc");
        
        /// <summary>
        /// голосовое сообщение
        /// </summary>
        public static readonly DocMessageType AudioMessage = RegisterPossibleValue("audio_message");
    }
}