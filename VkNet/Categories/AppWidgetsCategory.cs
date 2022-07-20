using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class AppWidgetsCategory : IAppWidgetsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// api vk.com
		/// </summary>
		/// <param name = "vk">
		/// Api vk.com
		/// </param>
		public AppWidgetsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc/>
		public UploadServerInfo GetAppImageUploadServer(AppWidgetImageType imageType)
		{
			return _vk.Call("appWidgets.getAppImageUploadServer", new VkParameters { { "image_type", imageType } });
		}

		/// <inheritdoc/>
		public AppImageResult GetAppImages(int offset, int count, AppWidgetImageType imageType)
		{
			return _vk.Call<AppImageResult>("appWidgets.getAppImages",
				new VkParameters
				{
					{ "offset", offset },
					{ "count", count },
					{ "image_type", imageType }
				});
		}

		/// <inheritdoc/>
		public UploadServerInfo GetGroupImageUploadServer(AppWidgetImageType imageType)
		{
			return _vk.Call<UploadServerInfo>("appWidgets.getGroupImageUploadServer", new VkParameters { { "image_type", imageType } });
		}

		/// <inheritdoc/>
		public AppImageResult GetGroupImages(int offset, int count, AppWidgetImageType imageType)
		{
			return _vk.Call<AppImageResult>("appWidgets.getGroupImages",
				new VkParameters
				{
					{ "offset", offset },
					{ "count", count },
					{ "image_type", imageType }
				});
		}

		/// <param name="images"></param>
		/// <inheritdoc/>
		public ReadOnlyCollection<AppImage> GetImagesById(string images)
		{
			var parameters = new VkParameters
			{
				{ "images", images }
			};
			return _vk.Call("appWidgets.getImagesById", parameters).ToReadOnlyCollectionOf<AppImage>(x => x);
		}

		/// <inheritdoc/>
		public AppImage SaveAppImage(string hash, string image)
		{
			return _vk.Call<AppImage>("appWidgets.saveAppImage", new VkParameters { { "hash", hash }, { "image", image } });
		}

		/// <inheritdoc/>
		public AppImage SaveGroupImage(string hash, string image)
		{
			return _vk.Call<AppImage>("appWidgets.saveGroupImage", new VkParameters { { "hash", hash }, { "image", image } });
		}

		/// <inheritdoc/>
		public bool Update(string code, AppWidgetType type)
		{
			return _vk.Call<bool>("appWidgets.update", new VkParameters
			{
				{ "code", code },
				{ "type", type }
			});
		}
	}
}