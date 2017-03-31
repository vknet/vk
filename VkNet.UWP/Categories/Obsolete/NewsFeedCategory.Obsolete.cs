using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	public partial class NewsFeedCategory
	{
		/// <summary>
		/// Возвращает список записей пользователей на своих стенах, в которых упоминается указанный пользователь.
		/// </summary>
		/// <param name="total">Количество.</param>
		/// <param name="ownerId">Идентификатор группы или сообщества. по умолчанию идентификатор текущего пользователя</param>
		/// <param name="startTime">Время в формате unixtime начиная с которого следует получать упоминания о пользователе.</param>
		/// <param name="endTime">Время, в формате unixtime, до которого следует получать упоминания о пользователе.</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества новостей. По умолчанию 0.</param>
		/// <param name="count">Количество возвращаемых записей. Если параметр не задан, то считается, что он равен 20. Максимальное значение параметра 50.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.getMentions
		/// </remarks>
		[Obsolete("Устаревшая версия API. Используйте метод GetMentions(long? ownerId = null, DateTime? startTime = null, DateTime? endTime = null, long? offset = null, long? count = null)")]
		public ReadOnlyCollection<Mention> GetMentions(out int total, long? ownerId = null, DateTime? startTime = null, DateTime? endTime = null, long? offset = null, long? count = null)
		{
			var response = GetMentions(ownerId, startTime, endTime, offset, count);

			total = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}

		/// <summary>
		/// Возвращает пользовательские списки новостей.
		/// </summary>
		/// <param name="total">Количество пользовательских списков.</param>
		/// <param name="listIds">Идентификаторы списков.</param>
		/// <param name="extended"><c>true</c> — вернуть дополнительную информацию о списке (значения source_ids и no_reposts).</param>
		/// <returns>
		/// Метод возвращает список объектов пользовательских списков.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.getLists
		/// </remarks>
		[Obsolete("Устаревшая версия API. Используйте метод GetLists(IEnumerable<long> listIds, bool? extended = null)")]
		public ReadOnlyCollection<NewsUserListItem> GetLists(out int total, IEnumerable<long> listIds, bool? extended = null)
		{
			var response = GetLists(listIds, extended);

			total = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}

	}
}