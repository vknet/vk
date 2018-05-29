using System;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация информацию о том, каким образом (через интерфейс сайта, виджет и
	/// т.п.) была создана запись на стене.
	/// Используя данные из этого поля, разработчик может вывести уточняющую информацию
	/// о том, как была создана запись на
	/// стене
	/// в своем приложении.
	/// См. описание http://vk.com/dev/post_source
	/// </summary>
	[Serializable]
	public class PostSource
	{
		/// <summary>
		/// На данный момент поддерживаются следующие типы источников записи на стене.
		/// </summary>
		public PostSourceType Type { get; set; }

		/// <summary>
		/// Название платформы, если оно доступно: android, iphone, wphone.
		/// </summary>
		public Platform Platform { get; set; }

		/// <summary>
		/// Поле data является опциональным и содержит следующие данные в зависимости от
		/// значения поля type:
		/// </summary>
		public PostSourceData Data { get; set; }

		/// <summary>
		/// Cодержит внешнюю ссылку на ресурс, с которого была опубликована запись.
		/// </summary>
		public Uri Uri { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static PostSource FromJson(VkResponse response)
		{
			var postSource = new PostSource
			{
					Type = response[key: "type"]
					, Data = response[key: "data"]
					, Platform = response[key: "source_platform"]
					, Uri = response[key: "source_url"]
			};

			return postSource;
		}

	#endregion
	}
}