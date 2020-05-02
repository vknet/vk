using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IWidgetsCategoryAsync"/>
	public interface IWidgetsCategory : IWidgetsCategoryAsync
	{
		/// <inheritdoc cref="IWidgetsCategoryAsync.GetCommentsAsync"/>
		VkCollection<Comment> GetComments(GetCommentsParams getCommentsParams);

		/// <inheritdoc cref="IWidgetsCategoryAsync.GetPagesAsync"/>
		VkCollection<WidgetPage> GetPages(long? widgetApiId = null
										, string order = null
										, string period = null
										, ulong? offset = null
										, ulong? count = null);
	}
}