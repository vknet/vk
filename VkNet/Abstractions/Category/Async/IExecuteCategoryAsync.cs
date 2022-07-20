using System.Threading.Tasks;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы этого класса позволяют производить действия с универсальным
	/// методом.
	/// </summary>
	public interface IExecuteCategoryAsync
	{
		/// <summary>
		/// Универсальный метод, который позволяет запускать последовательность других
		/// методов, сохраняя и фильтруя
		/// промежуточные результаты.
		/// </summary>
		/// <param name="code">
		/// Код алгоритма в VKScript - формате, похожем на JavaSсript или ActionScript
		/// (предполагается совместимость с
		/// ECMAScript).
		/// Алгоритм должен завершаться командой return %выражение%. Операторы должны быть
		/// разделены точкой с запятой.
		/// </param>
		/// <param name="vkParameters"></param>
		/// <returns>
		/// Возвращает данные, запрошенные алгоритмом.
		/// При работе с методом execute структура ответа в XML ближе к JSON и может
		/// незначительно отличаться от стандартного
		/// представления других методов.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/execute
		/// </remarks>
		Task<VkResponse> ExecuteAsync(string code, VkParameters vkParameters = default);

		/// <summary>
		/// Универсальный метод, который позволяет запускать последовательность других
		/// методов, сохраняя и фильтруя
		/// промежуточные результаты.
		/// </summary>
		/// <param name="code">
		/// Код алгоритма в VKScript - формате, похожем на JavaSсript или ActionScript
		/// (предполагается совместимость с
		/// ECMAScript).
		/// Алгоритм должен завершаться командой return %выражение%. Операторы должны быть
		/// разделены точкой с запятой.
		/// </param>
		/// <param name="vkParameters"></param>
		/// <returns>
		/// Возвращает данные, запрошенные алгоритмом.
		/// При работе с методом execute структура ответа в XML ближе к JSON и может
		/// незначительно отличаться от стандартного
		/// представления других методов.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/execute
		/// </remarks>
		Task<T> ExecuteAsync<T>(string code, VkParameters vkParameters = default);

		/// <summary>
		/// Универсальный метод, который позволяет запускать хранимые процедуры.
		/// </summary>
		/// <param name="procedureName"> Имя хранимой процедуры </param>
		/// <param name="vkParameters"> Параметры хранимой процедуры </param>
		/// <returns>
		/// Возвращает данные, запрошенные алгоритмом.
		/// При работе с методом execute структура ответа в XML ближе к JSON и может
		/// незначительно отличаться от стандартного
		/// представления других методов.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/execute
		/// </remarks>
		Task<T> StoredProcedureAsync<T>(string procedureName, VkParameters vkParameters);
	}
}