namespace VkNet.Model
{
    using Utils;

	/// <summary>
	/// Теги.
	/// </summary>
	public class Tags
    {
		/// <summary>
		/// Количество.
		/// </summary>
		public int Count { get; set; }

		#region Internal methods

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Tags FromJson(VkResponse response)
		{
			var tags = new Tags
			{
				Count = response["count"]
			};

			return tags;
		}

		#endregion
	}
}