using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VkNet.Utils
{
    /// <summary>
    /// Vk Collection Json Converter
    /// </summary>
    public class VkCollectionJsonConverter : JsonConverter
    {
        /// <summary>
        /// Count
        /// </summary>
        private static string CountField => "count";

        /// <summary>
        /// Collection Field
        /// </summary>
        private string CollectionField { get; }

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="collectionField">Collection Field</param>
        public VkCollectionJsonConverter(string collectionField = "items")
        {
            CollectionField = collectionField;
        }

        /// <summary>
        /// Init
        /// </summary>
        public VkCollectionJsonConverter()
        {
            CollectionField = "items";
        }

        /// <summary>
        /// Object to Json
        /// </summary>
        /// <param name="writer">Json writer</param>
        /// <param name="value">Value</param>
        /// <param name="serializer">Serializer</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// JSON to VkCollection 
        /// </summary>
        /// <param name="reader">Json reader</param>
        /// <param name="objectType">object Type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">Seerilizer</param>
        /// <returns></returns>
        /// <exception cref="TypeAccessException"></exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (!objectType.IsGenericType)
            {
                throw new TypeAccessException();
            }

            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var keyType = objectType.GetGenericArguments()[0];

            var constructedListType = typeof(List<>).MakeGenericType(keyType);

            var list = (IList) Activator.CreateInstance(constructedListType);
            
            var vkCollection = typeof(VkCollection<>).MakeGenericType(keyType);
            
            var obj = JObject.Load(reader);
            var totalCount = obj[CountField].Value<ulong>();
            
            foreach (var item in obj[CollectionField])
            {
                list.Add(item.ToObject(keyType));
            }

            return Activator.CreateInstance(vkCollection, totalCount, list);
        }

        /// <summary>
        /// Can Convert
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(VkCollection<>).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Can Write
        /// </summary>
        public override bool CanWrite => false;
    }
}