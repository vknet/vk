using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Abstractions.Async;
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
			return _vk.Call("execute", new VkParameters { { "code", code } });
		}

		/// <inheritdoc />
		public T Execute<T>(string code)
		{
			return _vk.Call<T>("execute", new VkParameters { { "code", code } });
		}

		/// <inheritdoc />
		public T StoredProcedure<T>(string procedureName, VkParameters vkParameters)
		{
			return _vk.Call<T>($"execute.{procedureName}", vkParameters);
		}
	}
}