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
		public async Task<Uri> GetAppImagesAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetAppImages());
		}

		/// <inheritdoc/>
		public async Task<Uri> GetGroupImageUploadServerAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetGroupImageUploadServer());
		}

		/// <inheritdoc/>
		public async Task<Uri> GetGroupImagesAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetGroupImages());
		}

		/// <inheritdoc/>
		public async Task<Uri> GetImagesByIdAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetImagesById());
		}

		/// <inheritdoc/>
		public async Task<Uri> SaveAppImageAsync(string hash, string image)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => SaveAppImage(hash, image));
		}

		/// <inheritdoc/>
		public async Task<Uri> SaveGroupImageAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(() => SaveGroupImage());
		}

		/// <inheritdoc/>
		public async Task<bool> UpdateAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(() => Update());
		}
	}
}