using System;

namespace VkToolkit.Model
{
    public class Attachment
    {
        public Type Type { get; set; }
        internal Audio Audio;
        internal Photo Photo;
        internal Video Video;

        public object Instance
        {
            get
            {
                if (Type == typeof(Audio))
                    return Audio;
                if (Type == typeof(Photo))
                    return Photo;
                if (Type == typeof(Video))
                    return Video;

                return null;
            }
        }
    }
}