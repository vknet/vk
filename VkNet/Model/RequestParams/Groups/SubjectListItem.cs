using System;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Элемент списка возможных тематик
	/// </summary>
	[Serializable]
	public class SubjectListItem
	{
		/// <summary>
		/// идентификатор тематики;
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// название тематики.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static SubjectListItem FromJson(VkResponse response)
		{
			return new SubjectListItem
			{
				Id = response["id"],
				Name = response["name"]
			};
		}
	}
}