namespace VkNet.Exception
{
    using System;

    /// <summary>
    /// Исключение, выбрасываемое при исчерпании лимита публикации постов в день
    /// </summary>
    [Serializable]
    public class PostLimitException : VkApiException
    {
        public PostLimitException(string message)
            : base(message)
        {
        }
    }
}