using System;

namespace VkNet.Model.Attachments
{
    /// <summary>
    /// Строковая ссылка
    /// </summary>
    [Serializable]
    public class StringLink: MediaAttachment
    {
        /// <inheritdoc />
        static StringLink()
        {
            RegisterType(typeof(string), "string");
        }

        /// <summary>
        /// Ссылка
        /// </summary>
        public string Link { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Link;
        }
    }
}