using System.Runtime.Serialization;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Enums.Filters;

/// <summary>
/// Тип объекта, добавленного в закладки.
/// </summary>
public sealed class FaveType : SafetyEnum<FaveType>
{
	/// <summary>
	/// Запись на стене.
	/// </summary>
	[EnumMember(Value = "post")]
	public static readonly FaveType Post = RegisterPossibleValue("post");

	/// <summary>
	/// Видеозапись.
	/// </summary>
	[EnumMember(Value = "video")]
	public static readonly FaveType Video = RegisterPossibleValue("video");

	/// <summary>
	/// Товар.
	/// </summary>
	[EnumMember(Value = "product")]
	public static readonly FaveType Product = RegisterPossibleValue("product");

	/// <summary>
	/// Статья.
	/// </summary>
	[EnumMember(Value = "article")]
	public static readonly FaveType Article = RegisterPossibleValue("article");

	/// <summary>
	/// Ссылки.
	/// </summary>
	[EnumMember(Value = "link")]
	public static readonly FaveType Link = RegisterPossibleValue("link");

	/// <summary>
	/// Подкаст.
	/// </summary>
	[EnumMember(Value = "podcast")]
	public static readonly FaveType Podcast = RegisterPossibleValue("podcast");
}