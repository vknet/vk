using System;

namespace VkToolkit.Model
{
    public class Attachment
    {
        public Type Type { get; set; }
        internal Audio Audio;
        internal Photo Photo;
        internal Video Video;
        internal Document Document;
        internal Note Note;

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
                if (Type == typeof(Document))
                    return Document;
                if (Type == typeof(Note))
                    return Note;

                return null;
            }
        }
    }
}