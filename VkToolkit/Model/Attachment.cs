namespace VkToolkit.Model
{
    using System;

    using VkToolkit.Exception;
    using VkToolkit.Utils;

    /// <summary>
    /// Информация о приложенных к записи объектах. 
    /// TODO: Доделать.
    /// </summary>
    /// <remarks>
    /// Пока не поддерживаются:
    /// - graffiti - графити;
    /// - app – изображение, загруженное сторонним приложением;
    /// - poll – голосование.
    /// </remarks>
    public class Attachment
    {
        #region Поля

        /// <summary>
        /// Альбом с фотографиями.
        /// </summary>
        internal Album Album;

        /// <summary>
        /// Аудиозапись.
        /// </summary>
        internal Audio Audio;

        /// <summary>
        /// Документ.
        /// </summary>
        internal Document Document;

        /// <summary>
        /// Ссылка на Web-страницу.
        /// </summary>
        internal Link Link;

        /// <summary>
        /// Заметка.
        /// </summary>
        internal Note Note;

        /// <summary>
        /// Wiki страница.
        /// </summary>
        internal Page Page;

        /// <summary>
        /// Фотография из альбома или фотография, загруженная напрямую с компьютера пользователя.
        /// </summary>
        internal Photo Photo;

        /// <summary>
        /// Видеозапись.
        /// </summary>
        internal Video Video;

        #endregion

        /// <summary>
        /// Экземпляр самого прикрепления.
        /// </summary>
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
                if (Type == typeof(Link))
                    return Link;
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
                case "audio":
                    attachment.Type = typeof(Audio);
                    attachment.Audio = response["audio"];
                    break;

                case "photo":
                    attachment.Type = typeof(Photo);
                    attachment.Photo = response["photo"];
                    break;

                case "posted_photo":
                    attachment.Type = typeof(Photo);
                    attachment.Photo = response["posted_photo"];
                    break;

                case "video":
                    attachment.Type = typeof(Video);
                    attachment.Video = response["video"];
                    break;

                case "doc":
                    attachment.Type = typeof(Document);
                    attachment.Document = response["doc"];
                    break;

                case "graffiti":
                    // TODO:
                    throw new NotImplementedException();

                case "link":
                    attachment.Type = typeof(Link);
                    attachment.Link = response["link"];
                    break;

                case "note":
                    attachment.Type = typeof(Note);
                    attachment.Note = response["note"];
                    break;

                case "app":
                    // TODO:
                    throw new NotImplementedException();

                case "poll":
                    // TODO:
                    throw new NotImplementedException();

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