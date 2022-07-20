using System;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class StreamingCategory : IStreamingCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// api vk.com
		/// </summary>
		/// <param name="vk">
		/// Api vk.com
		/// </param>
		public StreamingCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public StreamingServerUrl GetServerUrl()
		{
			return _vk.Call<StreamingServerUrl>(methodName: "streaming.getServerUrl", parameters: VkParameters.Empty);
		}

		/// <inheritdoc />
		public StreamingSettings GetSettings()
		{
			return _vk.Call<StreamingSettings>(methodName: "streaming.getSettings", parameters: VkParameters.Empty);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<StreamingStats> GetStats(string type
															, string interval
															, DateTime? startTime = null
															, DateTime? endTime = null)
		{
			var result = _vk.Call<ReadOnlyCollection<StreamingStats>>(methodName: "streaming.getStats"
					, parameters: new VkParameters
					{
							{ "type", type }
							, { "interval", interval }
							, { "start_time", startTime }
							, { "end_time", endTime }
					});

			return result;
		}

		/// <inheritdoc />
		public bool SetSettings(MonthlyLimit monthlyTier)
		{
			return _vk.Call<bool>(methodName: "streaming.setSettings", parameters: new VkParameters { { "monthly_tier", monthlyTier } });
		}

		/// <inheritdoc />
		public string GetStem(string word)
		{
			return _vk.Call(methodName: "streaming.getStem", parameters: new VkParameters { { "word", word } })["stem"];
		}
	}
}