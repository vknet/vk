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
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Leads.CheckUser(checkUserParams: checkUserParams));
		}

		/// <inheritdoc />
		public Task<LeadsComplete> CompleteAsync(string vkSid, string secret, string comment)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Leads.Complete(vkSid: vkSid, secret: secret, comment: comment));
		}

		/// <inheritdoc />
		public Task<Lead> GetStatsAsync(ulong leadId, string secret, string dateStart, string dateEnd)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Leads.GetStats(leadId: leadId, secret: secret, dateStart: dateStart, dateEnd: dateEnd));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<Entry>> GetUsersAsync(GetUsersParams getUsersParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Leads.GetUsers(getUsersParams: getUsersParams));
		}

		/// <inheritdoc />
		public Task<MetricHitResponse> MetricHitAsync(string data)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Leads.MetricHit(data: data));
		}

		/// <inheritdoc />
		public Task<Start> StartAsync(StartParams start)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Leads.Start(startParams: start));
		}
	}
}