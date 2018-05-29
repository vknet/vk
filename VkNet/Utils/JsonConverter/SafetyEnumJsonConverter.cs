using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace VkNet.Utils.JsonConverter
{
    /// <summary>
    /// TODO: Description
    /// </summary>
    public class SafetyEnumJsonConverter : Newtonsoft.Json.JsonConverter
    {
        /// <summary>
        /// TODO: Description
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// TODO: Description
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var result = Activator.CreateInstance(objectType);
            var methods = result.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Public |
                                                      BindingFlags.Static | BindingFlags.FlattenHierarchy);

            result = methods
                .FirstOrDefault(x => x.Name == "FromJsonString")
                ?.Invoke(result, new object[] {$"{reader.Value}"});

            var fields = result?.GetType().GetFields();
	        if ( fields == null ) {
		        return null;
	        }

	        foreach ( var field in fields ) {
		        field.GetValue(null);
	        }

	        return result;
        }
        /// <summary>
        /// TODO: Description
        /// </summary>
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}