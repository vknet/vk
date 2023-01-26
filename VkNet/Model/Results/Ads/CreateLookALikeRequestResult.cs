using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат запроса LookALikeRequest
/// </summary>
[Serializable]
public class CreateLookALikeRequestResult
{
	/// <summary>
	/// Идентификатор созданного запроса на поиск похожей аудитории
	/// </summary>
	[JsonProperty("request_id")]
	public long RequestId { get; set; }
}