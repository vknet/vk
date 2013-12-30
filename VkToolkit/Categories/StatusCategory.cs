using System;
using VkToolkit.Model;

namespace VkToolkit.Categories
{
    using VkToolkit.Enums;
    using VkToolkit.Utils;

    /// <summary>
    /// Методы для работы со статусом пользователя или сообщества.
    /// </summary>
    public class StatusCategory
    {
        private readonly VkApi _vk;

        public StatusCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Получает статус пользователя или сообщества.
        /// </summary>
        /// <param name="uid">
        /// Идентификатор пользователя или сообщества, информацию о статусе которого нужно получить.
        /// </param>
        /// <returns>
        /// В случае успеха возвращается статус пользователдя или сообщества.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Status"/>. 
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/methods#/dev/status.get"/>.
        /// </remarks>
        public Status Get(long uid)
        {
            var parameters = new VkParameters { { "uid", uid } };

            return _vk.Call("status.get", parameters);
        }

        /// <summary>
        /// Устанавливает новый статус текущему пользователю. 
        /// </summary>
        /// <param name="text">
        /// Текст статуса, который необходимо установить текущему пользователю. Если параметр 
        /// равен пустой строке, то статус текущего пользователя будет очищен.
        /// </param>
        /// <param name="audio">
        /// Текущая аудиозапись, которую необходимо транслировать в статус, задается в формате oid_aid (
        /// идентификатор владельца и идентификатор аудиозаписи, разделенные знаком подчеркивания). 
        /// Для успешной трансляции необходимо, чтобы она была включена пользователем, в противном случае будет возвращена 
        /// ошибка 221 ("User disabled track name broadcast"). При указании параметра audio параметр text игнорируется.
        /// </param>
        /// <returns>Возвращает true, если статус был успешно установлен, false в противном случае.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Status"/>. 
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/methods#/dev/status.set"/>.
        /// </remarks>
        public bool Set(string text, Audio audio = null)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            var parameters = new VkParameters();
            if (audio != null)
                parameters.Add("audio", string.Format("{0}_{1}", audio.OwnerId, audio.Id));
            else
                parameters.Add("text", text);

            return _vk.Call("status.set", parameters);
        }

        /// <summary>
        /// Устанавливает новый аудиозапись текущему пользователю. 
        /// </summary>
        /// <param name="audio">
        /// Текущая аудиозапись, которую необходимо транслировать в статус, задается в формате oid_aid (
        /// идентификатор владельца и идентификатор аудиозаписи, разделенные знаком подчеркивания). 
        /// Для успешной трансляции необходимо, чтобы она была включена пользователем, в противном случае будет возвращена 
        /// ошибка 221 ("User disabled track name broadcast"). При указании параметра audio параметр text игнорируется.
        /// </param>
        /// <returns>Возвращает true, если статус был успешно установлен, false в противном случае.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Status"/>. 
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/methods#/dev/status.set"/>.
        /// </remarks>
        public bool Set(Audio audio)
        {
            if (audio == null)
                throw new ArgumentNullException("audio");

            var parameters = new VkParameters
                {
                    { "audio", string.Format("{0}_{1}", audio.OwnerId, audio.Id) }
                };

            return _vk.Call("status.set", parameters);
        }
    }
}