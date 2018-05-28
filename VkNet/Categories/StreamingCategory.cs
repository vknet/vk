using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class StreamingCategory : IStreamingCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly VkApi _vk;

		/// <inheritdoc/>
		/// <param name = "api">
		/// Api vk.com
		/// </param>
		public StreamingCategory(VkApi api)
		{
			_vk = api;
		}

		/// <inheritdoc/>
		public StreamingServerUrl GetServerUrl()
		{
			return _vk.Call<StreamingServerUrl>("streaming.getServerUrl", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public StreamingSettings GetSettings()
		{
			return _vk.Call<StreamingSettings>("streaming.getSettings", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<StreamingStats> GetStats(string type, string interval, DateTime? startTime = null,
			DateTime? endTime = null)
		{
			var result = _vk.Call<ReadOnlyCollection<StreamingStats>>("streaming.getStats",
				new VkParameters
				{
					{"type", type},
					{"interval", interval},
					{"start_time", startTime},
					{"end_time", endTime}
				});

			return result;
		}

		/// <inheritdoc/>
		public bool SetSettings(string monthlyTier)
		{
			return _vk.Call<bool>("streaming.setSettings", new VkParameters {{"monthly_tier", monthlyTier}});
		}
	}
}