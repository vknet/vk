using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IStreamingCategory" />
public partial class StreamingCategory
{
	/// <inheritdoc />
	public Task<StreamingServerUrl> GetServerUrlAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetServerUrl, token);

	/// <inheritdoc />
	public Task<StreamingSettings> GetSettingsAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetSettings, token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<StreamingStats>> GetStatsAsync(string type,
																string interval,
																DateTime? startTime = null,
																DateTime? endTime = null,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetStats(type, interval, startTime, endTime), token);

	/// <inheritdoc />
	public Task<bool> SetSettingsAsync(MonthlyLimit monthlyTier,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetSettings(monthlyTier), token);

	/// <inheritdoc />
	public Task<string> GetStemAsync(string word,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetStem(word), token);
}