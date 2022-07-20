using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IStatusCategoryAsync"/>
	public interface IStatusCategory : IStatusCategoryAsync
	{
		/// <inheritdoc cref="IStatusCategoryAsync.GetAsync"/>
		Status Get(long userId, long? groupId = null);

		/// <inheritdoc cref="IStatusCategoryAsync.SetAsync"/>
		bool Set(string text, long? groupId = null);
	}
}