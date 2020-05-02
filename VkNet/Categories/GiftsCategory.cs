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
		public VkCollection<GiftItem> Get(long? userId = null, int? count = null, int? offset = null)
		{
			var parameters = new VkParameters
			{
				{ "user_id", userId },
				{ "count", count },
				{ "offset", offset }
			};

			return _vk.Call<VkCollection<GiftItem>>("gifts.get", parameters);
		}
	}
}