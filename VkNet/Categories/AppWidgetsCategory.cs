using System;
using VkNet.Abstractions;
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
		public Uri GetAppImageUploadServer(object imageType)
		{
			return _vk.Call<Uri>("appWidgets.getAppImageUploadServer", new VkParameters { { "image_type", imageType } });
		}

		/// <inheritdoc/>
		public Uri GetAppImages()
		{
			return _vk.Call<Uri>("appWidgets.getAppImages", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public Uri GetGroupImageUploadServer()
		{
			return _vk.Call<Uri>("appWidgets.getGroupImageUploadServer", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public Uri GetGroupImages()
		{
			return _vk.Call<Uri>("appWidgets.getGroupImages", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public Uri GetImagesById()
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