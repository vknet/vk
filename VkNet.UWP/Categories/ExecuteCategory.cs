using System.Net;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы этого класса позволяют производить действия с универсальным методом.
	/// </summary>
	public class ExecuteCategory : IExecuteCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с универсальным методом.
		/// </summary>
		/// <param name="vk">API.</param>
		public ExecuteCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Универсальный метод, который позволяет запускать последовательность других методов, сохраняя и фильтруя промежуточные результаты.
		/// </summary>
		/// <param name="code">
		/// Код алгоритма в VKScript - формате, похожем на JavaSсript или ActionScript (предполагается совместимость с ECMAScript).
		/// Алгоритм должен завершаться командой return %выражение%. Операторы должны быть разделены точкой с запятой.
		/// </param>
		/// <returns>
		/// Возвращает данные, запрошенные алгоритмом.
		/// При работе с методом execute структура ответа в XML ближе к JSON и может незначительно отличаться от стандартного представления других методов.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/execute
		/// </remarks>
		public VkResponse Execute(string code)
		{
			return _vk.Call("execute", new VkParameters { { "code", code } });
		}
	}
}