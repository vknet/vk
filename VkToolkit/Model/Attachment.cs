using System;

namespace VkToolkit.Model
{
    public class Attachment
    {
        public Type Type { get; set; }
        internal Audio Audio;

        public object GetAttachment()
        {
            if (Type == typeof(Audio))
                return Audio;

            return null;
        }
    }
}