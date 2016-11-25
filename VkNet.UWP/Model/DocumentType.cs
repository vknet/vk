using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Тип документа.
	/// </summary>
	public class DocumentType
	{
		/// <summary>
		/// Идентификатор полученного подарка.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Текст сообщения, приложенного к подарку.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Количество документов данного типа.
		/// </summary>
		public long Count { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns>Тип документа.</returns>
		public static DocumentType FromJson(VkResponse response)
		{
			var result = new DocumentType
			{
				Id = response["id"],
				Name = response["name"],
				Count = response["count"]
			};

			return result;
		}
	}
}