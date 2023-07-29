using VkNet.Model;

namespace VkNet.Abstractions;

/// <inheritdoc cref="IShortVideoCategoryAsync"/>
public interface IShortVideoCategory : IShortVideoCategoryAsync
{
	/// <inheritdoc cref="IShortVideoCategoryAsync.CreateAsync"/>
	ShortVideoUploadServer Create(string description,
								ulong fileSize = 16384,
								long? groupId = null,
								bool? wallPost = null);
}