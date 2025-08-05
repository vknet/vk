using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Статус заявки на изменение имени
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum ChangeNameStatus
{
	/// <summary>
	/// Заявка рассматривается
	/// </summary>
	Processing,

	/// <summary>
	/// Заявка отклонена
	/// </summary>
	Declined,

	/// <summary>
	/// Имя было успешно изменено
	/// </summary>
	Success,

	/// <summary>
	/// Недавно уже была одобрена заявка, повторную заявку можно подать не раньше даты,
	/// указанной в поле
	/// ChangeNameRequest.RepeatDate
	/// </summary>
	WasAccepted,

	/// <summary>
	/// Предыдущая заявка была отклонена, повторную заявку можно подать не раньше даты,
	/// указанной в поле
	/// ChangeNameRequest.RepeatDate
	/// </summary>
	WasDeclined
}