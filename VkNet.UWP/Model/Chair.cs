using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Кафедра
	/// </summary>
	public class Chair
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
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static Chair FromJson(VkResponse response)
		{
			var result = new Chair
			{
				Id = response["id"],
				Title = response["title"]
			};

			return result;
		}

		#endregion
	}
}