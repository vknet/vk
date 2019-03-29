﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VkNet.Utils.JsonConverter
{
	/// <summary>
	/// Конвертер значений по умолчанию
	/// </summary>
	public class VkDefaultJsonConverter : Newtonsoft.Json.JsonConverter
	{
		/// <summary>
		/// Gets a value indicating whether this
		/// <see cref="T:Newtonsoft.Json.JsonConverter" /> can write JSON.
		/// </summary>
		/// <value>
		/// <c> true </c> if this <see cref="T:Newtonsoft.Json.JsonConverter" /> can write
		/// JSON; otherwise, <c> false </c>.
		/// </value>
		public override bool CanWrite => false;

		/// <summary> Writes the JSON representation of the object. </summary>
		/// <param name="writer">
		/// The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write
		/// to.
		/// </param>
		/// <param name="value"> The value. </param>
		/// <param name="serializer"> The calling serializer. </param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		/// <summary> Reads the JSON representation of the object. </summary>
		/// <param name="reader">
		/// The <see cref="T:Newtonsoft.Json.JsonReader" /> to read
		/// from.
		/// </param>
		/// <param name="objectType"> Type of the object. </param>
		/// <param name="existingValue"> The existing value of object being read. </param>
		/// <param name="serializer"> The calling serializer. </param>
		/// <returns> The object value. </returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
			{
				return null;
			}

			var obj = JObject.Load(reader: reader);
			var response = obj[propertyName: "response"] ?? obj;

			return IsDateTime(objectType: objectType, token: response.Type)
					? VkResponse.TimestampToDateTime(unixTimeStamp: response.ToObject<long>())
					: response.ToObject(objectType: objectType);
		}

		private static bool IsDateTime(Type objectType, JTokenType token)
		{
			return objectType == typeof(DateTime) && token == JTokenType.Integer;
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
			return !objectType.IsArray && objectType.IsSerializable;
		}
	}
}
