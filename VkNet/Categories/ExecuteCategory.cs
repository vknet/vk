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
			return _vk.Call(methodName: "execute", parameters: new VkParameters { { "code", code } });
		}

		/// <inheritdoc />
		public T Execute<T>(string code)
		{
			return _vk.Call<T>(methodName: "execute", parameters: new VkParameters { { "code", code } });
		}

		/// <inheritdoc />
		public T StoredProcedure<T>(string procedureName, VkParameters vkParameters)
		{
			return _vk.Call<T>(methodName: $"execute.{procedureName}", parameters: vkParameters);
		}
	}
}