using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Школа, в которой учился пользователь.
/// См. описание http://vk.com/dev/fields
/// </summary>
[Serializable]
public class School
{
	/// <summary>
	/// Идентификатор школы.
	/// </summary>
	[JsonProperty("id")]
	public long? Id { get; set; }

	/// <summary>
	/// Идентификатор страны, в которой расположена школа.
	/// </summary>
	[JsonProperty("country")]
	public long? Country { get; set; }

	/// <summary>
	/// Идентификатор города, в котором расположена школа.
	/// </summary>
	[JsonProperty("city")]
	public long? City { get; set; }

	/// <summary>
	/// Наименование школы.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Год начала обучения.
	/// </summary>
	[JsonProperty("year_from")]
	public int? YearFrom { get; set; }

	/// <summary>
	/// Год окончания обучения.
	/// </summary>
	[JsonProperty("year_to")]
	public int? YearTo { get; set; }

	/// <summary>
	/// Год выпуска.
	/// </summary>
	[JsonProperty("year_graduated")]
	public int? YearGraduated { get; set; }

	/// <summary>
	/// Буква класса.
	/// </summary>
	[JsonProperty("class")]
	public string Class { get; set; }

	/// <summary>
	/// Специализация класса.
	/// </summary>
	[JsonProperty("speciality")]
	public string Speciality { get; set; }

	/// <summary>
	/// Идентификатор типа школы.
	/// </summary>
	[JsonProperty("type")]
	public long? Type { get; set; }

	/// <summary>
	/// Название типа школы.
	/// </summary>
	[JsonProperty("type_str")]
	public string TypeStr { get; set; }

	[JsonProperty("title")]
	private string Title
	{
		get => Name;
		set => Name = value;
	}
}