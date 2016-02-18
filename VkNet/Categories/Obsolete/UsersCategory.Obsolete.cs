using System;
using JetBrains.Annotations;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <summary>
    /// Методы для работы с информацией о пользователях.
    /// </summary>
    public partial class UsersCategory
    {
        /// <summary>
        /// Получает настройки текущего пользователя в данном приложении. .
        /// </summary>
        /// <param name="uid">Идентификатор пользователя, информацию о настройках которого необходимо получить.</param>
        /// <returns>После успешного выполнения возвращает битовую маску настроек текущего пользователя в данном приложении.
        ///
        /// Пример:
        /// Если Вы хотите получить права на Доступ к друзьям и Доступ к статусам пользователя, то Ваша битовая маска будет
        /// равна: 2 + 1024 = 1026.
        /// Если, имея битовую маску 1026, Вы хотите проверить, имеет ли она доступ к друзьям — Вы можете сделать 1026 &amp; 2.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/getUserSettings"/>.
        /// </remarks>
        [Pure]
        [Obsolete("Метод устарел. Используйте вместо него account.getAppPermissions")]
        [ApiVersion("5.44")]
        public int GetUserSettings(long uid)
        {
            throw new System.Exception("Метод устарел. Используйте вместо него account.getAppPermissions");
        }

    }
}