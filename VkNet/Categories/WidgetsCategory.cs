using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class WidgetsCategory : IWidgetsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Api vk.com
		/// </summary>
		/// <param name="vk">
		/// Api vk.com
		/// </param>
		internal WidgetsCategory(VkApi vk = null)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public VkCollection<Comment> GetComments(GetCommentsParams getCommentsParams)
		{
			return _vk.Call<VkCollection<Comment>>("widgets.getComments"
					, new VkParameters
					{
						{ "widget_api_id", getCommentsParams.WidgetApiId }
						, { "url", getCommentsParams.Url }
						, { "page_id", getCommentsParams.PageId }
						, { "order", getCommentsParams.Order }
						, { "fields", getCommentsParams.Fields }
						, { "offset", getCommentsParams.Offset }
						, { "count", getCommentsParams.Count }
					}
					, false
					, new VkCollectionJsonConverter(collectionField: "posts"));
		}

		/// <inheritdoc />
		public VkCollection<WidgetPage> GetPages(long? widgetApiId = null
												, string order = null
												, string period = null
												, ulong? offset = null
												, ulong? count = null)
		{
			return _vk.Call<VkCollection<WidgetPage>>("widgets.getPages"
					, new VkParameters
					{
							{ "widget_api_id", widgetApiId }
							, { "order", order }
							, { "period", period }
							, { "offset", offset }
							, { "count", count }
					}
					, false
					, new VkCollectionJsonConverter(collectionField: "pages"));
		}
	}
}