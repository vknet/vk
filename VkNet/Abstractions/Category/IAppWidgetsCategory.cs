using System;
using System.Collections.ObjectModel;
using VkNet.Abstractions.Category;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;

namespace VkNet.Abstractions
{
	/// <inheritdoc />
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

		//TODO: TEST IT!!
		/// <inheritdoc cref="IAppWidgetsCategoryAsync.UpdateAsync"/>
		bool Update(string code, AppWidgetType type);
	}
}