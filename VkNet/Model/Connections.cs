using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о социальных контактах пользователя.
	/// См. описание
	/// <see href="http://vk.com/pages?oid=-1&amp;p=Описание_полей_параметра_fields" />
	/// и http://vk.com/dev/fields
	/// Экспериментально установлено, что поля находятся непосредственно в полях
	/// объекта User.
	/// </summary>
	[Serializable]
	public class Connections
	{
		/// <summary>
		/// Логин в Skype.
		/// </summary>
		public string Skype { get; set; }

		/// <summary>
		/// Идентификатор акаунта в Facebook.
		/// </summary>
		public long? FacebookId { get; set; }

		/// <summary>
		/// Имя и фамилия в facebook.
		/// </summary>
		public string FacebookName { get; set; }

		/// <summary>
		/// Акаунт в twitter.
		/// </summary>
		public string Twitter { get; set; }

		/// <summary>
		/// Акаунт в Instagram.
		/// </summary>
		public string Instagram { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Connections FromJson(VkResponse response)
		{
			var connections = new Connections
			{
					Skype = response[key: "skype"]
					, FacebookId = Utilities.GetNullableLongId(response: response[key: "facebook"])
					, FacebookName = response[key: "facebook_name"]
					, Twitter = response[key: "twitter"]
					, Instagram = response[key: "instagram"]
			};

			return connections;
		}

	#endregion
	}
}