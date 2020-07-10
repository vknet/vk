using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter
{
	/// <inheritdoc />
	public class CoordinatesJsonConverter : Newtonsoft.Json.JsonConverter
	{
		/// <inheritdoc />
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (objectType.IsGenericType)
			{
				throw new TypeAccessException();
			}

			double latitude = 0;
			double longitude = 0;

			switch (reader.TokenType)
			{
				case JsonToken.Null:
					return null;
				case JsonToken.String:
				{
					var latitudeWithLongitude = ((string) reader.Value).Split(' ');

					if (latitudeWithLongitude.Length != 2)
					{
						throw new VkApiException(message: "Coordinates must have latitude and longitude!");
					}

					if (!double.TryParse(s: latitudeWithLongitude[0].Replace(oldValue: ".", newValue: ","), result: out latitude))
					{
						throw new VkApiException(message: "Invalid latitude!");
					}

					if (!double.TryParse(s: latitudeWithLongitude[1].Replace(oldValue: ".", newValue: ","), result: out longitude))
					{
						throw new VkApiException(message: "Invalid longitude!");
					}

					break;
				}
				case JsonToken.StartObject:
				{
					var obj = JObject.Load(reader);
					var responseJToken = obj["response"] ?? obj;
					var response = new VkResponse(responseJToken);

					if (response.ContainsKey("latitude") && response.ContainsKey("longitude")) //приходит в messages.geo
					{
						latitude = response["latitude"];
						longitude = response["longitude"];
					}

					break;
				}
				case JsonToken.None:
					break;
				case JsonToken.StartArray:
					break;
				case JsonToken.StartConstructor:
					break;
				case JsonToken.PropertyName:
					break;
				case JsonToken.Comment:
					break;
				case JsonToken.Raw:
					break;
				case JsonToken.Integer:
					break;
				case JsonToken.Float:
					break;
				case JsonToken.Boolean:
					break;
				case JsonToken.Undefined:
					break;
				case JsonToken.EndObject:
					break;
				case JsonToken.EndArray:
					break;
				case JsonToken.EndConstructor:
					break;
				case JsonToken.Date:
					break;
				case JsonToken.Bytes:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			var coordinates = new Coordinates
			{
				Latitude = latitude,
				Longitude = longitude
			};

			return coordinates;
		}

		/// <inheritdoc />
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}
	}
}