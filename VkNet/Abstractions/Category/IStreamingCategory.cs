using System;
using System.Collections.ObjectModel;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IStreamingCategoryAsync"/>
	public interface IStreamingCategory : IStreamingCategoryAsync
	{
		/// <inheritdoc cref="IStreamingCategoryAsync.GetServerUrlAsync"/>
		StreamingServerUrl GetServerUrl();

		/// <inheritdoc cref="IStreamingCategoryAsync.GetSettingsAsync"/>
		StreamingSettings GetSettings();

		/// <inheritdoc cref="IStreamingCategoryAsync.GetStatsAsync"/>
		ReadOnlyCollection<StreamingStats> GetStats(string type, string interval, DateTime? startTime = null, DateTime? endTime = null);

		/// <inheritdoc cref="IStreamingCategoryAsync.SetSettingsAsync"/>
		bool SetSettings(MonthlyLimit monthlyTier);

		/// <inheritdoc cref="IStreamingCategoryAsync.GetStemAsync"/>
		string GetStem(string word);
	}
}