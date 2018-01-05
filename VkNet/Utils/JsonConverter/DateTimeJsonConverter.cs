using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VkNet.Utils.JsonConverter
{
    public class DateTimeJsonConverter: Newtonsoft.Json.JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.TokenType == JsonToken.Null ? default(DateTime) : VkResponse.TimestampToDateTime((long)reader.Value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEquivalentTo(typeof(DateTime));
        }
    }
}