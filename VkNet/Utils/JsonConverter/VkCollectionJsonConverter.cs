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
		/// Инициализация
		/// </summary>
		/// <param name="collectionField"> Collection Field </param>
		public VkCollectionJsonConverter(string collectionField)
		{
			CollectionField = string.IsNullOrWhiteSpace(collectionField) ? "items" : collectionField;
		}

		/// <inheritdoc />
		public VkCollectionJsonConverter() : this("items")
		{
		}

		/// <summary>
		/// Количество
		/// </summary>
		private static string CountField => "count";

		/// <summary>
		/// Поле с коллекцией данных
		/// </summary>
		private string CollectionField { get; }

		/// <summary>
		/// Сериализация объекта в Json
		/// </summary>
		/// <param name="writer"> Json writer </param>
		/// <param name="value"> Значение </param>
		/// <param name="serializer"> Сериализатор </param>
		/// <exception cref="NotImplementedException"> </exception>
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

		/// <summary>
		/// Преобразование JSON в VkCollection
		/// </summary>
		/// <param name="reader"> Json reader </param>
		/// <param name="objectType"> Тип объекта </param>
		/// <param name="existingValue"> Существующее значение </param>
		/// <param name="serializer"> Seerilizer </param>
		/// <returns> </returns>
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

			var keyType = objectType.GetGenericArguments()[0];

			var constructedListType = typeof(List<>).MakeGenericType(keyType);

			var list = (IList) Activator.CreateInstance(constructedListType);

			var vkCollection = typeof(VkCollection<>).MakeGenericType(keyType);

			var obj = JObject.Load(reader);
			var response = obj["response"] ?? obj;
			var totalCount = response[CountField].Value<ulong>();

			var converter =
				serializer.Converters.FirstOrDefault(x => x.GetType() == typeof(VkCollectionJsonConverter)) as
					VkCollectionJsonConverter;

			var collectionField = CollectionField;

			if (converter != null)
			{
				collectionField = converter.CollectionField;
			}

			foreach (var item in response[collectionField])
			{
				list.Add(item.ToObject(keyType));
			}

			return Activator.CreateInstance(vkCollection, totalCount, list);
		}

		/// <summary>
		/// Может преобразовать
		/// </summary>
		/// <param name="objectType"> Тип объекта </param>
		/// <returns> <c> true </c> если можно преобразовать </returns>
		public override bool CanConvert(Type objectType)
		{
			return typeof(VkCollection<>).IsAssignableFrom(objectType);
		}
	}
}