using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
			return new Collection<T>(list: new List<T>(collection: source));
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
				return new Collection<T>(list: new List<T>());
			}

			var responseArray = (VkResponseArray) response;

			if (responseArray == null) //TODO: V3022 http://www.viva64.com/en/w/V3022 Expression 'responseArray == null' is always false.
			{
				return new Collection<T>(list: new List<T>());
			}

			return
					responseArray.Select(selector: selector)
							.Where(predicate: i => i != null)
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
			return new ReadOnlyCollection<T>(list: new List<T>(collection: source));
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
				return new ReadOnlyCollection<T>(list: new List<T>());
			}

			var responseArray = (VkResponseArray) response;

			if (responseArray == null) //TODO: V3022 http://www.viva64.com/en/w/V3022 Expression 'responseArray == null' is always false.
			{
				return new ReadOnlyCollection<T>(list: new List<T>());
			}

			return responseArray.Select(selector: selector).Where(predicate: i => i != null).ToReadOnlyCollection();
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
			if (responses == null)
			{
				return new ReadOnlyCollection<T>(list: new List<T>());
			}

			return responses.Select(selector: selector).ToReadOnlyCollection();
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
					responseArray.Select(selector: selector)
							.Where(predicate: i => i != null)
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
			if (responses == null)
			{
				return new List<T>();
			}

			return responses.Select(selector: selector).ToList();
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
				return new VkCollection<T>(totalCount: 0, list: Enumerable.Empty<T>());
			}

			VkResponseArray data = response.ContainsKey(key: arrayName)
					? response[key: arrayName]
					: response;

			var resultCollection = data.ToReadOnlyCollectionOf(selector: selector);

			var totalCount = response.ContainsKey(key: "count")
					? response[key: "count"]
					: (ulong) resultCollection.Count;

			return new VkCollection<T>(totalCount: totalCount, list: resultCollection);
		}
	}
}