using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Контактов, который не был найден.
	/// </summary>
	[Serializable]
	public class LookupContactsOther
	{
		/// <summary>
		/// Контакт.
		/// </summary>
		public string Contact { get; set; }

		/// <summary>
		/// Количество.
		/// </summary>
		public long CommonCount { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static LookupContactsOther FromJson(VkResponse response)
		{
			return new LookupContactsOther
			{
					Contact = response[key: "contact"]
					, CommonCount = response[key: "common_count"]
			};
		}
	}
}