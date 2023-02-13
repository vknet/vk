using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc/>
public partial class AppWidgetsCategory
{
	/// <inheritdoc/>
	public Task<UploadServerInfo> GetAppImageUploadServerAsync(AppWidgetImageType imageType) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAppImageUploadServer(imageType));

	/// <inheritdoc/>
	public Task<AppImageResult> GetAppImagesAsync(int offset, int count, AppWidgetImageType imageType) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAppImages(offset, count, imageType));

	/// <inheritdoc/>
	public Task<UploadServerInfo> GetGroupImageUploadServerAsync(AppWidgetImageType imageType) =>
		TypeHelper.TryInvokeMethodAsync(() => GetGroupImageUploadServer(imageType));

	/// <inheritdoc/>
	public Task<AppImageResult> GetGroupImagesAsync(int offset, int count, AppWidgetImageType imageType) =>
		TypeHelper.TryInvokeMethodAsync(() => GetGroupImages(offset, count, imageType));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<AppImage>> GetImagesByIdAsync(string images) =>
		TypeHelper.TryInvokeMethodAsync(() => GetImagesById(images));

	/// <inheritdoc/>
	public Task<AppImage> SaveAppImageAsync(string hash, string image) => TypeHelper.TryInvokeMethodAsync(() => SaveAppImage(hash, image));

	/// <inheritdoc/>
	public Task<AppImage> SaveGroupImageAsync(string hash, string image) =>
		TypeHelper.TryInvokeMethodAsync(() => SaveGroupImage(hash, image));

	/// <inheritdoc/>
	public Task<bool> UpdateAsync(string code, AppWidgetType type) => TypeHelper.TryInvokeMethodAsync(() => Update(code, type));
}