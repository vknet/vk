using System;
using System.Globalization;
using Newtonsoft.Json;

namespace VkNet.Utils.JsonConverter
{
	/// <inheritdoc />
	public class DateTimeToStringFormatConverter : Newtonsoft.Json.JsonConverter
	{
		private readonly string _format;

		/// <inheritdoc />
		public DateTimeToStringFormatConverter(string format)
		{
			_format = format;
		}

		/// <inheritdoc />
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var date = value is DateTime time ? time : new DateTime();
			writer.WriteValue(date.ToString(_format));
		}

		/// <inheritdoc />
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (objectType != typeof(DateTime) && objectType != typeof(DateTime?))
			{
				throw new JsonSerializationException("objectType should be DateTime or DateTime?.");
			}

			return DateTime.ParseExact(reader.Value.ToString(), _format, CultureInfo.InvariantCulture);
		}

		/// <inheritdoc />
		public override bool CanConvert(Type objectType)
		{
			return objectType.IsValueType || objectType == typeof(DateTime);
		}
	}
}