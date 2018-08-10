using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class SecureCategory : ISecureCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <inheritdoc/>
		/// <param name = "api">
		/// Api vk.com
		/// </param>
		public SecureCategory(IVkApiInvoke api)
		{
			_vk = api;
		}

		/// <inheritdoc/>
		public object AddAppEvent(ulong userId, ulong activityId, ulong? value = null)
		{
			return _vk.Call<object>("secure.addAppEvent",
				new VkParameters { { "user_id", userId }, { "activity_id", activityId }, { "value", value } });
		}

		/// <inheritdoc/>
		public object CheckToken(string token, string ip)
		{
			return _vk.Call<object>("secure.checkToken", new VkParameters { { "token", token }, { "ip", ip } });
		}

		/// <inheritdoc/>
		public object GetAppBalance()
		{
			return _vk.Call<object>("secure.getAppBalance", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public IEnumerable<object> GetSmsHistory(ulong? userId = null, ulong? dateFrom = null, ulong? dateTo = null, ulong? limit = null)
		{
			return _vk.Call<IEnumerable<object>>("secure.getSMSHistory",
				new VkParameters { { "user_id", userId }, { "date_from", dateFrom }, { "date_to", dateTo }, { "limit", limit } });
		}

		/// <inheritdoc/>
		public IEnumerable<object> GetTransactionsHistory()
		{
			return _vk.Call<IEnumerable<object>>("secure.getTransactionsHistory", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public object GetUserLevel(IEnumerable<long> userIds)
		{
			return _vk.Call<object>("secure.getUserLevel", new VkParameters { { "user_ids", userIds } });
		}

		/// <inheritdoc/>
		public object SendNotification(string message, IEnumerable<ulong> userIds = null, ulong? userId = null)
		{
			return _vk.Call<object>("secure.sendNotification",
				new VkParameters { { "message", message }, { "user_ids", userIds }, { "user_id", userId } });
		}

		/// <inheritdoc/>
		public bool SendSmsNotification(ulong userId, string message)
		{
			return _vk.Call<bool>("secure.sendSMSNotification", new VkParameters { { "user_id", userId }, { "message", message } });
		}

		/// <inheritdoc/>
		public bool SetCounter(IEnumerable<string> counters, ulong? userId = null, long? counter = null, bool? increment = null)
		{
			return _vk.Call<bool>("secure.setCounter",
				new VkParameters { { "counters", counters }, { "user_id", userId }, { "counter", counter }, { "increment", increment } });
		}

		/// <inheritdoc/>
		public bool SetUserLevel(IEnumerable<string> levels, ulong? userId = null, ulong? level = null)
		{
			return _vk.Call<bool>("secure.setUserLevel",
				new VkParameters { { "levels", levels }, { "user_id", userId }, { "level", level } });
		}
	}
}