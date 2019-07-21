using System.Threading;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class SearchCategory : ISearchCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <inheritdoc />
		public SearchCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public VkCollection<SearchHintsItem> GetHints(SearchGetHintsParams @params)
		{
			return GetHintsAsync(@params, CancellationToken.None).GetAwaiter().GetResult();
		}
	}
}