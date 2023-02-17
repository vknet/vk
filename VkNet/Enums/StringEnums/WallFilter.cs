using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums;

/// <summary>
/// Фильтр для задания типов сообщений, которые необходимо получить со стены.
/// </summary>
public enum WallFilter
{
	/// <summary>
	/// Необходимо получить сообщения на стене только от ее владельца.
	/// </summary>
	[EnumMember(Value = "owner")]
	Owner,

	/// <summary>
	/// Необходимо получить сообщения на стене не от владельца стены.
	/// </summary>
	[EnumMember(Value = "others")]
	Others,

	/// <summary>
	/// Необходимо получить все сообщения на стене (Owner + Others).
	/// </summary>
	[EnumMember(Value = "all")]
	[DefaultValue]
	All,

	/// <summary>
	/// Предложенные записи на стене сообщества
	/// </summary>
	[EnumMember(Value = "suggests")]
	Suggests,

	/// <summary>
	/// Отложенные записи
	/// </summary>
	[EnumMember(Value = "postponed")]
	Postponed
}