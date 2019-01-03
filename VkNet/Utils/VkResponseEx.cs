using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VkNet.Utils
{
	/// <summary>
	/// Методы расширения для ответов vk.com
	/// </summary>
	public static class VkResponseEx
	{
		/// <summary>
		/// В коллекцию.
		/// </summary>
		/// <typeparam name="T"> Тип данных коллекции. </typeparam>
		/// <param name="source"> Коллекция данных. </param>
		/// <returns> Коллекция данных. </returns>
		public static Collection<T> ToCollection<T>(this IEnumerable<T> source)
		{
			return new Collection<T>(new List<T>(source));
		}

		/// <summary>
		/// В коллекцию.
		/// </summary>
		/// <typeparam name="T"> Тип данных коллекции. </typeparam>
		/// <param name="response"> Ответ vk.com. </param>
		/// <param name="selector"> Функция выборки. </param>
		/// <returns> Коллекция данных. </returns>
		public static Collection<T> ToCollectionOf<T>(this VkResponse response, Func<VkResponse, T> selector) //where T : class
		{
			if (response == null)
			{
				return new Collection<T>(new List<T>());
			}

			var responseArray = (VkResponseArray) response;

			if (responseArray == null) //TODO: V3022 http://www.viva64.com/en/w/V3022 Expression 'responseArray == null' is always false.
			{
				return new Collection<T>(new List<T>());
			}

			return
				responseArray.Select(selector)
					.Where(i => i != null)
					.ToCollection(); //TODO: V3111 http://www.viva64.com/en/w/V3111 Checking value of 'i' for null will always return false when generic type is instantiated with a value type.
		}

		// --------------------------------------------------------------------------------------------
		/// <summary>
		/// В коллекцию только для чтения.
		/// </summary>
		/// <typeparam name="T"> Тип данных коллекции. </typeparam>
		/// <param name="source"> Коллекция данных. </param>
		/// <returns> Коллекция данных только для чтения. </returns>
		public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> source)
		{
			return new ReadOnlyCollection<T>(new List<T>(source));
		}

		/// <summary>
		/// В коллекцию только для чтения.
		/// </summary>
		/// <typeparam name="T"> Тип данных коллекции. </typeparam>
		/// <param name="response"> Ответ vk.com. </param>
		/// <param name="selector"> Функция выборки. </param>
		/// <returns> Коллекция данных только для чтения. </returns>
		public static ReadOnlyCollection<T>
			ToReadOnlyCollectionOf<T>(this VkResponse response, Func<VkResponse, T> selector) // where T : class
		{
			if (response == null)
			{
				return new ReadOnlyCollection<T>(new List<T>());
			}

			var responseArray = (VkResponseArray) response;

			if (responseArray == null) //TODO: V3022 http://www.viva64.com/en/w/V3022 Expression 'responseArray == null' is always false.
			{
				return new ReadOnlyCollection<T>(new List<T>());
			}

			return responseArray.Select(selector).Where(i => i != null).ToReadOnlyCollection();
		}

		/// <summary>
		/// В коллекцию только для чтения.
		/// </summary>
		/// <typeparam name="T"> Тип данных коллекции. </typeparam>
		/// <param name="response"> Ответ vk.com. </param>
		/// <returns> Коллекция данных только для чтения. </returns>
		public static ReadOnlyCollection<T>
			ToReadOnlyCollectionOf<T>(this VkResponse response)
			where T : class
		{
			if (response == null)
			{
				return new ReadOnlyCollection<T>(new List<T>());
			}

			var responseArray = (VkResponseArray) response;

			if (responseArray == null) //TODO: V3022 http://www.viva64.com/en/w/V3022 Expression 'responseArray == null' is always false.
			{
				return new ReadOnlyCollection<T>(new List<T>());
			}

			return responseArray.Select(x => x as T).Where(i => i != null).ToReadOnlyCollection();
		}

		/// <summary>
		/// В коллекцию только для чтения.
		/// </summary>
		/// <typeparam name="T"> Тип данных коллекции. </typeparam>
		/// <param name="responses"> Коллекция ответов от vk.com. </param>
		/// <param name="selector"> Функция выборки. </param>
		/// <returns> Коллекция данных только для чтения. </returns>
		public static ReadOnlyCollection<T> ToReadOnlyCollectionOf<T>(this IEnumerable<VkResponse> responses, Func<VkResponse, T> selector)
		{
			return responses == null
				? new ReadOnlyCollection<T>(new List<T>())
				: responses.Select(selector).ToReadOnlyCollection();
		}

		// --------------------------------------------------------------------------------------------
		/// <summary>
		/// В список.
		/// </summary>
		/// <typeparam name="T"> Тип данных списка. </typeparam>
		/// <param name="response"> Ответ vk.com. </param>
		/// <param name="selector"> Функция выборки. </param>
		/// <returns>
		/// Список данных.
		/// </returns>
		public static List<T> ToListOf<T>(this VkResponse response, Func<VkResponse, T> selector)
		{
			if (response == null)
			{
				return new List<T>();
			}

			var responseArray = (VkResponseArray) response;

			if (responseArray == null) //TODO: V3022 http://www.viva64.com/en/w/V3022 Expression 'responseArray == null' is always false.
			{
				return new List<T>();
			}

			return
				responseArray.Select(selector)
					.Where(i => i != null)
					.ToList(); //TODO: V3111 http://www.viva64.com/en/w/V3111 Checking value of 'i' for null will always return false when generic type is instantiated with a value type.
		}

		/// <summary>
		/// В список.
		/// </summary>
		/// <typeparam name="T"> Тип данных списка. </typeparam>
		/// <param name="responses"> Ответ vk.com. </param>
		/// <param name="selector"> Функция выборки. </param>
		/// <returns>
		/// Список данных.
		/// </returns>
		public static List<T> ToListOf<T>(this IEnumerable<VkResponse> responses, Func<VkResponse, T> selector)
		{
			return responses == null ? new List<T>() : responses.Select(selector).ToList();
		}

		// --------------------------------------------------------------------------------------------

		/// <summary>
		/// В специальную коллекцию данных vk с общим количеством.
		/// </summary>
		/// <typeparam name="T"> Тип данных </typeparam>
		/// <param name="response"> Ответ vk.com. </param>
		/// <param name="selector"> Функция выборки. </param>
		/// <param name="arrayName"> Наименование поля массива </param>
		/// <returns> Специальная коллекция данных vk с общим количеством. </returns>
		public static VkCollection<T> ToVkCollectionOf<T>(this VkResponse response
														, Func<VkResponse, T> selector
														, string arrayName = "items")
		{
			if (response == null)
			{
				return new VkCollection<T>(0, Enumerable.Empty<T>());
			}

			VkResponseArray data = response.ContainsKey(arrayName)
				? response[arrayName]
				: response;

			var resultCollection = data.ToReadOnlyCollectionOf(selector);

			var totalCount = response.ContainsKey("count")
				? response["count"]
				: (ulong) resultCollection.Count;

			return new VkCollection<T>(totalCount, resultCollection);
		}

		/// <summary>
		/// Преобразовать <see cref="VkResponse" /> к <see cref="IConvertible" />
		/// </summary>
		/// <param name="response"> Ответ vk.com. </param>
		/// <typeparam name="T"> Тип перечисления </typeparam>
		/// <returns> </returns>
		public static T ToEnum<T>(this VkResponse response)
			where T : IConvertible
		{
			return response == null
				? default(T)
				: Utilities.EnumFrom<T>(response);
		}

		/// <summary>
		/// Проверка что строка является JSON
		/// </summary>
		/// <param name="input"> </param>
		/// <returns> </returns>
		public static bool IsValidJson(string input)
		{
			input = input.Trim();

			if ((!input.StartsWith("{")
				|| !input.EndsWith("}"))
				&& (!input.StartsWith("[")
					|| !input.EndsWith("]")))
			{
				return false;
			}

			try
			{
				var obj = JToken.Parse(input);

				return true;
			}
			catch (JsonReaderException jex)
			{
				//Exception in parsing json
				Console.WriteLine(jex.Message);

				return false;
			}
			catch (System.Exception ex) //some other exception
			{
				Console.WriteLine(ex.ToString());

				return false;
			}
		}
	}
}