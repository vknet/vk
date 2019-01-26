using System;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

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
			return _vk.Call("appWidgets.getAppImageUploadServer", new VkParameters { { "image_type", imageType } })["upload_url"];
		}

		/// <inheritdoc/>
		public Uri GetAppImages(int offset, int count, AppWidgetImageType imageType)
		{
			return _vk.Call<Uri>("appWidgets.getAppImages",
				new VkParameters
				{
					{ "offset", offset },
					{ "count", count },
					{ "image_type", imageType }
				});
		}

		/// <inheritdoc/>
		public Uri GetGroupImageUploadServer(AppWidgetImageType imageType)
		{
			return _vk.Call<Uri>("appWidgets.getGroupImageUploadServer", new VkParameters { { "image_type", imageType } });
		}

		/// <inheritdoc/>
		public Uri GetGroupImages(int offset, int count, AppWidgetImageType imageType)
		{
			return _vk.Call<Uri>("appWidgets.getGroupImages",
				new VkParameters
				{
					{ "offset", offset },
					{ "count", count },
					{ "image_type", imageType }
				});
		}

		/// <param name="images"></param>
		/// <inheritdoc/>
		public Uri GetImagesById(string images)
		{
			return _vk.Call<Uri>("appWidgets.getImagesById", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public Uri SaveAppImage(string hash, string image)
		{
			return _vk.Call<Uri>("appWidgets.saveAppImage", new VkParameters { { "hash", hash }, { "image", image } });
		}

		/// <inheritdoc/>
		public Uri SaveGroupImage()
		{
			return _vk.Call<Uri>("appWidgets.saveGroupImage", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public bool Update()
		{
			return _vk.Call<bool>("appWidgets.update", VkParameters.Empty);
		}
	}
}