using System;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class AppWidgetsCategory
	{
		/// <inheritdoc/>
		public async Task<Uri> GetAppImageUploadServerAsync(AppWidgetImageType imageType, CancellationToken cancellationToken = default)
		{
			return (await _vk.CallAsync("appWidgets.getAppImageUploadServer",
						new VkParameters
						{
							{ "image_type", imageType }
						},
						cancellationToken: cancellationToken)
					.ConfigureAwait(false))
				["upload_url"];
		}

		/// <inheritdoc/>
		public Task<Uri> GetAppImagesAsync(int offset, int count, AppWidgetImageType imageType,
											CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<Uri>("appWidgets.getAppImages",
				new VkParameters
				{
					{ "offset", offset },
					{ "count", count },
					{ "image_type", imageType }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc/>
		public Task<Uri> GetGroupImageUploadServerAsync(AppWidgetImageType imageType, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<Uri>("appWidgets.getGroupImageUploadServer",
				new VkParameters
				{
					{ "image_type", imageType }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc/>
		public Task<Uri> GetGroupImagesAsync(int offset, int count, AppWidgetImageType imageType,
											CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<Uri>("appWidgets.getGroupImages",
				new VkParameters
				{
					{ "offset", offset },
					{ "count", count },
					{ "image_type", imageType }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc/>
		public Task<Uri> GetImagesByIdAsync(string images, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<Uri>("appWidgets.getImagesById", VkParameters.Empty, cancellationToken: cancellationToken);
		}

		/// <inheritdoc/>
		public Task<Uri> SaveAppImageAsync(string hash, string image, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<Uri>("appWidgets.saveAppImage",
				new VkParameters
				{
					{ "hash", hash },
					{ "image", image }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc/>
		public Task<Uri> SaveGroupImageAsync(CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<Uri>("appWidgets.saveGroupImage", VkParameters.Empty, cancellationToken: cancellationToken);
		}

		/// <inheritdoc/>
		public Task<bool> UpdateAsync(CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("appWidgets.update", VkParameters.Empty, cancellationToken: cancellationToken);
		}
	}
}