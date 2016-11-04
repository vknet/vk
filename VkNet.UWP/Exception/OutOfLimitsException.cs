using System;
using System.Runtime.Serialization;

namespace VkNet.Exception
{
	/// <summary>
	/// 103 - Выход за пределы
	/// </summary>
	/// <seealso cref="VkNet.Exception.VkApiException" />
	[DataContract]
    public class OutOfLimitsException : VkApiException
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public OutOfLimitsException(string message) : base(message)
        {
        }
    }
}