using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Высшее учебное заведение, в котором учился пользователь.
/// См. описание http://vk.com/dev/fields
/// </summary>
[Serializable]
public class University
{
	/// <summary>
	/// Идентификатор университета.
	/// </summary>
	[JsonProperty("id")]
	public long? Id { get; set; }

	/// <summary>
	/// Идентификатор страны, в которой расположен университет.
	/// </summary>
	[JsonProperty("country")]
	public long? Country { get; set; }

	/// <summary>
	/// Идентификатор города, в котором расположен университет.
	/// </summary>
	[JsonProperty("city")]
	public long? City { get; set; }

	/// <summary>
	/// Наименование университета.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Идентификатор факультета.
	/// </summary>
	[JsonProperty("faculty")]
	public long? Faculty { get; set; }

	/// <summary>
	/// Название факультета.
	/// </summary>
	[JsonProperty("faculty_name")]
	public string FacultyName { get; set; }

	/// <summary>
	/// Идентификатор кафедры.
	/// </summary>
	[JsonProperty("chair")]
	public int? Chair { get; set; }

	/// <summary>
	/// Наименование кафедры.
	/// </summary>
	[JsonProperty("chair_name")]
	public string ChairName { get; set; }

	/// <summary>
	/// Год окончания обучения.
	/// </summary>
	[JsonProperty("graduation")]
	public int? Graduation { get; set; }

	[JsonProperty("title")]
	private string Title
	{
		get => Name;
		set => Name = value;
	}

	#region Методы

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static University FromJson(VkResponse response) => new()
	{
		Id = response[key: "id"],
		Country = response[key: "country"],
		City = response[key: "city"],
		Name = response[key: "name"] ?? response[key: "title"],
		Faculty = response[key: "faculty"],
		FacultyName = response[key: "faculty_name"],
		Chair = response[key: "chair"],
		ChairName = response[key: "chair_name"],
		Graduation = response[key: "graduation"],

		// установлено экcпериментальным путем
		EducationForm = response[key: "education_form"],
		EducationStatus = response[key: "education_status"]
	};

	#endregion

	#region Поля, установленные экспериментально

	/// <summary>
	/// Форма обучения.
	/// </summary>
	[JsonProperty("education_form")]
	public string EducationForm { get; set; }

	/// <summary>
	/// Статус пользователя в университете.
	/// </summary>
	[JsonProperty("education_status")]
	public string EducationStatus { get; set; }

	#endregion
}