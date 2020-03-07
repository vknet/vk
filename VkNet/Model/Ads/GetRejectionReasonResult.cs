using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	public class GetRejectionReasonResult
	{
		/// <summary>
		/// Количество оставшихся методов;
		/// </summary>
		[JsonProperty("comment")]
		public string Comment { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("rules")]
		public ReadOnlyCollection<RejectionRules> Rules { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GetRejectionReasonResult FromJson(VkResponse response)
		{
			return new GetRejectionReasonResult
			{
				Comment = response["comment"],
				Rules = response["rules"].ToReadOnlyCollectionOf<RejectionRules>()
			};
		}
	}
}