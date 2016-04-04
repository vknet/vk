﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace VkNet.Utils
{
	/// <summary>
	/// Коллекция данных возвращенных от vk.com
	/// </summary>
	/// <typeparam name="T">Тип данных.</typeparam>
	public class VkCollection<T> : ReadOnlyCollection<T>, IEnumerable<T>
	{
		/// <summary>
		/// Общее количество элементов.
		/// </summary>
		public ulong TotalCount { get; private set; }

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="totalCount">Общее количество.</param>
		/// <param name="list">Список элементов.</param>
		public VkCollection(ulong totalCount, IEnumerable<T> list) : base(list.ToList())
		{
			TotalCount = totalCount;
		}

		/// <summary>
		/// Текущий элемент.
		/// </summary>
		/// <param name="index">Индекс.</param>
		public new T this[int index] => Items[index];

		/// <summary>
		/// Возвращает перечислитель, выполняющий итерацию в коллекции.
		/// </summary>
		/// <returns>
		/// Интерфейс <see cref="T:System.Collections.Generic.IEnumerator`1"/>, который может использоваться для перебора элементов коллекции.
		/// </returns>
		public new IEnumerator<T> GetEnumerator() => Items.GetEnumerator();
	}
}