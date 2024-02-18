using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// ShortVideo В этой секции представлены методы, предназначенные для работы с Клипами
/// </summary>
public interface IShortVideoCategory : IShortVideoCategoryAsync
{
	/// <inheritdoc cref="IShortVideoCategoryAsync.CreateAsync"/>
	ShortVideoUploadServer Create(string description,
								ulong fileSize = 16384,
								long? groupId = null,
								bool? wallPost = null);
}