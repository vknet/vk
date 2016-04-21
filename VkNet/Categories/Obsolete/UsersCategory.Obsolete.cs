using System;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using VkNet.Model;
using VkNet.Model.RequestParams;
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

		/// <summary>
		/// Возвращает список пользователей в соответствии с заданным критерием поиска.
		/// </summary>
		/// <param name="itemsCount">Общее количество пользователей, удовлетворяющих условиям запроса.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов пользователей, найденных в соответствии с заданными критериями.
		/// </returns>
		/// <exception cref="ArgumentException">Query can not be <c>null</c> or empty.</exception>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/users.search" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		[Obsolete("Метод устарел. Используйте вместо него Search(UserSearchParams @params)")]
		public ReadOnlyCollection<User> Search(out int itemsCount, UserSearchParams @params)
		{
			var response = Search(@params);

			itemsCount = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}

	}
}