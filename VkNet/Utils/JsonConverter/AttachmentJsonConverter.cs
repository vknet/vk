using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <summary>
/// Attachment JsonConverter
/// </summary>
/// <seealso cref="Newtonsoft.Json.JsonConverter" />
public class AttachmentJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	/// <exception cref="T:System.NotImplementedException"> </exception>
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var attachments = (IEnumerable<Attachment>) value;

		var jArray = new JArray();

		foreach (var attachment in attachments)
		{
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

			jArray.Add(jObj);
		}

		jArray.WriteTo(writer);
	}

	/// <inheritdoc />
	/// <exception cref="T:System.TypeAccessException"> </exception>
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (!objectType.IsGenericType)
		{
			throw new TypeAccessException();
		}

		if (reader.TokenType == JsonToken.Null)
		{
			return null;
		}

		if (reader.TokenType != JsonToken.StartArray)
		{
			return null;
		}

		var keyType = objectType.GetGenericArguments()[0];

		var constructedListType = typeof(List<>).MakeGenericType(keyType);

		var list = (IList) Activator.CreateInstance(type: constructedListType);

		var vkCollection = typeof(ReadOnlyCollection<>).MakeGenericType(keyType);

		var obj = JArray.Load(reader: reader);

		foreach (var item in obj)
		{
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

			list.Add(attachment);
		}

		return Activator.CreateInstance(vkCollection, list);
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
	public override bool CanConvert(Type objectType) => typeof(ReadOnlyCollection<>).IsAssignableFrom(c: objectType);
}