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
		/// <summary>
		/// Writes the JSON representation of the object.
		/// </summary>
		/// <param name="writer">
		/// The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write
		/// to.
		/// </param>
		/// <param name="value"> The value. </param>
		/// <param name="serializer"> The calling serializer. </param>
		/// <exception cref="NotImplementedException"> </exception>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Reads the JSON representation of the object.
		/// </summary>
		/// <param name="reader">
		/// The <see cref="T:Newtonsoft.Json.JsonReader" /> to read
		/// from.
		/// </param>
		/// <param name="objectType"> Type of the object. </param>
		/// <param name="existingValue"> The existing value of object being read. </param>
		/// <param name="serializer"> The calling serializer. </param>
		/// <returns>
		/// The object value.
		/// </returns>
		/// <exception cref="TypeAccessException"> </exception>
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

			var obj = JObject.Load(reader: reader);
			var response = obj[propertyName: "response"] ?? obj;

			foreach (var item in response)
			{
				list.Add(value: Attachment.FromJson(response: new VkResponse(token: item) { RawJson = response.ToString() }));
			}

			return Activator.CreateInstance(vkCollection, list);
		}

		/// <summary>
		/// Determines whether this instance can convert the specified object type.
		/// </summary>
		/// <param name="objectType"> Type of the object. </param>
		/// <returns>
		/// <c> true </c> if this instance can convert the specified object type;
		/// otherwise, <c> false </c>.
		/// </returns>
		public override bool CanConvert(Type objectType)
		{
			return typeof(ReadOnlyCollection<>).IsAssignableFrom(c: objectType);
		}
	}
}