using System.Threading;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class GiftsCategory : IGiftsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Методы для работы с подарками.
		/// </summary>
		/// <param name="vk"> API. </param>
		public GiftsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public VkCollection<GiftItem> Get(long userId, int? count = null, int? offset = null)
		{
			return GetAsync(userId, count, offset, CancellationToken.None).GetAwaiter().GetResult();
		}
	}
}