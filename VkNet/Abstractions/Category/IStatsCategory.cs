using System.Collections.ObjectModel;
using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы со статистикой.
/// </summary>
public interface IStatsCategory : IStatsCategoryAsync
{
	/// <inheritdoc cref="IStatsCategoryAsync.GetAsync"/>
	ReadOnlyCollection<StatsPeriod> Get(StatsGetParams getParams);

	/// <inheritdoc cref="IStatsCategoryAsync.TrackVisitorAsync"/>
	bool TrackVisitor();

	/// <inheritdoc cref="IStatsCategoryAsync.GetPostReachAsync"/>
	PostReach GetPostReach(long ownerId, long postId);
}