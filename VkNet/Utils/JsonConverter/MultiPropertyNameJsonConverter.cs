using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VkNet.Utils.JsonConverter
{
    /// <summary>
    /// Несколько значений для свойства
    /// </summary>
    public class MultiPropertyNameJsonConverter: Newtonsoft.Json.JsonConverter
    {
        /// <summary>
        /// Наименования свойств
        /// </summary>
        private readonly ICollection<string> _propertyNames;
        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="propertyNames"></param>
        public MultiPropertyNameJsonConverter(string propertyNames)
        {
            _propertyNames = propertyNames.Split('|').Select(x => x.Trim()).ToList();
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteNull();
        }

        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            if (reader.ValueType.IsValueType && _propertyNames.Contains(reader.Path))
            {
                return reader.Value;
            }
            
            var obj = JObject.Load(reader);
            var response = obj.Properties().FirstOrDefault(x => _propertyNames.Contains(x.Name));
            return response?.ToObject(objectType);
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// 	<c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return _propertyNames.Count > 1;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Newtonsoft.Json.JsonConverter" /> can read JSON.
        /// </summary>
        /// <value><c>true</c> if this <see cref="T:Newtonsoft.Json.JsonConverter" /> can read JSON; otherwise, <c>false</c>.</value>
        public override bool CanRead => true;
    }
}