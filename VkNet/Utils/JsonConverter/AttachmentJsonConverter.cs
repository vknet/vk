using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Model.Attachments;

namespace VkNet.Utils.JsonConverter
{
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
					{ "type", type },
					{ type, JToken.FromObject(attachment.Instance, serializer) }
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
				list.Add(value: Attachment.FromJson(response: new VkResponse(token: item) { RawJson = item.ToString() }));
			}

			return Activator.CreateInstance(vkCollection, list);
		}

		/// <inheritdoc />
		public override bool CanConvert(Type objectType)
		{
			return typeof(ReadOnlyCollection<>).IsAssignableFrom(c: objectType);
		}
	}
}