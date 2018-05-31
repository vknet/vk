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
		private readonly VkApi _vk;

		/// <inheritdoc />
		/// <param name="api">
		/// Api vk.com
		/// </param>
		internal WidgetsCategory(VkApi api = null)
		{
			_vk = api;
		}

		/// <inheritdoc />
		public VkCollection<Comment> GetComments(GetCommentsParams getCommentsParams)
		{
			return _vk.Call<VkCollection<Comment>>("widgets.getComments"
					, getCommentsParams
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