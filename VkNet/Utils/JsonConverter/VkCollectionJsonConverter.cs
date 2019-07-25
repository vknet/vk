using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VkNet.Utils.JsonConverter
{
	/// <summary>
	/// Vk Collection Json Converter
	/// </summary>
	public class VkCollectionJsonConverter : Newtonsoft.Json.JsonConverter
	{
		/// <summary>
		/// A field with a total number of items.
		/// </summary>
		private static string CountField => "count";

		/// <inheritdoc />
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var vkCollectionType = value.GetType();

			var vkCollectionGenericArgument = vkCollectionType.GetGenericArguments()[0];
			var toListMethod = typeof(Enumerable).GetMethod("ToList");

			if (toListMethod == null)
			{
				return;
			}

			var constructedToListGenericMethod = toListMethod.MakeGenericMethod(vkCollectionGenericArgument);
			var castToListObject = constructedToListGenericMethod.Invoke(null, new[] { value });

			var vkCollectionSurrogate = new
			{
				TotalCount = vkCollectionType.GetProperty("TotalCount")?.GetValue(value, null),
				Items = castToListObject
			};

			serializer.Serialize(writer, vkCollectionSurrogate);
		}

		/// <inheritdoc />
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

			var keyType = objectType.GetGenericArguments()[0];

			var constructedListType = typeof(List<>).MakeGenericType(keyType);

			var list = (IList) Activator.CreateInstance(constructedListType);

			var vkCollection = typeof(VkCollection<>).MakeGenericType(keyType);

			var obj = JObject.Load(reader);

			var itemsArray = obj.Properties().FirstOrDefault(x => obj[x.Path] != null && obj[x.Path].Type == JTokenType.Array);

			if (itemsArray == null)
			{
				throw new InvalidOperationException("There is no property of an array of items.");
			}

			foreach (var item in itemsArray.Value)
			{
				list.Add(item.ToObject(keyType, serializer));
			}

			var totalCount = obj[CountField]?.Value<ulong>() ?? (ulong) list.Count;

			return Activator.CreateInstance(vkCollection, totalCount, list);
		}

		/// <inheritdoc />
		public override bool CanConvert(Type objectType)
		{
			return typeof(VkCollection<>).IsAssignableFrom(objectType);
		}
	}
}