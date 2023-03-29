using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc/>
public partial class AppWidgetsCategory
{
	/// <inheritdoc/>
	public Task<UploadServerInfo> GetAppImageUploadServerAsync(AppWidgetImageType imageType,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAppImageUploadServer(imageType));

	/// <inheritdoc/>
	public Task<AppImageResult> GetAppImagesAsync(int offset,
												int count,
												AppWidgetImageType imageType,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAppImages(offset, count, imageType));

	/// <inheritdoc/>
	public Task<UploadServerInfo> GetGroupImageUploadServerAsync(AppWidgetImageType imageType,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetGroupImageUploadServer(imageType));

	/// <inheritdoc/>
	public Task<AppImageResult> GetGroupImagesAsync(int offset,
													int count,
													AppWidgetImageType imageType,
													CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetGroupImages(offset, count, imageType));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<AppImage>> GetImagesByIdAsync(string images,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetImagesById(images));

	/// <inheritdoc/>
	public Task<AppImage> SaveAppImageAsync(string hash,
											string image,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => SaveAppImage(hash, image));

	/// <inheritdoc/>
	public Task<AppImage> SaveGroupImageAsync(string hash,
											string image,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => SaveGroupImage(hash, image));

	/// <inheritdoc/>
	public Task<bool> UpdateAsync(string code,
								AppWidgetType type,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => Update(code, type));
}