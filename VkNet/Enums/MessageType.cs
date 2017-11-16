using System.Runtime.Serialization;

namespace VkNet.Enums
{
	/// <summary>
	/// Тип сообщения.
	/// </summary>
	[DataContract]
	public enum MessageType
    {
        /// <summary>
        /// Полученное сообщение.
        /// </summary>
        Received = 0,

        /// <summary>
        /// Отправленное сообщение.
        /// </summary>
        Sended = 1
    }
}