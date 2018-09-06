using System;
using System.Threading.Tasks;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class AppWidgetsCategory
	{
		/// <inheritdoc/>
		public async Task<Uri> GetAppImageUploadServerAsync(object imageType)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetAppImageUploadServer(imageType));
		}

		/// <inheritdoc/>
		public Task<Uri> GetAppImagesAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(GetAppImages);
		}

		/// <inheritdoc/>
		public Task<Uri> GetGroupImageUploadServerAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(GetGroupImageUploadServer);
		}

		/// <inheritdoc/>
		public Task<Uri> GetGroupImagesAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(GetGroupImages);
		}

		/// <inheritdoc/>
		public Task<Uri> GetImagesByIdAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(GetImagesById);
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
		public Task<bool> UpdateAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(Update);
		}
	}
}