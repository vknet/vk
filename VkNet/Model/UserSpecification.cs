using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Массив объектов UserSpecification
/// </summary>
[Serializable]
public class UserSpecification
{
	/// <summary>
	/// Идентификатор пользователя, добавляемого как администратор/наблюдатель.
	/// </summary>
	[JsonProperty(propertyName: "user_id")]
	public long UserId { get; set; }

	/// <summary>
	/// Флаг, описывающий тип полномочий
	/// </summary>
	[JsonProperty(propertyName: "role")]
	public AccessRole Role { get; set; }

	/// <summary>
	/// Идентификатор клиента
	/// </summary>
	[JsonProperty(propertyName: "client_id")]
	public long ClientId { get; set; }
}