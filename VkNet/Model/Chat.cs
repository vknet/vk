using System;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о беседе (мультидиалоге, чате).
	/// См. описание http://vk.com/dev/chat_object
	/// </summary>
	[Serializable]
	public class Chat
	{
		/// <summary>
		/// Идентификатор беседы.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Тип диалога.
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Название беседы.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Идентификатор пользователя, который является создателем беседы.
		/// </summary>
		public long? AdminId { get; set; }

		/// <summary>
		/// Список идентификаторов участников беседы.
		/// </summary>
		public ReadOnlyCollection<long> Users { get; set; }

		/// <summary>
		/// Настройки оповещений для диалога..
		/// </summary>
		[CanBeNull]
		public ChatPushSettings PushSettings { get; set; }

		/// <summary>
		/// URL изображения-обложки чата шириной 50 px (если доступно).
		/// </summary>
		public string Photo50 { get; set; }

		/// <summary>
		/// URL изображения-обложки чата шириной 100 px (если доступно).
		/// </summary>
		public string Photo100 { get; set; }

		/// <summary>
		/// URL изображения-обложки чата шириной 200 px (если доступно).
		/// </summary>
		public string Photo200 { get; set; }

		/// <summary>
		/// флаг, указывающий, что пользователь покинул беседу. Всегда содержит 1.
		/// </summary>
		public bool Left { get; set; }

		/// <summary>
		/// флаг, указывающий, что пользователь был исключен из беседы. Всегда содержит 1.
		/// </summary>
		public bool Kicked { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Chat FromJson(VkResponse response)
		{
			var chat = new Chat
			{
					Id = response[key: "id"]
					, Type = response[key: "type"]
					, Title = response[key: "title"]
					, AdminId = Utilities.GetNullableLongId(response: response[key: "admin_id"])
					, Users = response[key: "users"].ToReadOnlyCollectionOf<long>(selector: x => x)
					, Left = response.ContainsKey(key: "left") && response[key: "left"]
					, Kicked = response[key: "kicked"]
					, Photo50 = response[key: "photo_50"]
					, Photo100 = response[key: "photo_100"]
					, Photo200 = response[key: "photo_200"]
					, PushSettings = response[key: "push_settings"]
			};

			return chat;
		}

	#endregion
	}
}