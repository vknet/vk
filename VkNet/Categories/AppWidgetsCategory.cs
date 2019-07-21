using System;
using System.Threading;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class AppWidgetsCategory : IAppWidgetsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <inheritdoc/>
		/// <param name = "api">
		/// Api vk.com
		/// </param>
		public AppWidgetsCategory(IVkApiInvoke api)
		{
			_vk = api;
		}

		/// <inheritdoc/>
		public Uri GetAppImageUploadServer(AppWidgetImageType imageType)
		{
			return GetAppImageUploadServerAsync(imageType, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc/>
		public Uri GetAppImages(int offset, int count, AppWidgetImageType imageType)
		{
			return GetAppImagesAsync(offset, count, imageType, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc/>
		public Uri GetGroupImageUploadServer(AppWidgetImageType imageType)
		{
			return GetGroupImageUploadServerAsync(imageType, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc/>
		public Uri GetGroupImages(int offset, int count, AppWidgetImageType imageType)
		{
			return GetGroupImagesAsync(offset, count, imageType, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <param name="images"></param>
		/// <inheritdoc/>
		public Uri GetImagesById(string images)
		{
			return GetImagesByIdAsync(images, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc/>
		public Uri SaveAppImage(string hash, string image)
		{
			return SaveAppImageAsync(hash, image).GetAwaiter().GetResult();
		}

		/// <inheritdoc/>
		public Uri SaveGroupImage()
		{
			return SaveGroupImageAsync(CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc/>
		public bool Update()
		{
			return UpdateAsync(CancellationToken.None).GetAwaiter().GetResult();
		}
	}
}