using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{

	/// <summary>
	/// Результат выполнения метода RemoveTargetContactsResult
	/// </summary>
	[Serializable]
	public class RemoveTargetContactsResult
	{
		/// <summary>
		/// Результат.
		/// </summary>
		[JsonProperty("result")]
		public bool Result { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static RemoveTargetContactsResult FromJson(VkResponse response)
		{
			return new RemoveTargetContactsResult
			{
				Result = response["result"]
			};
		}
	}
}