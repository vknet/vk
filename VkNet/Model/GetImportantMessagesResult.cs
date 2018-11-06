using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Параметры метода Messages.GetImportantMessages
	/// </summary>
	[Serializable]
	public class GetImportantMessagesResult
	{
		/// <summary>
		/// Сообщения
		/// </summary>
		[JsonProperty("messages")]
		[JsonConverter(typeof(VkCollectionJsonConverter))]
		public VkCollection<Message> Messages { get; set; }

		/// <summary>
		/// Профили пользователей
		/// </summary>
		[JsonProperty("profiles")]
		public ReadOnlyCollection<User> Profiles { get; set; }

		/// <summary>
		/// Беседы
		/// </summary>
		[JsonProperty("conversations")]
		public ReadOnlyCollection<Conversation> Conversations { get; set; }
	}
}