using System;
using Newtonsoft.Json;

namespace VkNet.Model.Results.Asr;

/// <summary>
/// Объект TaskId
/// </summary>
[Serializable]
public class TaskIdResult
{
	/// <summary>
	/// Идентификатор созданной задачи на обработку аудиозаписи в формате UUID
	/// </summary>
	[JsonProperty("task_id")]
	public string TaskId { get; set; }
}