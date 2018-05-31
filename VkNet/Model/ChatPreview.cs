using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Превью чата
	/// </summary>
	[Serializable]
	public class ChatPreview
	{
		/// <summary>
		/// Информация о чате.
		/// </summary>
		[JsonProperty(propertyName: "preview")]
		public ChatPreviewField Preview { get; set; }

		/// <summary>
		/// Массив объектов пользователей
		/// </summary>
		[JsonProperty(propertyName: "profiles")]
		public IEnumerable<User> Profiles { get; set; }

		/// <summary>
		/// Массив объектов сообществ
		/// </summary>
		[JsonProperty(propertyName: "groups")]
		public IEnumerable<Group> Groups { get; set; }

		/// <summary>
		/// Массив объектов, описывающих e-mail.
		/// </summary>
		[JsonProperty(propertyName: "emails")]
		public IEnumerable<Email> Emails { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static ChatPreview FromJson(VkResponse response)
		{
			return new ChatPreview
			{
					Preview = response[key: "preview"]
					, Profiles = response[key: "profiles"].ToReadOnlyCollectionOf<User>(selector: x => x)
					, Groups = response[key: "groups"].ToReadOnlyCollectionOf<Group>(selector: x => x)
					, Emails = response[key: "emails"].ToReadOnlyCollectionOf<Email>(selector: x => x)
			};
		}

	#endregion
	}
}