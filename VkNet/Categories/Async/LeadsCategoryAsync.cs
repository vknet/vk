using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams.Leads;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class LeadsCategory
{
	/// <inheritdoc />
	public Task<Checked> CheckUserAsync(CheckUserParams checkUserParams) =>
		TypeHelper.TryInvokeMethodAsync(func: () => CheckUser(checkUserParams: checkUserParams));

	/// <inheritdoc />
	public Task<LeadsComplete> CompleteAsync(string vkSid, string secret, string comment) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Complete(vkSid, secret, comment));

	/// <inheritdoc />
	public Task<Lead> GetStatsAsync(ulong leadId, string secret, string dateStart, string dateEnd) => TypeHelper.TryInvokeMethodAsync(
		func: () =>
			GetStats(leadId, secret, dateStart, dateEnd));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Entry>> GetUsersAsync(GetUsersParams getUsersParams) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetUsers(getUsersParams: getUsersParams));

	/// <inheritdoc />
	public Task<MetricHitResponse> MetricHitAsync(string data) => TypeHelper.TryInvokeMethodAsync(func: () => MetricHit(data: data));

	/// <inheritdoc />
	public Task<Start> StartAsync(StartParams startParams) => TypeHelper.TryInvokeMethodAsync(func: () => Start(startParams: startParams));
}