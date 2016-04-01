namespace VkNet.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

	/// <summary>
	/// Методы расширения для ответов vk.com
	/// </summary>
	internal static class VkResponseEx
    {
		/// <summary>
		/// В коллекцию.
		/// </summary>
		/// <typeparam name="T">Тип данных коллекции.</typeparam>
		/// <param name="source">Коллекция данных.</param>
		/// <returns>Коллекция данных.</returns>
		public static Collection<T> ToCollection<T>(this IEnumerable<T> source)
        {
            return new Collection<T>(new List<T>(source));
        }

		/// <summary>
		/// В коллекцию.
		/// </summary>
		/// <typeparam name="T">Тип данных коллекции.</typeparam>
		/// <param name="response">Ответ vk.com.</param>
		/// <param name="selector">Функция выборки.</param>
		/// <returns>Коллекция данных.</returns>
		public static Collection<T> ToCollectionOf<T>(this VkResponse response, Func<VkResponse, T> selector) //where T : class
        {
	        if (response == null)
	        {
		        return new Collection<T>(new List<T>());
	        }

            var responseArray = (VkResponseArray) response;
	        if (responseArray == null)
	        {
		        return new Collection<T>(new List<T>());
	        }

            return responseArray.Select(selector).Where(i => i != null).ToCollection();
        }

		/// <summary>
		/// В коллекцию.
		/// </summary>
		/// <typeparam name="T">Тип данных коллекции.</typeparam>
		/// <param name="responses">Коллекция ответов от vk.com.</param>
		/// <param name="selector">Функция выборки.</param>
		/// <returns>Коллекция данных.</returns>
		public static Collection<T> ToCollectionOf<T>(this IEnumerable<VkResponse> responses, Func<VkResponse, T> selector)
        {
	        if (responses == null)
	        {
		        return new Collection<T>(new List<T>());
	        }

            return responses.Select(selector).ToCollection();
        }

		// --------------------------------------------------------------------------------------------
		/// <summary>
		/// В коллекцию только для чтения.
		/// </summary>
		/// <typeparam name="T">Тип данных коллекции.</typeparam>
		/// <param name="source">Коллекция данных.</param>
		/// <returns>Коллекция данных только для чтения.</returns>
		public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> source)
        {
            return new ReadOnlyCollection<T>(new List<T>(source));
        }

		/// <summary>
		/// В коллекцию только для чтения.
		/// </summary>
		/// <typeparam name="T">Тип данных коллекции.</typeparam>
		/// <param name="response">Ответ vk.com.</param>
		/// <param name="selector">Функция выборки.</param>
		/// <returns>Коллекция данных только для чтения.</returns>
		public static ReadOnlyCollection<T> ToReadOnlyCollectionOf<T>(
            this VkResponse response, Func<VkResponse, T> selector) where T : class
        {
	        if (response == null)
	        {
		        return new ReadOnlyCollection<T>(new List<T>());
	        }

            var responseArray = (VkResponseArray)response;
	        if (responseArray == null)
	        {
		        return new ReadOnlyCollection<T>(new List<T>());
	        }

            return responseArray.Select(selector).Where(i => i != null).ToReadOnlyCollection();
        }

		/// <summary>
		/// В коллекцию только для чтения.
		/// </summary>
		/// <typeparam name="T">Тип данных коллекции.</typeparam>
		/// <param name="responses">Коллекция ответов от vk.com.</param>
		/// <param name="selector">Функция выборки.</param>
		/// <returns>Коллекция данных только для чтения.</returns>
		public static ReadOnlyCollection<T> ToReadOnlyCollectionOf<T>(this IEnumerable<VkResponse> responses, Func<VkResponse, T> selector)
        {
	        if (responses == null)
	        {
		        return new ReadOnlyCollection<T>(new List<T>());
	        }

            return responses.Select(selector).ToReadOnlyCollection();
        }

		// --------------------------------------------------------------------------------------------
		/// <summary>
		/// В список.
		/// </summary>
		/// <typeparam name="T">Тип данных списка.</typeparam>
		/// <param name="response">Ответ vk.com.</param>
		/// <param name="selector">Функция выборки.</param>
		/// <returns>
		/// Список данных.
		/// </returns>
		public static List<T> ToListOf<T>(this VkResponse response, Func<VkResponse, T> selector)
        {
	        if (response == null)
	        {
		        return new List<T>();
	        }

            var responseArray = (VkResponseArray)response;
	        if (responseArray == null)
	        {
		        return new List<T>();
	        }

            return responseArray.Select(selector).Where(i => i != null).ToList();
        }

		/// <summary>
		/// В список.
		/// </summary>
		/// <typeparam name="T">Тип данных списка.</typeparam>
		/// <param name="responses">Ответ vk.com.</param>
		/// <param name="selector">Функция выборки.</param>
		/// <returns>
		/// Список данных.
		/// </returns>
		public static List<T> ToListOf<T>(this IEnumerable<VkResponse> responses, Func<VkResponse, T> selector)
        {
	        if (responses == null)
	        {
		        return new List<T>();
	        }

            return responses.Select(selector).ToList();
        }
		// --------------------------------------------------------------------------------------------

		/// <summary>
		/// В специальную коллекцию данных vk с общим количеством.
		/// </summary>
		/// <typeparam name="T">Тип данных</typeparam>
		/// <param name="response">Ответ vk.com.</param>
		/// <param name="selector">Функция выборки.</param>
		/// <returns>Специальная коллекция данных vk с общим количеством.</returns>
		public static VkCollection<T> ToVkCollectionOf<T>(this VkResponse response, Func<VkResponse, T> selector)
		{
			if (response == null)
			{
				return new VkCollection<T>(0, Enumerable.Empty<T>());
			}

			VkResponseArray data = response.ContainsKey("items") ?
				response["items"]
				: response;

			var resultCollection = data.ToCollectionOf(selector);

			var totalCount = response.ContainsKey("count") ?
				response["count"]
				: (ulong) resultCollection.Count;

			return new VkCollection<T>(totalCount, resultCollection);
		}
	}
}