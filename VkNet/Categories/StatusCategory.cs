using System.Threading;
using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Model;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class StatusCategory : IStatusCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
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
			return GetAsync(userId, groupId, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool Set(string text, long? groupId = null)
		{
			return SetAsync(text, groupId, CancellationToken.None).GetAwaiter().GetResult();
		}
	}
}