using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class StreamingCategory
{
	/// <inheritdoc />
	public Task<StreamingServerUrl> GetServerUrlAsync() => TypeHelper.TryInvokeMethodAsync(func: GetServerUrl);

	/// <inheritdoc />
	public Task<StreamingSettings> GetSettingsAsync() => TypeHelper.TryInvokeMethodAsync(func: GetSettings);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<StreamingStats>> GetStatsAsync(string type
																, string interval
																, DateTime? startTime = null
																, DateTime? endTime = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetStats(type, interval, startTime, endTime));

	/// <inheritdoc />
	public Task<bool> SetSettingsAsync(MonthlyLimit monthlyTier) =>
		TypeHelper.TryInvokeMethodAsync(func: () => SetSettings(monthlyTier: monthlyTier));

	/// <inheritdoc />
	public Task<string> GetStemAsync(string word) => TypeHelper.TryInvokeMethodAsync(func: () => GetStem(word: word));
}