using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о предложениях.
	/// </summary>
	[Serializable]
	public class InformationAboutOffers
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Инструкция.
		/// </summary>
		public string Instruction { get; set; }

		/// <summary>
		/// Инструкция с html разметкой.
		/// </summary>
		/// <value>
		/// The instruction_html.
		/// </value>
		public string InstructionHtml { get; set; }

		/// <summary>
		/// Краткое описание.
		/// </summary>
		public string ShortDescription { get; set; }

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Ссылка на изображение.
		/// </summary>
		public Uri Img { get; set; }

		/// <summary>
		/// Тег.
		/// </summary>
		public string Tag { get; set; }

		/// <summary>
		/// Цена.
		/// </summary>
		public long Price { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static InformationAboutOffers FromJson(VkResponse response)
		{
			return new InformationAboutOffers
			{
					Id = response[key: "id"]
					, Title = response[key: "title"]
					, Instruction = response[key: "instruction"]
					, InstructionHtml = response[key: "instruction_html"]
					, ShortDescription = response[key: "short_description"]
					, Description = response[key: "description"]
					, Img = new Uri(uriString: response[key: "img"])
					, Tag = response[key: "tag"]
					, Price = response[key: "price"]
			};
		}
	}
}