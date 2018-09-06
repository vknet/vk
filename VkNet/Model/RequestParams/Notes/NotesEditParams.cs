using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.RequestParams.Notes
{
	/// <summary>
	/// Notes Edit Params
	/// </summary>
	[Serializable]
	public class NotesEditParams
	{
		/// <summary>
		/// Идентификатор заметки.
		/// </summary>
		[JsonProperty(propertyName: "note_id")]
		public long? NoteId { get; set; }

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
}
