using System;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с документами (получение списка, загрузка, удаление и т.д.)
	/// </summary>
	public partial class DocsCategory
	{
		/// <summary>
		/// Возвращает расширенную информацию о документах пользователя или сообщества.
		/// </summary>
		/// <param name="totalCount">Общее количество документов.</param>
		/// <param name="count">Количество документов, информацию о которых нужно вернуть. По умолчанию — все документы.</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества документов. Положительное число.</param>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежат документы. Целое число, по умолчанию идентификатор текущего пользователя.</param>
		/// <param name="filter">Фильтр по типу документа.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов документов.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/docs.get
		/// </remarks>
		[Obsolete("Данный метод устарел. Используйте Get(int? count = null, int? offset = null, long? ownerId = null, DocFilter? filter = null)")]
		public ReadOnlyCollection<Document> Get(out int totalCount, int? count = null, int? offset = null, long? ownerId = null, DocFilter? filter = null)
		{
			var response = Get(count, offset, ownerId, filter);

			totalCount = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}

	}
}