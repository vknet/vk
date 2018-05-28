using System.Collections.Generic;
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
		public object GetSettings()
		{
			return _vk.Call<object>("streaming.getSettings", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public IEnumerable<object> GetStats(string type, string interval, ulong? startTime = null,
			ulong? endTime = null)
		{
			return _vk.Call<IEnumerable<object>>("streaming.getStats",
				new VkParameters
				{
					{"type", type},
					{"interval", interval},
					{"start_time", startTime},
					{"end_time", endTime}
				});
		}

		/// <inheritdoc/>
		public bool SetSettings(string monthlyTier)
		{
			return _vk.Call<bool>("streaming.setSettings", new VkParameters {{"monthly_tier", monthlyTier}});
		}
	}
}