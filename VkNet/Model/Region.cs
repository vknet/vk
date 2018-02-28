using System;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Регион
    /// </summary>
    [Serializable]
    public class Region
    {
        /// <summary>
        /// Идентификатор региона
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название региона
        /// </summary>
        public string Title { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static Region FromJson(VkResponse response)
        {
			var region = new Region
			{
				Id = response["region_id"] ?? response["id"],
				Title = response["title"]
			};

			return region;
        }
    }
}