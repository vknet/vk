using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация для предварительного просмотра документа
/// </summary>
[Serializable]
public class DocumentPreview
{
	/// <summary>
	/// Изображения для предпросмотра.
	/// </summary>
	[JsonProperty("photo")]
	public Photo Photo { get; set; }

	/// <summary>
	/// Данные о граффити
	/// </summary>
	[JsonProperty("graffiti")]
	public Graffiti Graffiti { get; set; }

	/// <summary>
	/// Данные об аудиосообщении.
	/// </summary>
	[JsonProperty("audio_message")]
	public AudioMessage AudioMessage { get; set; }
}