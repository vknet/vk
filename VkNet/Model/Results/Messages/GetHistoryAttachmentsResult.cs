using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат метода messages.GetHistoryAttachments
/// </summary>
[Serializable]
public class GetHistoryAttachmentsResult
{
	/// <summary>
	/// Идентификатор следующей пачки результатов
	/// </summary>
	[JsonProperty("next_from")]
	public string NextFrom { get; set; }

	/// <summary>
	/// Беседы
	/// </summary>
	[JsonProperty("items")]
	public ReadOnlyCollection<HistoryAttachment> Items { get; set; }

	/// <summary>
	/// Массив объектов пользователей.
	/// </summary>
	[JsonProperty("profiles")]
	public ReadOnlyCollection<User> Profiles { get; set; }
}