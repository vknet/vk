using System;

namespace VkToolkit.Model
{
    public class Attachment
    {
        public Type Type { get; set; }
        internal Audio Audio;
        internal Photo Photo;

        public object Instance
        {
            get
            {
                if (Type == typeof(Audio))
                    return Audio;
                if (Type == typeof(Photo))
                    return Photo;

                return null;
            }
        }
    }
}