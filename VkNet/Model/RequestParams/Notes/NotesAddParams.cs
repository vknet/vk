using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model;

/// <summary>
/// Notes Add Params
/// </summary>
[Serializable]
public class NotesAddParams
{
	/// <summary>
	/// Заголовок заметки. 
	/// </summary>
	[JsonProperty(propertyName: "title")]
	public string Title { get; set; }

	/// <summary>
	/// Текст заметки. 
	/// </summary>
	[JsonProperty(propertyName: "text")]
	public string Text { get; set; }

	/// <summary>
	/// Настройки приватности просмотра заметки в специальном формате.
	/// </summary>
	[JsonProperty(propertyName: "privacy_view")]
	public List<Privacy> PrivacyView { get; set; }

	/// <summary>
	/// Настройки приватности комментирования заметки в специальном формате.
	/// </summary>
	[JsonProperty(propertyName: "privacy_comment")]
	public List<Privacy> PrivacyComment { get; set; }
}