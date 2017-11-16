using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VkNet.Enums.Filters;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <summary>
    /// Методы для работы со статусом пользователя или сообщества.
    /// </summary>
    public partial class StatusCategory
    {
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
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Status
        /// Страница документации ВКонтакте http://vk.com/dev/status.set
        /// </remarks>
        [Obsolete("Данный метод устарел. Пожалуйста используйте метод Audio.SetBroadcast")]
        public bool Set([NotNull] Audio audio)
        {
            _vk.Audio.SetBroadcast(string.Format("{0}_{1}", audio.OwnerId, audio.Id), new List<long>());
            return true;
        }
    }
}