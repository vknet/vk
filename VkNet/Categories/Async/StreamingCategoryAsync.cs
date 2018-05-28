using System.Collections.Generic;
using System.Threading.Tasks;
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
		public async Task<object> GetSettingsAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Streaming.GetSettings());
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<object>> GetStatsAsync(string type, string interval, ulong? startTime = null, ulong? endTime = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Streaming.GetStats(type, interval, startTime, endTime));
		}

		/// <inheritdoc/>
		public async Task<bool> SetSettingsAsync(string monthlyTier)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Streaming.SetSettings(monthlyTier));
		}
	}
}