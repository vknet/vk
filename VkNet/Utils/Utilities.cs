using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Exception;
using VkNet.Infrastructure;

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
			where T : IConvertible
		{
			if (!Enum.IsDefined(typeof(T), value))
			{
				throw new ArgumentException($"Enum value {value} not defined!", nameof(value));
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
			if (!Enum.IsDefined(typeof(T), value))
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
			return string.IsNullOrWhiteSpace(response?.ToString())
				? (long?) null
				: System.Convert.ToInt64(response?.ToString());
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

			return string.Join(separator,
				collection.Select(i => i.ToString().Trim())
					.Where(s => !string.IsNullOrWhiteSpace(s)));
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
			return response?.Select(selector).ToList() ?? Enumerable.Empty<T>();
		}

		/// <summary>
		/// Конвертировать JSON в читаемый формат с отступами
		/// </summary>
		/// <param name="json"> JSON. </param>
		/// <returns> JSON с отступами </returns>
		public static string PrettyPrintJson(string json)
		{
			const string hidden = "***HIDDEN***";

			var keysToHide = new[]
			{
				"access_token",
				"new_password",
				"old_password"
			};

			try
			{
				var jObject = json.ToJObject();

				foreach (var key in keysToHide)
				{
					if (jObject.ContainsKey(key))
					{
						jObject[key] = hidden;
					}
				}

				return jObject.ToString(Formatting.Indented);
			}
			catch (VkApiException)
			{
				return json;
			}
		}

		/// <summary>
		/// Сериализует объект в JSON
		/// </summary>
		/// <param name="object"> Объект </param>
		/// <returns> </returns>
		public static string SerializeToJson<T>(T @object)
		{
			var result = JsonConvert.SerializeObject(@object, Formatting.Indented);

			return result == "null" ? null : result;
		}

		/// <summary>
		/// Deserializes JSON for the specified .NET type. A return value indicates whether deserialization succeeded.
		/// </summary>
		/// <param name="json"> The JSON to deserialize. </param>
		/// <param name="result"> Deserialized object. </param>
		/// <typeparam name="T"> Type for deserialization. </typeparam>
		/// <returns></returns>
		public static bool TryDeserializeObject<T>(string json, out T result)
		{
			try
			{
				result = JsonConvert.DeserializeObject<T>(json, JsonConfigure.JsonSerializerSettings);
				return true;
			}
			catch
			{
				result = default;
				return false;
			}
		}
	}
}