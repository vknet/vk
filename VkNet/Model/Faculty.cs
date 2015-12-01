using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Факультет
    /// </summary>
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

        #region Internal Methods

        internal static Faculty FromJson(VkResponse response)
		{
			var faculty = new Faculty
			{
				Id = response["id"],
				Title = response["title"]
			};

			return faculty;
		}

		#endregion
	}
}