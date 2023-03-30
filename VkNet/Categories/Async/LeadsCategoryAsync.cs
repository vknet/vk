using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams.Leads;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class LeadsCategory
{
	/// <inheritdoc />
	public Task<Checked> CheckUserAsync(CheckUserParams checkUserParams,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => CheckUser(checkUserParams));

	/// <inheritdoc />
	public Task<LeadsComplete> CompleteAsync(string vkSid,
											string secret,
											string comment,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Complete(vkSid, secret, comment));

	/// <inheritdoc />
	public Task<Lead> GetStatsAsync(ulong leadId,
									string secret,
									string dateStart,
									string dateEnd,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetStats(leadId, secret, dateStart, dateEnd));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Entry>> GetUsersAsync(GetUsersParams getUsersParams,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetUsers(getUsersParams));

	/// <inheritdoc />
	public Task<MetricHitResponse> MetricHitAsync(string data,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			MetricHit(data));

	/// <inheritdoc />
	public Task<Start> StartAsync(StartParams startParams,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Start(startParams));
}