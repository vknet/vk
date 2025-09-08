using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace VkNet.Utils;

/// <summary>
/// Массив
/// </summary>
public sealed class VkResponseArray : IEnumerable<VkResponse>
{
	/// <summary>
	/// Массив
	/// </summary>
	private readonly JArray _array;

	/// <summary>
	/// Инициализация нового массива.
	/// </summary>
	/// <param name="array"> Массив. </param>
	public VkResponseArray(JArray array) => _array = array;

	/// <summary>
	/// Взять VkResponse
	/// </summary>
	/// <value>
	/// The VkResponse
	/// </value>
	/// <param name="key"> Ключ. </param>
	/// <returns> Текущий объект </returns>
	public VkResponse this[object key]
	{
		get {
			var token = _array[key: key];

			return new(token: token);
		}
	}

	/// <summary>
	/// Количество.
	/// </summary>
	/// <value>
	/// Количество.
	/// </value>
	public int Count => _array.Count;

	/// <inheritdoc />
	public IEnumerator<VkResponse> GetEnumerator() => _array.Select(selector: i => new VkResponse(token: i))
		.GetEnumerator();

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}