using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Порядок сортировки членов группы.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum GroupsMemberFilters
{
	/// <summary>
	/// Friends — будут возвращены только друзья в этом сообществе.
	/// </summary>
	Friends,

	/// <summary>
	/// unsure — будут возвращены пользователи, которые выбрали «Возможно пойду» (если
	/// сообщество относится к
	/// мероприятиям).
	/// </summary>
	Unsure,

	/// <summary>
	/// managers — будут возвращены только руководители сообщества (доступно при
	/// запросе с передачей access_token от имени
	/// администратора сообщества).
	/// строка.
	/// </summary>
	Managers,

	/// <summary>
	/// donuts — будут возвращены доны
	/// строка.
	/// </summary>
	Donut
}