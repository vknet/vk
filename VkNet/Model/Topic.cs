using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

/// <summary>
/// Элемент коллекции тем.
/// </summary>
[Serializable]
public class Topic
{
	/// <summary>
	/// Идентификатор темы.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Заголовок.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }


	/// <summary>
	/// Дата создания (в формате unixtime).
	/// </summary>
	[JsonProperty("created")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? Created { get; set; }

	/// <summary>
	/// Идентификатор пользователя, создавшего тему.
	/// </summary>
	[JsonProperty("created_by")]
	public long CreatedBy { get; set; }

	/// <summary>
	/// Дата последнего сообщения (в формате unixtime).
	/// </summary>
	[JsonProperty("updated")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? Updated { get; set; }

	/// <summary>
	/// Идентификатор автора последнего комментария в обсуждении (может содержать id
	/// сообщества со знаком минус).
	/// </summary>
	[JsonProperty("updated_by")]
	public long UpdatedBy { get; set; }

	/// <summary>
	/// Eсли тема является закрытой (в ней нельзя оставлять сообщения).
	/// </summary>
	[JsonProperty("is_closed")]
	public bool IsClosed { get; set; }

	/// <summary>
	/// Если тема является закрепленной (находится в начале списка тем).
	/// </summary>
	[JsonProperty("is_fixed")]
	public bool IsFixed { get; set; }

	/// <summary>
	/// Число сообщений в теме.
	/// </summary>
	[JsonProperty("comments")]
	public long Comments { get; set; }

	/// <summary>
	/// (только если в поле preview указан флаг 1) — текст первого сообщения.
	/// </summary>
	[JsonProperty("first_comment")]
	public string FirstComment { get; set; }

	/// <summary>
	/// (только если в поле preview указан флаг 2) — текст последнего сообщения.
	/// </summary>
	[JsonProperty("last_comment")]
	public string LastComment { get; set; }
}