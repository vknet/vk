using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc cref="JsonConverter" />
public class HistoryAttachmentJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	/// <exception cref="T:System.NotImplementedException"> </exception>
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var attachment = (Attachment) value;

		var type = attachment.Type.Name.ToLower();

		var jObj = new JObject
		{
			{
				"type", type
			},
			{
				type, JToken.FromObject(attachment.Instance, serializer)
			}
		};

		jObj.WriteTo(writer);
	}

	/// <inheritdoc />
	/// <exception cref="T:System.TypeAccessException"> </exception>
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (objectType.IsGenericType)
		{
			throw new TypeAccessException();
		}

		if (reader.TokenType is JsonToken.Null)
		{
			return null;
		}

		if (reader.TokenType is not JsonToken.StartObject)
		{
			return null;
		}


		var item = JObject.Load(reader: reader);

		var type = item["type"].ToString();

		var attachment = type switch
		{
			"link" => CreateTyped(item[type].ToObject<Link>()),
			"photo" or "posted_photo" => CreateTyped(item[type].ToObject<Photo>()),
			"audio" => CreateTyped(item[type].ToObject<Audio>()),
			"video" => CreateTyped(item[type].ToObject<Video>()),
			"doc" => CreateTyped(item[type].ToObject<Document>()),
			"podcast" => CreateTyped(item[type].ToObject<Podcast>()),
			"article" => CreateTyped(item[type].ToObject<Article>()),
			"event" => CreateTyped(item[type].ToObject<Event>()),
			"graffiti" => CreateTyped(item[type].ToObject<Graffiti>()),
			"money_transfer" => CreateTyped(item[type].ToObject<MoneyTransfer>()),
			"money_request" => CreateTyped(item[type].ToObject<MoneyRequest>()),
			"note" => CreateTyped(item[type].ToObject<Note>()),
			"poll" => CreateTyped(item[type].ToObject<Poll>()),
			"page" => CreateTyped(item[type].ToObject<Page>()),
			"album" => CreateTyped(item[type].ToObject<Album>()),
			"photos_list" => CreateTyped(item[type].ToObject<PhotosList>()),
			"wall" => CreateTyped(item[type].ToObject<Wall>()),
			"sticker" => CreateTyped(item[type].ToObject<Sticker>()),
			"wall_reply" => CreateTyped(item[type].ToObject<WallReply>()),
			"market_album" => CreateTyped(item[type].ToObject<MarketAlbum>()),
			"market" => CreateTyped(item[type].ToObject<Market>()),
			"pretty_cards" => CreateTyped(item[type].ToObject<PrettyCards>()),
			"audio_message" => CreateTyped(item[type].ToObject<AudioMessage>()),
			"call" => CreateTyped(item[type].ToObject<Call>()),
			"story" => CreateTyped(item[type].ToObject<Story>()),
			"audio_playlist" => CreateTyped(item[type].ToObject<AudioPlaylist>()),
			var _ => CreateTyped(item[type].ToObject<UnknownAttachment>())
		};

		return attachment;
	}

	#region Приватные методы

	private static Attachment CreateTyped<TAttachment>(TAttachment instance)
		where TAttachment : MediaAttachment
	{
		var attachment = new Attachment
		{
			Type = typeof(TAttachment),
			Instance = instance
		};

		return attachment;
	}

	#endregion

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}