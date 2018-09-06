using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams.Leads;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class LeadsCategory
	{
		/// <inheritdoc />
		public Task<Checked> CheckUserAsync(CheckUserParams checkUserParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => CheckUser(checkUserParams: checkUserParams));
		}

		/// <inheritdoc />
		public Task<LeadsComplete> CompleteAsync(string vkSid, string secret, string comment)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Complete(vkSid: vkSid, secret: secret, comment: comment));
		}

		/// <inheritdoc />
		public Task<Lead> GetStatsAsync(ulong leadId, string secret, string dateStart, string dateEnd)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				GetStats(leadId: leadId, secret: secret, dateStart: dateStart, dateEnd: dateEnd));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<Entry>> GetUsersAsync(GetUsersParams getUsersParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetUsers(getUsersParams: getUsersParams));
		}

		/// <inheritdoc />
		public Task<MetricHitResponse> MetricHitAsync(string data)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => MetricHit(data: data));
		}

		/// <inheritdoc />
		public Task<Start> StartAsync(StartParams startParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Start(startParams: startParams));
		}
	}
}