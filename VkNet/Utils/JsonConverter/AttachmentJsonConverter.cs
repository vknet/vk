using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Model.Attachments;

namespace VkNet.Utils.JsonConverter
{
    public class AttachmentJsonConverter : Newtonsoft.Json.JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

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
            
            
            var obj = JObject.Load(reader);
            var response = obj["response"] ?? obj;
            return Attachment.FromJson(new VkResponse(response) {RawJson = response.ToString()});
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(VkCollection<>).IsAssignableFrom(objectType);
        }
    }
}