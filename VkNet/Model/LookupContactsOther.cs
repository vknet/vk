﻿using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Контактов, который не был найден.
	/// </summary>
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
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static LookupContactsOther FromJson(VkResponse response)
		{
			return new LookupContactsOther
			{
				Contact = response["contact"],
				CommonCount = response["common_count"]
			};
		}
	}
}