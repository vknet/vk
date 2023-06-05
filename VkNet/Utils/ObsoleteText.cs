using VkNet.Abstractions;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Core;

namespace VkNet.Utils;

/// <summary>
/// Тексты для атрибута Obsolete
/// </summary>
public static class ObsoleteText
{
	/// <summary>
	/// Устаревший параметр, доступен только для версий меньше <b>5.86</b>
	/// </summary>
	public const string StatsGet = "Устаревший параметр, доступен только для версий меньше 5.86";

	/// <summary>
	/// "Интерфейс был разделен на <see cref="IImplicitFlow"/> и <see cref="INeedValidationHandler"/>
	/// </summary>
	public const string Browser = "Интерфейс был разделен на " + nameof(IImplicitFlow) + " и " + nameof(INeedValidationHandler);

	/// <summary>
	/// Данный метод устарел, используйте перегрузку класса <see cref="INeedValidationHandler"/>.<see cref="INeedValidationHandler.Validate(string)"/>
	/// </summary>
	public const string Validate = "Данный метод устарел, используйте перегрузку void Validate(string validateUrl);";

	/// <summary>
	/// <inheritdoc cref="Deprecated"/> <see cref="IMessagesCategory.GetConversations"/>
	/// </summary>
	public const string MessageGet = Deprecated + nameof(IMessagesCategory.GetConversations);

	/// <summary>
	/// <inheritdoc cref="Deprecated"/> <see cref="IMessagesCategory.SearchConversations"/>
	/// </summary>
	public const string MessageSearchDialogs = Deprecated + nameof(IMessagesCategory.SearchConversations);

	/// <summary>
	/// <inheritdoc cref="Deprecated"/> <see cref="IMessagesCategory.MarkAsImportantConversation"/>
	/// </summary>
	public const string MessageMarkAsImportantDialog = Deprecated + nameof(IMessagesCategory.MarkAsImportantConversation);

	/// <summary>
	/// <inheritdoc cref="Deprecated"/> <see cref="IMessagesCategory.MarkAsAnsweredConversation"/>
	/// </summary>
	public const string MessageMarkAsAnsweredDialog = Deprecated + nameof(IMessagesCategory.MarkAsAnsweredConversation);

	/// <summary>
	/// <inheritdoc cref="Deprecated"/> <see cref="IMessagesCategory.DeleteConversation"/>
	/// </summary>
	public const string MessageDeleteDialog = Deprecated + nameof(IMessagesCategory.DeleteConversation);

	/// <summary>
	/// <inheritdoc cref="Deprecated"/> <see cref="IMessagesCategory.GetConversationMembers"/>
	/// </summary>
	public const string MessageGetChatUsers = Deprecated + nameof(IMessagesCategory.GetConversationMembers);

	/// <summary>
	/// <inheritdoc cref="Deprecated"/> <see cref="IFriendsCategory.AddList"/>
	/// </summary>
	public const string FriendsAddList = Deprecated + "long AddList(string name, IEnumerable<long> userIds);";

	/// <summary>
	/// <inheritdoc cref="Deprecated"/> <see cref="IAccountCategoryAsync.BanAsync"/>
	/// </summary>
	public const string BanUser = Deprecated + "bool Ban(long ownerId);";

	/// <summary>
	/// <inheritdoc cref="Deprecated"/> <see cref="IAccountCategoryAsync.UnbanAsync"/>
	/// </summary>
	public const string UnbanUser = Deprecated + "bool Unban(long groupId, long userId)";

	/// <summary>
	/// <inheritdoc cref="Deprecated"/> <see cref="IAccountCategoryAsync.BanAsync"/>
	/// </summary>
	public const string BanUserAsync = Deprecated + "bool BanAsync(long ownerId);";

	/// <summary>
	/// <inheritdoc cref="Deprecated"/> <see cref="IAccountCategoryAsync.UnbanAsync"/>
	/// </summary>
	public const string UnbanUserAsync = Deprecated + "Task<bool> UnbanUserAsync(long groupId, long userId)";

	/// <summary>
	/// <inheritdoc cref="Obsolete"/> Используйте вместо него
	/// </summary>
	private const string Deprecated = Obsolete + " Используйте вместо него ";

	/// <summary>
	/// Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.
	/// </summary>
	public const string Obsolete =
		"Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.";

	/// <summary>
	/// Данный класс устарел и может быть удалён в будующих версиях, пожалуйста, избегайте его использования.
	/// </summary>
	public const string ObsoleteClass =
		"Данный класс устарел и может быть удалён в будующих версиях, пожалуйста, избегайте его использования.";

	/// <summary>
	/// Данное поле содержало кириллицу в названии. Обновите использование на поле с латинским названием.
	/// </summary>
	public const string ObsoleteCyrillicProperty =
		"Данное поле содержало кириллицу в названии. Обновите использование на поле с латинским названием.";
}