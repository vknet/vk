using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VkNet.Utils
{
	/// <summary>
	/// Коллекция данных возвращенных от vk.com
	/// </summary>
	/// <typeparam name="T">Тип данных.</typeparam>
	public class VkCollection<T> : ReadOnlyCollectionBase, IEnumerable<T> where T : class, IVkModel, new()
	{
		/// <summary>
		/// Общее количество элементов.
		/// </summary>
		public ulong TotalCount { get; set; }

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="response">Ответ от сервера.</param>
		public VkCollection(VkResponse response)
		{
			if (response.ContainsKey("count"))
			{
				TotalCount = response["count"];
			}

			if (response.ContainsKey("items"))
			{
				InnerList.AddRange(response["items"].ToReadOnlyCollectionOf(o => (T)new T().FromJson(o)));
			}
		}

		/// <summary>
		/// Текущий элемент.
		/// </summary>
		/// <param name="index">Индекс.</param>
		public T this[int index] => (T)InnerList[index];

		/// <summary>
		/// Возвращает перечислитель, выполняющий итерацию в коллекции.
		/// </summary>
		/// <returns>
		/// Интерфейс <see cref="T:System.Collections.Generic.IEnumerator`1"/>, который может использоваться для перебора элементов коллекции.
		/// </returns>
		public new IEnumerator<T> GetEnumerator() => InnerList.Cast<T>().GetEnumerator();
	}
}