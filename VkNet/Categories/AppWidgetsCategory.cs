using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IAppWidgetsCategory" />
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
	public AppWidgetsCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc/>
	public UploadServerInfo GetAppImageUploadServer(AppWidgetImageType imageType) => _vk.Call<UploadServerInfo>("appWidgets.getAppImageUploadServer", new()
	{
		{
			"image_type", imageType
		}
	});

	/// <inheritdoc/>
	public AppImageResult GetAppImages(int offset, int count, AppWidgetImageType imageType) => _vk.Call<AppImageResult>(
		"appWidgets.getAppImages",
		new()
		{
			{
				"offset", offset
			},
			{
				"count", count
			},
			{
				"image_type", imageType
			}
		});

	/// <inheritdoc/>
	public UploadServerInfo GetGroupImageUploadServer(AppWidgetImageType imageType) => _vk.Call<UploadServerInfo>(
		"appWidgets.getGroupImageUploadServer", new()
		{
			{
				"image_type", imageType
			}
		});

	/// <inheritdoc/>
	public AppImageResult GetGroupImages(int offset, int count, AppWidgetImageType imageType) => _vk.Call<AppImageResult>(
		"appWidgets.getGroupImages",
		new()
		{
			{
				"offset", offset
			},
			{
				"count", count
			},
			{
				"image_type", imageType
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<AppImage> GetImagesById(string images)
	{
		var parameters = new VkParameters
		{
			{
				"images", images
			}
		};

		return _vk.Call<ReadOnlyCollection<AppImage>>("appWidgets.getImagesById", parameters);
	}

	/// <inheritdoc/>
	public AppImage SaveAppImage(string hash, string image) => _vk.Call<AppImage>("appWidgets.saveAppImage", new()
	{
		{
			"hash", hash
		},
		{
			"image", image
		}
	});

	/// <inheritdoc/>
	public AppImage SaveGroupImage(string hash, string image) => _vk.Call<AppImage>("appWidgets.saveGroupImage", new()
	{
		{
			"hash", hash
		},
		{
			"image", image
		}
	});

	/// <inheritdoc/>
	public bool Update(string code, AppWidgetType type) => _vk.Call<bool>("appWidgets.update", new()
	{
		{
			"code", code
		},
		{
			"type", type
		}
	});
}