using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class AppWidgetsCategory
	{
		/// <inheritdoc/>
		public Task<UploadServerInfo> GetAppImageUploadServerAsync(AppWidgetImageType imageType)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAppImageUploadServer(imageType));
		}

		/// <inheritdoc/>
		public Task<AppImageResult> GetAppImagesAsync(int offset, int count, AppWidgetImageType imageType)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAppImages(offset, count, imageType));
		}

		/// <inheritdoc/>
		public Task<UploadServerInfo> GetGroupImageUploadServerAsync(AppWidgetImageType imageType)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetGroupImageUploadServer(imageType));
		}

		/// <inheritdoc/>
		public Task<AppImageResult> GetGroupImagesAsync(int offset, int count, AppWidgetImageType imageType)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetGroupImages(offset, count, imageType));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<AppImage>> GetImagesByIdAsync(string images)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetImagesById(images));
		}

		/// <inheritdoc/>
		public Task<AppImage> SaveAppImageAsync(string hash, string image)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SaveAppImage(hash, image));
		}

		/// <inheritdoc/>
		public Task<AppImage> SaveGroupImageAsync(string hash, string image)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SaveGroupImage(hash, image));
		}

		/// <inheritdoc/>
		public Task<bool> UpdateAsync(string code, AppWidgetType type)
		{
			return TypeHelper.TryInvokeMethodAsync((() => Update(code, type)));
		}
	}
}