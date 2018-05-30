using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams.Leads;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class LeadsCategory
	{
		/// <inheritdoc/>
		public async Task<Checked> CheckUserAsync(CheckUserParams checkUser)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Leads.CheckUser(checkUser));
		}

		/// <inheritdoc/>
		public async Task<LeadsComplete> CompleteAsync(string vkSid, string secret, string comment)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Leads.Complete(vkSid, secret, comment));
		}

		/// <inheritdoc/>
		public async Task<Lead> GetStatsAsync(ulong leadId, string secret, string dateStart, string dateEnd)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Leads.GetStats(leadId, secret, dateStart, dateEnd));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<Entry>> GetUsersAsync(GetUsersParams getUsers)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Leads.GetUsers(getUsers));
		}

		/// <inheritdoc/>
		public async Task<MetricHitResponse> MetricHitAsync(string data)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Leads.MetricHit(data));
		}

		/// <inheritdoc/>
		public async Task<Start> StartAsync(StartParams start)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Leads.Start(start));
		}
	}
}