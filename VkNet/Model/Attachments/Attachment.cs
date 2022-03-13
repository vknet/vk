using System;
using System.Collections.Generic;
using VkNet.Utils;
using VkNet.UWP.Model.Attachments;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Информация о медиавложении в записи.
	/// См. описание http://vk.com/dev/attachments_w
	/// </summary>
	[Serializable]
	public class Attachment
	{
		/// <summary>
		/// Экземпляр самого прикрепления.
		/// </summary>
		public MediaAttachment Instance { get; private set; }

		/// <summary>
		/// Информация о типе вложения.
		/// </summary>
		public Type Type { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Attachment FromJson(VkResponse response)
		{
			var attachment = new Attachment();

			string type = response["type"];

			attachment.Type = _typeMapping.TryGetValue(type, out var attachmentType)
				? attachmentType
				: typeof(UnknownAttachment);
			attachment.Instance = response[type];

			return attachment;
		}

	#endregion

		public override string ToString()
		{
			return $"{Type.Name}";
		}

	#region Поля

		private static Dictionary<string, Type> _typeMapping = new()
		{
			["photo"] = typeof(Photo),
			["posted_photo"] = typeof(Photo),
			["audio"] = typeof(Audio),
			["video"] = typeof(Video),
			["doc"] = typeof(Document),
			["podcast"] = typeof(Podcast),
			["article"] = typeof(Article),
			["event"] = typeof(Event),
			["graffiti"] = typeof(Graffiti),
			["money_transfer"] = typeof(MoneyTransfer),
			["money_request"] = typeof(MoneyRequest),
			["note"] = typeof(Note),
			["poll"] = typeof(Poll),
			["page"] = typeof(Page),
			["album"] = typeof(Album),
			["photos_list"] = typeof(PhotosList),
			["wall"] = typeof(Wall),
			["sticker"] = typeof(Sticker),
			["gift"] = typeof(Gift),
			["wall_reply"] = typeof(WallReply),
			["market_album"] = typeof(MarketAlbum),
			["market"] = typeof(Market),
			["pretty_cards"] = typeof(PrettyCards),
			["audio_message"] = typeof(AudioMessage),
			["call"] = typeof(Call),
			["story"] = typeof(Story),
			["audio_playlist"] = typeof(AudioPlaylist),
		};

	#endregion
	}
}