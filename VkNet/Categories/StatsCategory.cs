using System;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы со статистикой.
	/// </summary>
	public partial class StatsCategory : IStatsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы со статистикой.
		/// </summary>
		/// <param name="vk"> API. </param>
		public StatsCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public ReadOnlyCollection<StatsPeriod> GetByGroup(long groupId, DateTime dateFrom, DateTime? dateTo = null)
		{
			return Get(dateFrom: dateFrom, dateTo: dateTo, groupId: groupId);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<StatsPeriod> GetByApp(long appId, DateTime dateFrom, DateTime? dateTo = null)
		{
			return Get(dateFrom: dateFrom, dateTo: dateTo, groupId: null, appId: appId);
		}

		/// <inheritdoc />
		public bool TrackVisitor()
		{
			return _vk.Call(methodName: "stats.trackVisitor", parameters: VkParameters.Empty);
		}

		/// <inheritdoc />
		public PostReach GetPostReach(long ownerId, long postId)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => postId);

			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "post_id", postId }
			};

			return _vk.Call(methodName: "stats.getPostReach", parameters: parameters);
		}

		/// <summary>
		/// Возвращает статистику сообщества или приложения.
		/// </summary>
		/// <param name="groupId"> Идентификатор сообщества. </param>
		/// <param name="appId"> Идентификатор приложения. </param>
		/// <param name="dateFrom">
		/// Начальная дата выводимой статистики в формате
		/// YYYY-MM-DD.
		/// </param>
		/// <param name="dateTo"> Конечная дата выводимой статистики в формате YYYY-MM-DD. </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/stats.get
		/// </remarks>
		private ReadOnlyCollection<StatsPeriod> Get(DateTime dateFrom, DateTime? dateTo = null, long? groupId = null, long? appId = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "app_id", appId },
				{ "date_from", dateFrom.ToString(format: "yyyy-MM-dd") }
			};

			if (dateTo != null)
			{
				parameters.Add(name: "date_to", value: dateTo.Value.ToString(format: "yyyy-MM-dd"));
			}

			var result = _vk.Call(methodName: "stats.get", parameters: parameters);

			return result.ToReadOnlyCollectionOf<StatsPeriod>(selector: x => x);
		}
	}
}