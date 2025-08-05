using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы со статусом пользователя или сообщества.
/// </summary>
public interface IStatusCategory : IStatusCategoryAsync
{
	/// <inheritdoc cref="IStatusCategoryAsync.GetAsync"/>
	Status Get(long userId, long? groupId = null);

	/// <inheritdoc cref="IStatusCategoryAsync.SetAsync"/>
	bool Set(string text, long? groupId = null);
}