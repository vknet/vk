using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class StreamingCategory
	{
		/// <inheritdoc />
		public Task<StreamingServerUrl> GetServerUrlAsync(CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<StreamingServerUrl>("streaming.getServerUrl", VkParameters.Empty, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<StreamingSettings> GetSettingsAsync(CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<StreamingSettings>("streaming.getSettings", VkParameters.Empty, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<StreamingStats>> GetStatsAsync(string type,
																	string interval,
																	DateTime? startTime = null,
																	DateTime? endTime = null,
																	CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<ReadOnlyCollection<StreamingStats>>("streaming.getStats",
				new VkParameters
				{
					{ "type", type },
					{ "interval", interval },
					{ "start_time", startTime },
					{ "end_time", endTime }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> SetSettingsAsync(MonthlyLimit monthlyTier, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("streaming.setSettings",
				new VkParameters
				{
					{ "monthly_tier", monthlyTier }
				},
				cancellationToken: cancellationToken);
		}
	}
}