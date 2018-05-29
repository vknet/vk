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
		public async Task<Checked> CheckUserAsync(CheckUserParams checkUserParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Leads.CheckUser(checkUserParams: checkUserParams));
		}

		/// <inheritdoc />
		public async Task<LeadsComplete> CompleteAsync(string vkSid, string secret, string comment)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Leads.Complete(vkSid: vkSid, secret: secret, comment: comment));
		}

		/// <inheritdoc />
		public async Task<Lead> GetStatsAsync(ulong leadId, string secret, string dateStart, string dateEnd)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Leads.GetStats(leadId: leadId, secret: secret, dateStart: dateStart, dateEnd: dateEnd));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Entry>> GetUsersAsync(GetUsersParams getUsersParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Leads.GetUsers(getUsersParams: getUsersParams));
		}

		/// <inheritdoc />
		public async Task<MetricHitResponse> MetricHitAsync(string data)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Leads.MetricHit(data: data));
		}

		/// <inheritdoc />
		public async Task<Start> StartAsync(StartParams start)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Leads.Start(startParams: start));
		}
	}
}