using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace VkNet.Utils
{
	/// <summary>
	/// Утилиты.
	/// </summary>
	public static class Utilities
	{
		/// <summary>
		/// Преобразовать в перечисление из числа.
		/// </summary>
		/// <typeparam name="T"> Тип перечисления. </typeparam>
		/// <param name="value"> Числовое значение. </param>
		/// <returns> Перечисление указанного типа. </returns>
		/// <exception cref="System.ArgumentException"> value </exception>
		public static T EnumFrom<T>(int value)
		{
			if (!Enum.IsDefined(enumType: typeof(T), value: value))
			{
				throw new ArgumentException(message: $"Enum value {value} not defined!", paramName: nameof(value));
			}

			return (T) (object) value;
		}

		/// <summary>
		/// Преобразовать в перечисление из числа.
		/// </summary>
		/// <typeparam name="T"> Тип перечисления. </typeparam>
		/// <param name="value"> Числовое значение. </param>
		/// <returns> Перечисление указанного типа. </returns>
		public static T? NullableEnumFrom<T>(int value)
				where T : struct
		{
			if (!Enum.IsDefined(enumType: typeof(T), value: value))
			{
				return null;
			}

			return (T) (object) value;
		}

		/// <summary>
		/// Получение идентификатора.
		/// Применять когда id может быть задано как строкой так и числом в json'e.
		/// </summary>
		/// <param name="response"> Ответ от сервера vk.com </param>
		/// <returns> Число типа long или null </returns>
		public static long? GetNullableLongId(VkResponse response)
		{
			return !string.IsNullOrWhiteSpace(value: response?.ToString())
					? System.Convert.ToInt64(value: response.ToString())
					: (long?) null;
		}

		/// <summary>
		/// Объединить не пустую коллекцию.
		/// </summary>
		/// <typeparam name="T"> Тип коллекции. </typeparam>
		/// <param name="collection"> Коллекция. </param>
		/// <param name="separator"> Разделитель. </param>
		/// <returns> Строковое представление коллекции через разделитель. </returns>
		public static string JoinNonEmpty<T>(this IEnumerable<T> collection, string separator = ",")
		{
			if (collection == null)
			{
				return string.Empty;
			}

			return string.Join(separator: separator
					, values: collection.Select(selector: i => i.ToString().Trim())
							.Where(predicate: s => !string.IsNullOrWhiteSpace(value: s)));
		}

		/// <summary>
		/// Преобразовать массив объектов ответа сервера vk.com.
		/// </summary>
		/// <typeparam name="T"> Тип коллекции. </typeparam>
		/// <param name="response"> Ответ от сервера vk.com. </param>
		/// <param name="selector"> Функция фильтрации. </param>
		/// <returns> Коллекция данных указанного типа. </returns>
		public static IEnumerable<T> Convert<T>(this VkResponseArray response, Func<VkResponse, T> selector)
		{
			return response?.Select(selector: selector).ToList() ?? Enumerable.Empty<T>();
		}

		/// <summary>
		/// Вывести в консоль Json.
		/// </summary>
		/// <param name="json"> Json. </param>
		/// <returns> Json </returns>
		public static string PreetyPrintJson(string json)
		{
			using (var stringReader = new StringReader(s: json))
			{
				using (var stringWriter = new StringWriter())
				{
					var jsonReader = new JsonTextReader(reader: stringReader);
					var jsonWriter = new JsonTextWriter(textWriter: stringWriter) { Formatting = Formatting.Indented };
					jsonWriter.WriteToken(reader: jsonReader);

					return stringWriter.ToString();
				}
			}
		}

		/// <summary>
		/// Сериализует объект в JSON
		/// </summary>
		/// <param name="object"> Объект </param>
		/// <returns> </returns>
		public static string SerializeToJson<T>(T @object)
		{
			var result = JsonConvert.SerializeObject(value: @object, formatting: Formatting.Indented);

			return result == "null" ? null : result;
		}
	}
}