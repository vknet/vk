using VkNet.Abstractions;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class ExecuteCategory : IExecuteCategory
	{
		/// <inheritdoc />
		public VkResponse Execute(string code, VkParameters vkParameters = default)
		{
			var parameters = new VkParameters
			{
				{ "code", code }
			};

			if (vkParameters == default)
			{
				return _vk.Call("execute", parameters);
			}

			foreach (var pair in vkParameters)
			{
				parameters.Add(pair.Key, pair.Value);
			}

			return _vk.Call("execute", parameters);
		}

		/// <inheritdoc />
		public T Execute<T>(string code, VkParameters vkParameters = default)
		{
			var parameters = new VkParameters
			{
				{ "code", code }
			};

			if (vkParameters == default)
			{
				return _vk.Call<T>("execute", parameters);
			}

			foreach (var pair in vkParameters)
			{
				parameters.Add(pair.Key, pair.Value);
			}

			return _vk.Call<T>("execute", parameters);
		}

		/// <inheritdoc />
		public T StoredProcedure<T>(string procedureName, VkParameters vkParameters)
		{
			return _vk.Call<T>($"execute.{procedureName}", vkParameters);
		}
	}
}