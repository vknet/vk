using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IAppWidgetsCategory" />
public partial class AppWidgetsCategory
{
	/// <inheritdoc/>
	public Task<UploadServerInfo> GetAppImageUploadServerAsync(AppWidgetImageType imageType,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAppImageUploadServer(imageType), token);

	/// <inheritdoc/>
	public Task<AppImageResult> GetAppImagesAsync(int offset,
												int count,
												AppWidgetImageType imageType,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAppImages(offset, count, imageType), token);

	/// <inheritdoc/>
	public Task<UploadServerInfo> GetGroupImageUploadServerAsync(AppWidgetImageType imageType,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetGroupImageUploadServer(imageType), token);

	/// <inheritdoc/>
	public Task<AppImageResult> GetGroupImagesAsync(int offset,
													int count,
													AppWidgetImageType imageType,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetGroupImages(offset, count, imageType), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<AppImage>> GetImagesByIdAsync(string images,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetImagesById(images), token);

	/// <inheritdoc/>
	public Task<AppImage> SaveAppImageAsync(string hash,
											string image,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SaveAppImage(hash, image), token);

	/// <inheritdoc/>
	public Task<AppImage> SaveGroupImageAsync(string hash,
											string image,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SaveGroupImage(hash, image), token);

	/// <inheritdoc/>
	public Task<bool> UpdateAsync(string code,
								AppWidgetType type,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Update(code, type), token);
}