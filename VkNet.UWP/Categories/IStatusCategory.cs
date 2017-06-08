﻿namespace VkNet.Categories
{
    using Model;

    /// <summary>
	/// Методы для работы со статусом пользователя или сообщества.
	/// </summary>
    public interface IStatusCategory
    {
        /// <summary>
        /// Получает статус пользователя или сообщества.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя или сообщества, информацию о статусе которого нужно получить.</param>
        /// <param name="groupId">Идентификатор сообщества, статус которого необходимо получить. положительное число (Положительное число).</param>
        /// <returns>
        /// В случае успеха возвращается статус пользователдя или сообщества.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Status
        /// Страница документации ВКонтакте http://vk.com/dev/status.get
        /// </remarks>
        Status Get(long userId, long? groupId = null);

        /// <summary>
        /// Устанавливает новый статус текущему пользователю. 
        /// </summary>
        /// <param name="text">
        /// Текст статуса, который необходимо установить текущему пользователю. Если параметр 
        /// равен пустой строке, то статус текущего пользователя будет очищен.
        /// </param>
        /// <param name="groupId"> Идентификатор сообщества, в котором будет установлен статус. По умолчанию статус устанавливается текущему пользователю. </param>
        /// <returns>Возвращает true, если статус был успешно установлен, false в противном случае.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Status
        /// Страница документации ВКонтакте http://vk.com/dev/status.set
        /// </remarks>
        bool Set(string text, long? groupId = null);
    }
}