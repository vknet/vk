using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
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
		/// <typeparam name="T">Тип перечисления.</typeparam>
		/// <param name="value">Числовое значение.</param>
		/// <returns>Перечисление указанного типа.</returns>
		/// <exception cref="System.ArgumentException">value</exception>
		public static T EnumFrom<T>(int value)
        {
			if (!Enum.IsDefined(typeof (T), value))
			{
				throw new ArgumentException($"Enum value {value} not defined!", "value");
			}

            return (T)(object)value;
        }

		/// <summary>
		/// Преобразовать в перечисление из числа.
		/// </summary>
		/// <typeparam name="T">Тип перечисления.</typeparam>
		/// <param name="value">Числовое значение.</param>
		/// <returns>Перечисление указанного типа.</returns>
		public static T? NullableEnumFrom<T>(int value) where T : struct
        {
			if (!Enum.IsDefined(typeof (T), value))
			{
				return null;
			}

            return (T)(object)value;
        }

        /// <summary>
        /// Получение идентификатора.
        ///
        /// Применять когда id может быть задано как строкой так и числом в json'e.
        /// </summary>
        /// <param name="response">Ответ от сервера vk.com</param>
        /// <returns>Число типа long или null</returns>
        public static long? GetNullableLongId(VkResponse response)
        {
            return !string.IsNullOrWhiteSpace(response?.ToString()) ? System.Convert.ToInt64(response.ToString()) : (long?)null;
        }

		/// <summary>
		/// Объединить не пустую коллекцию.
		/// </summary>
		/// <typeparam name="T">Тип коллекции.</typeparam>
		/// <param name="collection">Коллекция.</param>
		/// <param name="separator">Разделитель.</param>
		/// <returns>Строковое представление коллекции через разделитель.</returns>
		public static string JoinNonEmpty<T>(this IEnumerable<T> collection, string separator = ",")
		{
		    if (collection == null)
		    {
		        return string.Empty;
		    }

            return string.Join(
                    separator, 
                    collection.Select(i => i.ToString().Trim())
                    .Where(s => !string.IsNullOrWhiteSpace(s)
                ));
		}

		/// <summary>
		/// Преобразовать массив объектов ответа сервера vk.com.
		/// </summary>
		/// <typeparam name="T">Тип коллекции.</typeparam>
		/// <param name="response">Ответ от сервера vk.com.</param>
		/// <param name="selector">Функция фильтрации.</param>
		/// <returns>Коллекция данных указанного типа.</returns>
		public static IEnumerable<T> Convert<T>(this VkResponseArray response, Func<VkResponse, T> selector)
		{
		    return response?.Select(selector).ToList() ?? Enumerable.Empty<T>();
		}

		/// <summary>
		/// Вывести в консоль URL API.
		/// </summary>
		/// <param name="url">URL API.</param>
		/// <returns>URL</returns>
		public static string PreetyPrintApiUrl(string url) => $"            Uri = \"{url}\";";

        /// <summary>
		/// Вывести в консоль Json.
		/// </summary>
		/// <param name="json">Json.</param>
		/// <returns>Json</returns>
		public static string PreetyPrintJson(string json)
        {
            // DELME:
            var jObject = JObject.Parse(json);
            var preety = jObject.ToString();
            preety = preety.Replace('"', '\'');
            var result = new StringBuilder();

            result.AppendLine("            const string json =");
            result.Append("                @\"");
            using (var reader = new StringReader(preety))
            {
                var isFirst = true;
                for (;;)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    if (!isFirst)
                    {
                        result.AppendLine();
                        result.Append("                  ");
                    }

                    result.Append(line);

                    isFirst = false;
                }
            }
            result.Append("\";");

            return result.ToString();
        }

        /// <summary>
        /// Сериализует объект в JSON
        /// </summary>
        /// <param name="object">Объект</param>
        /// <returns></returns>
        public static string SerializeToJson(object @object)
        {
            string result = JsonConvert.SerializeObject(@object);
            if (result == "null")
                return null;
            return result;
        }
    }
}