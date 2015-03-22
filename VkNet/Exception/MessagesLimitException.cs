namespace VkNet.Exception
{
    using System;

    /// <summary>
    /// Исключение, выбрасываемое при исчерпании лимита публикации постов в день
    /// </summary>
    [Serializable]
    public class MessagesLimitException : VkApiException
    {
        public MessagesLimitException(string message)
            : base(message)
        {
        }
    }
}