using System.Collections.ObjectModel;
using VkNet.Enums.SafetyEnums;
using VkNet.Enums.StringEnums;
using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// Список методов секции appWidgets
/// </summary>
public interface IAppWidgetsCategory : IAppWidgetsCategoryAsync
{
	/// <inheritdoc cref="IAppWidgetsCategoryAsync.GetAppImageUploadServerAsync"/>
	UploadServerInfo GetAppImageUploadServer(AppWidgetImageType imageType);

	/// <inheritdoc cref="IAppWidgetsCategoryAsync.GetAppImagesAsync"/>
	AppImageResult GetAppImages(int offset, int count, AppWidgetImageType imageType);

	/// <inheritdoc cref="IAppWidgetsCategoryAsync.GetGroupImageUploadServerAsync"/>
	UploadServerInfo GetGroupImageUploadServer(AppWidgetImageType imageType);

	/// <inheritdoc cref="IAppWidgetsCategoryAsync.GetGroupImagesAsync"/>
	AppImageResult GetGroupImages(int offset, int count, AppWidgetImageType imageType);

	/// <inheritdoc cref="IAppWidgetsCategoryAsync.GetImagesByIdAsync"/>
	ReadOnlyCollection<AppImage> GetImagesById(string images);

	/// <inheritdoc cref="IAppWidgetsCategoryAsync.SaveAppImageAsync"/>
	AppImage SaveAppImage(string hash, string image);

	/// <inheritdoc cref="IAppWidgetsCategoryAsync.SaveGroupImageAsync"/>
	AppImage SaveGroupImage(string hash, string image);

	/// <inheritdoc cref="IAppWidgetsCategoryAsync.UpdateAsync"/>
	bool Update(string code, AppWidgetType type);
}