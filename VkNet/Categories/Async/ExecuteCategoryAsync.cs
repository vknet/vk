using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
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
		public ExecuteCategory(IVkApi vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public Task<VkResponse> ExecuteAsync(string code, VkParameters vkParameters = default)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Execute(code, vkParameters));
		}

		/// <inheritdoc />
		public Task<T> ExecuteAsync<T>(string code, VkParameters vkParameters = default)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Execute<T>(code, vkParameters));
		}

		/// <inheritdoc />
		public Task<T> StoredProcedureAsync<T>(string procedureName, VkParameters vkParameters)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				StoredProcedure<T>(procedureName, vkParameters));
		}
	}
}