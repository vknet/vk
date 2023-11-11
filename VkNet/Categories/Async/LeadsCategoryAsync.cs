using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="ILeadsCategory" />
public partial class LeadsCategory
{
	/// <inheritdoc />
	public Task<Checked> CheckUserAsync(CheckUserParams checkUserParams,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => CheckUser(checkUserParams), token);

	/// <inheritdoc />
	public Task<LeadsComplete> CompleteAsync(string vkSid,
											string secret,
											string comment,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Complete(vkSid, secret, comment), token);

	/// <inheritdoc />
	public Task<Lead> GetStatsAsync(ulong leadId,
									string secret,
									string dateStart,
									string dateEnd,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetStats(leadId, secret, dateStart, dateEnd), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Entry>> GetUsersAsync(GetUsersParams getUsersParams,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetUsers(getUsersParams), token);

	/// <inheritdoc />
	public Task<MetricHitResponse> MetricHitAsync(string data,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			MetricHit(data), token);

	/// <inheritdoc />
	public Task<Start> StartAsync(StartParams startParams,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Start(startParams), token);
}