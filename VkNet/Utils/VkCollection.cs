using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Utils
{
	/// <summary>
	/// Коллекция данных возвращенных от vk.com
	/// </summary>
	/// <typeparam name="T"> Тип данных. </typeparam>
	[Serializable]
	[JsonConverter(converterType: typeof(VkCollectionJsonConverter))]
	public class VkCollection<T> : ReadOnlyCollection<T>, IEnumerable<T>
	{
		/// <inheritdoc />
		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="totalCount"> Общее количество. </param>
		/// <param name="list"> Список элементов. </param>
		public VkCollection(ulong totalCount, IEnumerable<T> list) : base(list: list.ToList())
		{
			TotalCount = totalCount;
		}

		/// <summary>
		/// Общее количество элементов.
		/// </summary>
		[JsonProperty(propertyName: "count")]
		public ulong TotalCount { get; private set; }

		/// <summary>
		/// Текущий элемент.
		/// </summary>
		/// <param name="index"> Индекс. </param>
		public new T this[int index] => Items[index: index];

		/// <inheritdoc />
		/// <summary>
		/// Возвращает перечислитель, выполняющий итерацию в коллекции.
		/// </summary>
		/// <returns>
		/// Интерфейс T:System
		/// </returns>
		public new IEnumerator<T> GetEnumerator()
		{
			return Items.GetEnumerator();
		}
	}
}