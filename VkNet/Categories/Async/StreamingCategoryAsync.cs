using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class StreamingCategory
	{
		/// <inheritdoc/>
		public async Task<StreamingServerUrl> GetServerUrlAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Streaming.GetServerUrl());
		}

		/// <inheritdoc/>
		public async Task<StreamingSettings> GetSettingsAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Streaming.GetSettings());
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<StreamingStats>> GetStatsAsync(string type, string interval, DateTime? startTime = null, DateTime? endTime = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Streaming.GetStats(type, interval, startTime, endTime));
		}

		/// <inheritdoc/>
		public async Task<bool> SetSettingsAsync(MonthlyLimit monthlyTier)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Streaming.SetSettings(monthlyTier));
		}
	}
}