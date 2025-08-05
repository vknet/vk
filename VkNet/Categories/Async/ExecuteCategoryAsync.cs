using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IExecuteCategory" />
public partial class ExecuteCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApi _vk;

	/// <summary>
	/// Методы для работы с универсальным методом.
	/// </summary>
	/// <param name="vk"> API. </param>
	public ExecuteCategory(IVkApi vk) => _vk = vk;

	/// <inheritdoc />
	public Task<VkResponse> ExecuteAsync(string code,
										VkParameters vkParameters = default,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Execute(code, vkParameters), token);

	/// <inheritdoc />
	public Task<T> ExecuteAsync<T>(string code,
									VkParameters vkParameters = default,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Execute<T>(code, vkParameters), token);

	/// <inheritdoc />
	public Task<T> StoredProcedureAsync<T>(string procedureName,
											VkParameters vkParameters,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			StoredProcedure<T>(procedureName, vkParameters), token);
}