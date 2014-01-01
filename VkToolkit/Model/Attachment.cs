namespace VkToolkit.Model
{
    using System;

    using VkToolkit.Exception;
    using VkToolkit.Utils;

    /// <summary>
    /// Информация о медиавложении в записи.
    /// См. описание <see cref="http://vk.com/dev/attachments_w"/>. 
    /// </summary>
    public class Attachment
    {
        #region Поля

        /// <summary>
        /// Фотография из альбома или фотография, загруженная напрямую с компьютера пользователя.
        /// </summary>
        internal Photo Photo;

        /// <summary>
        /// Видеозапись.
        /// </summary>
        internal Video Video;

        /// <summary>
        /// Аудиозапись.
        /// </summary>
        internal Audio Audio;

        /// <summary>
        /// Документ.
        /// </summary>
        internal Document Document;

        /// <summary>
        /// Документ.
        /// </summary>
        internal Graffiti Graffiti;

        /// <summary>
        /// Ссылка на Web-страницу.
        /// </summary>
        internal Link Link;

        /// <summary>
        /// Заметка.
        /// </summary>
        internal Note Note;

        /// <summary>
        /// Контент приложения.
        /// </summary>
        internal ApplicationContent ApplicationContent;

        /// <summary>
        /// Опрос.
        /// </summary>
        internal Poll Poll;

        /// <summary>
        /// Wiki страница.
        /// </summary>
        internal Page Page;

        /// <summary>
        /// Альбом с фотографиями.
        /// </summary>
        internal Album Album;

        #endregion

        /// <summary>
        /// Экземпляр самого прикрепления.
        /// </summary>
        public object Instance
        {
            get
            {
                if (Type == typeof(Photo))
                    return Photo;
                if (Type == typeof(Video))
                    return Video;
                if (Type == typeof(Audio))
                    return Audio;
                if (Type == typeof(Document))
                    return Document;
                if (Type == typeof(Graffiti))
                    return Graffiti;
                if (Type == typeof(Link))
                    return Link;
                if (Type == typeof(Note))
                    return Note;
                if (Type == typeof(ApplicationContent))
                    return ApplicationContent;
                if (Type == typeof(Poll))
                    return Poll;
                if (Type == typeof(Page))
                    return Page;
                if (Type == typeof(Album))
                    return Album;

                return null;
            }
        }

        /// <summary>
        /// Информация о типе вложения.
        /// </summary>
        public Type Type { get; set; }

        #region Методы

        internal static Attachment FromJson(VkResponse response)
        {
            // TODO: Complete it later
            var attachment = new Attachment();

            string type = response["type"];
            switch (type)
            {
                case "photo":
                case "posted_photo":
                    attachment.Type = typeof(Photo);
                    attachment.Photo = response[type];
                    break;

                case "video":
                    attachment.Type = typeof(Video);
                    attachment.Video = response["video"];
                    break;

                case "audio":
                    attachment.Type = typeof(Audio);
                    attachment.Audio = response["audio"];
                    break;

                case "doc":
                    attachment.Type = typeof(Document);
                    attachment.Document = response["doc"];
                    break;

                case "graffiti":
                    attachment.Type = typeof(Graffiti);
                    attachment.Graffiti = response["graffiti"];
                    break;

                case "link":
                    attachment.Type = typeof(Link);
                    attachment.Link = response["link"];
                    break;

                case "note":
                    attachment.Type = typeof(Note);
                    attachment.Note = response["note"];
                    break;

                case "app":
                    attachment.Type = typeof(ApplicationContent);
                    attachment.ApplicationContent = response["app"];
                    break;

                case "poll":
                    attachment.Type = typeof(Poll);
                    attachment.Poll = response["poll"];
                    break;

                case "page":
                    attachment.Type = typeof(Page);
                    attachment.Page = response["page"];
                    break;

                case "album":
                    attachment.Type = typeof(Album);
                    attachment.Album = response["album"];
                    break;

                default:
                    throw new InvalidParamException("The type of attachment is not defined.");
            }

            return attachment;
        }

        #endregion
    }
}