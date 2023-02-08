using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Информация о высшем учебном заведении пользователя.
/// См. описание http://vk.com/dev/fields
/// </summary>
[Serializable]
[JsonConverter(typeof(EducationJsonConverter))]
public class Education
{
	/// <summary>
	/// Идентификатор университета.
	/// </summary>
	[JsonProperty("university")]
	public long? UniversityId { get; set; }

	/// <summary>
	/// Название ВУЗа.
	/// </summary>
	[JsonProperty("university_name")]
	public string UniversityName { get; set; }

	/// <summary>
	/// Идентификатор факультета.
	/// </summary>
	[JsonProperty("faculty")]
	public long? FacultyId { get; set; }

	/// <summary>
	/// Название факультета.
	/// </summary>
	[JsonProperty("faculty_name")]
	public string FacultyName { get; set; }

	/// <summary>
	/// Год окончания.
	/// </summary>
	[JsonProperty("graduation")]
	public int? Graduation { get; set; }

	#region Поля, установленные экспериментально

	/// <summary>
	/// Форма обучения.
	/// </summary>
	[JsonProperty("education_form")]
	public string EducationForm { get; set; }

	/// <summary>
	/// Текущий статус пользователя в высшем учебном заведении.
	/// </summary>
	[JsonProperty("education_status")]
	public string EducationStatus { get; set; }

	#endregion
}