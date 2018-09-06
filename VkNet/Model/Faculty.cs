using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Факультет
	/// </summary>
	[Serializable]
	public class Faculty
	{
		/// <summary>
		/// Идентификатор факультета
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Название факультета
		/// </summary>
		public string Title { get; set; }

	#region public Methods

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Faculty FromJson(VkResponse response)
		{
			var faculty = new Faculty
			{
					Id = response[key: "id"]
					, Title = response[key: "title"]
			};

			return faculty;
		}

	#endregion
	}
}