using System;
using VkNet.Abstractions.Category;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Abstractions
{
	/// <inheritdoc />
	public interface IAppWidgetsCategory : IAppWidgetsCategoryAsync
	{
		/// <inheritdoc cref="IAppWidgetsCategoryAsync.GetAppImageUploadServerAsync"/>
		Uri GetAppImageUploadServer(AppWidgetImageType imageType);

		/// <inheritdoc cref="IAppWidgetsCategoryAsync.GetAppImagesAsync"/>
		Uri GetAppImages(int offset, int count, AppWidgetImageType imageType);

		/// <inheritdoc cref="IAppWidgetsCategoryAsync.GetGroupImageUploadServerAsync"/>
		Uri GetGroupImageUploadServer(AppWidgetImageType imageType);

		/// <inheritdoc cref="IAppWidgetsCategoryAsync.GetGroupImagesAsync"/>
		Uri GetGroupImages(int offset, int count, AppWidgetImageType imageType);

		/// <inheritdoc cref="IAppWidgetsCategoryAsync.GetImagesByIdAsync"/>
		Uri GetImagesById(string images);

		/// <inheritdoc cref="IAppWidgetsCategoryAsync.SaveAppImageAsync"/>
		Uri SaveAppImage(string hash, string image);

		/// <inheritdoc cref="IAppWidgetsCategoryAsync.SaveGroupImageAsync"/>
		Uri SaveGroupImage();

		/// <inheritdoc cref="IAppWidgetsCategoryAsync.UpdateAsync"/>
		bool Update();
	}
}