using System.Threading;
using VkNet.Abstractions;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы этого класса позволяют производить действия с универсальным методом.
	/// </summary>
	public partial class ExecuteCategory : IExecuteCategory
	{
		/// <inheritdoc />
		public VkResponse Execute(string code)
		{
			return ExecuteAsync(code, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public T Execute<T>(string code)
		{
			return ExecuteAsync<T>(code, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public T StoredProcedure<T>(string procedureName, VkParameters vkParameters)
		{
			return StoredProcedureAsync<T>(procedureName, vkParameters, CancellationToken.None).GetAwaiter().GetResult();
		}
	}
}