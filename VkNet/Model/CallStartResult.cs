using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат создания нового звонка
/// </summary>
[Serializable]
public class CallStartResult
{
	/// <summary>
	/// Ссылка на звонок
	/// </summary>
	[JsonProperty("join_link")]
	public string JoinLink { get; set; }

	/// <summary>
	/// Ссылка на звонок (Ok)
	/// </summary>
	[JsonProperty("ok_join_link")]
	public string OkJoinLink { get; set; }

	/// <summary>
	/// Идентификатор созданного звонка
	/// </summary>
	[JsonProperty("call_id")]
	public string CallId  { get; set; }
}