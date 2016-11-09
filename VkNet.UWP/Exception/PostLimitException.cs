using System.Runtime.Serialization;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, выбрасываемое при исчерпании лимита публикации постов в день
    /// </summary>
    [DataContract]
    public class PostLimitException : VkApiException
    {
        public PostLimitException(string message)
            : base(message)
        {
        }
    }
}