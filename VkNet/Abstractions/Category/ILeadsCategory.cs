using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Model.RequestParams.Leads;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="ILeadsCategoryAsync" />
	public interface ILeadsCategory : ILeadsCategoryAsync
	{
		/// <inheritdoc cref="ILeadsCategoryAsync.CheckUserAsync" />
		Checked CheckUser(CheckUserParams checkUserParams);

		/// <inheritdoc cref="ILeadsCategoryAsync.CompleteAsync" />
		LeadsComplete Complete(string vkSid, string secret, string comment);

		/// <inheritdoc cref="ILeadsCategoryAsync.GetStatsAsync" />
		Lead GetStats(ulong leadId, string secret, string dateStart, string dateEnd);

		/// <inheritdoc cref="ILeadsCategoryAsync.GetUsersAsync" />
		ReadOnlyCollection<Entry> GetUsers(GetUsersParams getUsersParams);

		/// <inheritdoc cref="ILeadsCategoryAsync.MetricHitAsync" />
		MetricHitResponse MetricHit(string data);

		/// <inheritdoc cref="ILeadsCategoryAsync.StartAsync" />
		Start Start(StartParams startParams);
	}
}