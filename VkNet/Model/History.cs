namespace VkNet.Model
{
	using VkNet.Utils;
	
	/// <summary>
	/// История изменения объекта
	/// </summary>
	public class History
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Длина символов.
		/// </summary>
		/// <remarks>
		/// При необходимости сделать nullable
		/// </remarks>
		public int Length { get; set; }

		/// <summary>
		/// Дата изменения.
		/// </summary>
		public string Date { get; set; }

		/// <summary>
		/// Идентификатор пользователя применившего изменения.
		/// </summary>
		public long EditorId { get; set; }

		/// <summary>
		/// Имя пользователя применившего изменения.
		/// </summary>
		public string EditorName { get; set; }


		#region Методы

		/// <summary>
		/// Froms the json.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <returns></returns>
		internal static History FromJson(VkResponse response)
		{
			var reposts = new History
			{
				Id = response["id"],
				Length = response["length"],
				Date = response["date"],
				EditorId = response["editor_id"],
				EditorName = response["editor_name"]
			};

			return reposts;
		}

		#endregion
	}
}
