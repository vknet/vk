using System;
using System.Collections.ObjectModel;
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
		public Task<StreamingServerUrl> GetServerUrlAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetServerUrl());
		}

		/// <inheritdoc />
		public Task<StreamingSettings> GetSettingsAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetSettings());
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<StreamingStats>> GetStatsAsync(string type
																			, string interval
																			, DateTime? startTime = null
																			, DateTime? endTime = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetStats(type: type, interval: interval, startTime: startTime, endTime: endTime));
		}

		/// <inheritdoc />
		public Task<bool> SetSettingsAsync(MonthlyLimit monthlyTier)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>SetSettings(monthlyTier: monthlyTier));
		}

		/// <inheritdoc />
		public Task<string> GetStemAsync(string word)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetStem(word: word));
		}
	}
}