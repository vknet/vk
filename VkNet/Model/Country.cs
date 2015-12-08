using VkNet.Utils;

namespace VkNet.Model
{
    using System;

    /// <summary>
    /// Информация о стране.
    /// </summary>
    [Serializable]
    public class Country
    {
        /// <summary>
        /// Идентификатор страны.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название страны.
        /// </summary>
        public string Title { get; set; }

		#region Internal Methods
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Country FromJson(VkResponse response)
		{
			var country = new Country
			{
				Id = response["cid"] ?? response["id"],
				Title = response["title"] ?? response["name"]
			};

			return country;
		}

		#endregion
	}
}