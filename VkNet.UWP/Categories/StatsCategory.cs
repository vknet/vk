using System;
using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы со статистикой.
	/// </summary>
	public class StatsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		readonly VkApi _vk;

		/// <summary>
		/// Методы для работы со статистикой.
		/// </summary>
		/// <param name="vk">API.</param>
		internal StatsCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает статистику сообщества или приложения.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества.</param>
		/// <param name="appId">Идентификатор приложения.</param>
		/// <param name="dateFrom">Начальная дата выводимой статистики в формате YYYY-MM-DD.</param>
		/// <param name="dateTo">Конечная дата выводимой статистики в формате YYYY-MM-DD.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/stats.get" />.
		/// </remarks>
		[ApiVersion("5.44")]
		private ReadOnlyCollection<StatsPeriod> Get(DateTime dateFrom, DateTime? dateTo = null, long? groupId = null, long? appId = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "app_id", appId },
				{ "date_from", dateFrom.ToString("yyyy-MM-dd") }
			};
			if (dateTo != null)
			{
				parameters.Add("date_to", dateTo.Value.ToString("yyyy-MM-dd"));
			}
			var result = _vk.Call("stats.get", parameters);
			return result.ToReadOnlyCollectionOf<StatsPeriod>(x => x);
		}

		/// <summary>
		/// Возвращает статистику сообщества или приложения.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества.</param>
		/// <param name="dateFrom">The date from.</param>
		/// <param name="dateTo">The date to.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/stats.get" />.
		/// </remarks>
		public ReadOnlyCollection<StatsPeriod> GetByGroup(long groupId, DateTime dateFrom, DateTime? dateTo = null)
		{
			return Get(dateFrom, dateTo, groupId);
		}

		/// <summary>
		/// Возвращает статистику сообщества или приложения.
		/// </summary>
		/// <param name="appId">Идентификатор приложения.</param>
		/// <param name="dateFrom">The date from.</param>
		/// <param name="dateTo">The date to.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/stats.get" />.
		/// </remarks>
		public ReadOnlyCollection<StatsPeriod> GetByApp(long appId, DateTime dateFrom, DateTime? dateTo = null)
		{
			return Get(dateFrom, dateTo, null, appId);
		}

		/// <summary>
		/// Добавляет данные о текущем сеансе в статистику посещаемости приложения..
		/// </summary>
		/// <returns>
		/// В случае успешной обработки данных метод вернет <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/stats.trackVisitor" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool TrackVisitor()
		{
			return _vk.Call("stats.trackVisitor", VkParameters.Empty);
		}

		/// <summary>
		/// Возвращает статистику для записи на стене.
		/// </summary>
		/// <param name="ownerId">Идентификатор сообщества — владельца записи. Указывается со знаком «минус».</param>
		/// <param name="postId">Идентификатор записи. Обратите внимание — данные по статистике доступны только для 300 последних(самых свежих) записей на стене сообщества.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Необходимо входить в число руководителей этого сообщества.
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/stats.getPostReach" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public PostReach GetPostReach(long ownerId, long postId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => postId);
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "post_id", postId }
			};
			return _vk.Call("stats.getPostReach", parameters);
		}

	}
}