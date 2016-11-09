using System.Runtime.Serialization;

namespace VkNet.Model
{
	using System;
	using Utils;

	/// <summary>
	/// Теги.
	/// </summary>
	[DataContract]
	public class Tags
    {
		/// <summary>
		/// Количество.
		/// </summary>
		public int Count { get; set; }

		#region public methods

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static Tags FromJson(VkResponse response)
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