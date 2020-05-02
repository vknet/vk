using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams.Leads;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class LeadsCategory : ILeadsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// api vk.com
		/// </summary>>
		/// <param name="vk">
		/// Api vk.com
		/// </param>
		public LeadsCategory(VkApi vk = null)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public Checked CheckUser(CheckUserParams checkUserParams)
		{
			var result = new VkParameters
			{
					{ "lead_id", checkUserParams.LeadId }
					, { "country", checkUserParams.Country }
					, { "test_result", checkUserParams.TestResult }
					, { "test_mode", checkUserParams.TestMode }
					, { "auto_start", checkUserParams.AutoStart }
					, { "age", checkUserParams.Age }
			};

			return _vk.Call<Checked>(methodName: "leads.checkUser", parameters: result);
		}

		/// <inheritdoc />
		public LeadsComplete Complete(string vkSid, string secret, string comment)
		{
			return _vk.Call<LeadsComplete>(methodName: "leads.complete"
					, parameters: new VkParameters
					{
							{ "vk_sid", vkSid }
							, { "secret", secret }
							, { "comment", comment }
					});
		}

		/// <inheritdoc />
		public Lead GetStats(ulong leadId, string secret, string dateStart, string dateEnd)
		{
			return _vk.Call<Lead>(methodName: "leads.getStats"
					, parameters: new VkParameters
					{
							{ "lead_id", leadId }
							, { "secret", secret }
							, { "date_start", dateStart }
							, { "date_end", dateEnd }
					});
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Entry> GetUsers(GetUsersParams getUsersParams)
		{
			var result = new VkParameters
			{
					{ "offer_id", getUsersParams.OfferId }
					, { "secret", getUsersParams.Secret }
					, { "offset", getUsersParams.Offset }
					, { "count", getUsersParams.Count }
					, { "status", getUsersParams.Status }
					, { "reverse", getUsersParams.Reverse }
			};

			return _vk.Call<ReadOnlyCollection<Entry>>(methodName: "leads.getUsers", parameters: result);
		}

		/// <inheritdoc />
		public MetricHitResponse MetricHit(string data)
		{
			return _vk.Call<MetricHitResponse>(methodName: "leads.metricHit"
					, parameters: new VkParameters
					{
							{ "data", data }
					});
		}

		/// <inheritdoc />
		public Start Start(StartParams startParams)
		{
			var result = new VkParameters
			{
					{ "lead_id", startParams.LeadId }
					, { "secret", startParams.Secret }
					, { "uid", startParams.Uid }
					, { "aid", startParams.Aid }
					, { "test_mode", startParams.TestMode }
					, { "force", startParams.Force }
			};

			return _vk.Call<Start>(methodName: "leads.start", parameters: result);
		}
	}
}