using VkNet.Enums.SafetyEnums;

namespace VkNet.Model
{
	using System;
	using Utils;

	/// <summary>
	/// Информация информацию о том, каким образом (через интерфейс сайта, виджет и т.п.) была создана запись на стене.
	/// Используя данные из этого поля, разработчик может вывести уточняющую информацию о том, как была создана запись на стене
	/// в своем приложении.
	/// См. описание <see href="http://vk.com/dev/post_source"/>.
	/// </summary>
	[Serializable]
	public class PostSource
	{
		/// <summary>
		/// На данный момент поддерживаются следующие типы источников записи на стене.
		/// </summary>
		public PostSourceType Type { get; set; }

		/// <summary>
		/// Поле data является опциональным и содержит следующие данные в зависимости от значения поля type:
		/// </summary>
		public PostSourceData Data { get; set; }

		/// <summary>
		/// Название платформы, если оно доступно: android, iphone, wphone.
		/// </summary>
		public Platform Platform;

		/// <summary>
		/// Cодержит внешнюю ссылку на ресурс, с которого была опубликована запись.
		/// </summary>
		public Uri Url;
		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static PostSource FromJson(VkResponse response)
		{
			var postSource = new PostSource
			{
				Type = response["type"],
				Data = response["data"],
				Platform = response["source_platform"],
				Url = response["source_url"]
			};

			return postSource;
		}

		#endregion
	}
}