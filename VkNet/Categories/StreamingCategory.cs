using System;
using System.Collections.ObjectModel;
using System.Threading;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class StreamingCategory : IStreamingCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <inheritdoc />
		/// <param name="api">
		/// Api vk.com
		/// </param>
		public StreamingCategory(VkApi api)
		{
			_vk = api;
		}

		/// <inheritdoc />
		public StreamingServerUrl GetServerUrl()
		{
			return GetServerUrlAsync(CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public StreamingSettings GetSettings()
		{
			return GetSettingsAsync(CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public ReadOnlyCollection<StreamingStats> GetStats(string type,
															string interval,
															DateTime? startTime = null,
															DateTime? endTime = null)
		{
			return GetStatsAsync(type, interval, startTime, endTime, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool SetSettings(MonthlyLimit monthlyTier)
		{
			return SetSettingsAsync(monthlyTier, CancellationToken.None).GetAwaiter().GetResult();
		}
	}
}