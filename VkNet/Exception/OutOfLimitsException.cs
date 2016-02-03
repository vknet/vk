using System;

namespace VkNet.Exception
{
    /// <summary>
    /// 103 - Out of limits
    /// </summary>
    /// <seealso cref="VkNet.Exception.VkApiException" />
    [Serializable]
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