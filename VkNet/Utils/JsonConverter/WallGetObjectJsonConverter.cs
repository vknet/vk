using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Model;
using VkNet.Model.Attachments;

namespace VkNet.Utils.JsonConverter
{
	/// <inheritdoc />
	public class WallGetObjectJsonConverter : Newtonsoft.Json.JsonConverter
	{
		/// <inheritdoc />
		public override bool CanWrite => false;

		/// <inheritdoc />
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotSupportedException();
		}

		/// <inheritdoc />
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			switch (reader.TokenType)
			{
				case JsonToken.Null:
					return null;
				case JsonToken.StartObject:
				{
					var wallGetObject = new WallGetObject();

					serializer.Populate(reader, wallGetObject);

					return wallGetObject;
				}
				case JsonToken.StartArray:
				{
					var posts = new List<Post>();

					serializer.Populate(reader, posts);

					return new WallGetObject
					{
						TotalCount = (ulong) posts.Count,
						WallPosts = new ReadOnlyCollection<Post>(posts)
					};
				}
				default:
					throw new JsonSerializationException($"Unexpected token {reader.TokenType}");
			}
		}

		/// <inheritdoc />
		public override bool CanConvert(Type objectType)
		{
			return typeof(WallGetObject).IsAssignableFrom(objectType);
		}
	}
}