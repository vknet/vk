using System;

using VkToolkit.Exception;
using VkToolkit.Utils;

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
        internal Page Page;

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
                if (Type == typeof(Page))
                    return Page;

                return null;
            }
        }

        internal static Attachment FromJson(VkResponse attachment)
        {
            // TODO: Complete it later
            var result = new Attachment();

            string type = attachment["type"];
            switch (type)
            {
                case "audio":
                    result.Type = typeof(Audio);
                    result.Audio = attachment["audio"];
                    break;

                case "photo":
                    result.Type = typeof(Photo);
                    result.Photo = attachment["photo"];
                    break;

                case "posted_photo":
                    result.Type = typeof(Photo);
                    result.Photo = attachment["posted_photo"];
                    break;

                case "video":
                    result.Type = typeof(Video);
                    result.Video = attachment["video"];
                    break;

                case "doc":
                    result.Type = typeof(Document);
                    result.Document = attachment["doc"];
                    break;

                case "graffiti":
                    // TODO:
                    throw new NotImplementedException();

                case "link":
                    // TODO:
                    throw new NotImplementedException();

                case "note":
                    result.Type = typeof(Note);
                    result.Note = attachment["note"];
                    break;

                case "app":
                    // TODO:
                    throw new NotImplementedException();

                case "poll":
                    // TODO:
                    throw new NotImplementedException();

                case "page":
                    result.Type = typeof(Page);
                    result.Page = attachment["page"];
                    break;

                default:
                    throw new InvalidParamException("The type of attachment is not defined.");
            }

            return result;            
        }
    }
}