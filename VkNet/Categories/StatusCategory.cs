using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class StatusCategory : IStatusCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// api vk.com
		/// </summary>
		/// <param name="vk"> </param>
		public StatusCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		[Pure]
		public Status Get(long userId, long? groupId = null)
		{
			var parameters = new VkParameters
			{
					{ "user_id", userId }
					, { "group_id", groupId }
			};

			return _vk.Call(methodName: "status.get", parameters: parameters);
		}

		/// <inheritdoc />
		public bool Set(string text, long? groupId = null)
		{
			var parameters = new VkParameters
			{
					{ "text", text }
					, { "group_id", groupId }
			};

			return _vk.Call(methodName: "status.set", parameters: parameters);
		}
	}
}