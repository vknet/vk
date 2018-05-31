using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Метка в списке друзей
	/// </summary>
	[Serializable]
	public class FriendList
	{
		/// <summary>
		/// Идентификатор метки
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Название метки
		/// </summary>
		public string Name { get; set; }

	#region public Methods

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static FriendList FromJson(VkResponse response)
		{
			var list = new FriendList
			{
					Id = response[key: "list_id"] ?? response[key: "lid"] ?? response[key: "id"]
					, Name = response[key: "name"]
			};

			return list;
		}

	#endregion
	}
}