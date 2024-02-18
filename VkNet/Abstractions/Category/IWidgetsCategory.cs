using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с виджетами на внешних сайтах.
/// </summary>
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