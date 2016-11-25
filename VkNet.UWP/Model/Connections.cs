using System.Runtime.Serialization;

namespace VkNet.Model
{
    using Utils;

	/// <summary>
	/// Информация о социальных контактах пользователя.
	/// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Описание_полей_параметра_fields"/>
	/// и <see href="http://vk.com/dev/fields"/>. Последняя страница обманывает насчет поля 'connections'.
	/// Экспериментально установлено, что поля находятся непосредственно в полях объекта User.
	/// </summary>
	[DataContract]
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
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static Connections FromJson(VkResponse response)
		{
			var connections = new Connections
			{
				Skype = response["skype"],
				FacebookId = Utilities.GetNullableLongId(response["facebook"]),
				FacebookName = response["facebook_name"],
				Twitter = response["twitter"],
				Instagram = response["instagram"]
			};

			return connections;
		}

		#endregion
	}
}