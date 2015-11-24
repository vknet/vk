using System.Collections.Generic;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	public class LookupContactsResult
	{
		/// <summary>
		/// Список объектов пользователей.
		/// </summary>
		public List<User> FoundList { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static LookupContactsResult FromJson(VkResponse response)
		{

			return new LookupContactsResult
			{

			};
		}
	}
}