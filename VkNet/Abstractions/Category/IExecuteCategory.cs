using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IExecuteCategoryAsync" />
	public interface IExecuteCategory : IExecuteCategoryAsync
	{
		/// <inheritdoc cref="IExecuteCategoryAsync.ExecuteAsync"/>
		VkResponse Execute(string code, VkParameters vkParameters = default);

		/// <inheritdoc cref="IExecuteCategoryAsync.ExecuteAsync"/>
		T Execute<T>(string code, VkParameters vkParameters = default);

		/// <inheritdoc cref="IExecuteCategoryAsync.ExecuteAsync"/>
		T StoredProcedure<T>(string procedureName, VkParameters vkParameters);
	}
}