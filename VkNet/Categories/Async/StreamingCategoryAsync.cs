using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class StreamingCategory
{
	/// <inheritdoc />
	public Task<StreamingServerUrl> GetServerUrlAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetServerUrl);

	/// <inheritdoc />
	public Task<StreamingSettings> GetSettingsAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetSettings);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<StreamingStats>> GetStatsAsync(string type,
																string interval,
																DateTime? startTime = null,
																DateTime? endTime = null,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetStats(type, interval, startTime, endTime));

	/// <inheritdoc />
	public Task<bool> SetSettingsAsync(MonthlyLimit monthlyTier,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetSettings(monthlyTier));

	/// <inheritdoc />
	public Task<string> GetStemAsync(string word,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetStem(word));
}