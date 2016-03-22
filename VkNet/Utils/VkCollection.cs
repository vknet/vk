using System.Collections;

namespace VkNet.Utils
{
	/// <summary>
	/// Коллекция данных возвращенных от vk.com
	/// </summary>
	/// <typeparam name="T">Тип данных.</typeparam>
	public class VkCollection<T> : ReadOnlyCollectionBase where T: class, IVkModel, new()
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
	}
}