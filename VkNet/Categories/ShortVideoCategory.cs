using VkNet.Abstractions;
using VkNet.Model;

namespace VkNet.Categories;

/// <inheritdoc cref="IShortVideoCategory" />
public partial class ShortVideoCategory : IShortVideoCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	/// <param name="vk"> API. </param>
	public ShortVideoCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc/>
	public ShortVideoUploadServer Create(string description,
										ulong fileSize = 16384,
										long? groupId = null,
										bool? wallPost = null) => _vk.Call<ShortVideoUploadServer>("shortVideo.create",
		new()
		{
			{
				"group_id", groupId
			},
			{
				"description", description
			},
			{
				"wallpost", wallPost
			},
			{
				"file_size", fileSize
			}
		});
}