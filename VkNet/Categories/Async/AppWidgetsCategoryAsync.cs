using System;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class AppWidgetsCategory
	{
		/// <inheritdoc/>
		public Task<Uri> GetAppImageUploadServerAsync(AppWidgetImageType imageType)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAppImageUploadServer(imageType));
		}

		/// <inheritdoc/>
		public Task<Uri> GetAppImagesAsync(int offset, int count, AppWidgetImageType imageType)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAppImages(offset, count, imageType));
		}

		/// <inheritdoc/>
		public Task<Uri> GetGroupImageUploadServerAsync(AppWidgetImageType imageType)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetGroupImageUploadServer(imageType));
		}

		/// <inheritdoc/>
		public Task<Uri> GetGroupImagesAsync(int offset, int count, AppWidgetImageType imageType)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetGroupImages(offset, count, imageType));
		}

		/// <inheritdoc/>
		public Task<Uri> GetImagesByIdAsync(string images)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetImagesById(images));
		}

		/// <inheritdoc/>
		public Task<Uri> SaveAppImageAsync(string hash, string image)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SaveAppImage(hash, image));
		}

		/// <inheritdoc/>
		public Task<Uri> SaveGroupImageAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(SaveGroupImage);
		}

		/// <inheritdoc/>
		public Task<bool> UpdateAsync(string code, string type)
		{
			return TypeHelper.TryInvokeMethodAsync((() => Update(code, type)));
		}
	}
}