using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с универсальным методом.
	/// </summary>
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
		public Task<VkResponse> ExecuteAsync(string code, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync("execute",
				new VkParameters
				{
					{ "code", code }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<T> ExecuteAsync<T>(string code, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<T>("execute",
				new VkParameters
				{
					{ "code", code }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<T> StoredProcedureAsync<T>(string procedureName,
												VkParameters vkParameters,
												CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<T>($"execute.{procedureName}", vkParameters, cancellationToken: cancellationToken);
		}
	}
}