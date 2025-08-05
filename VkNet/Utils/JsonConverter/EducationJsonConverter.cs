using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class EducationJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

	/// <inheritdoc />
	/// <exception cref="T:System.TypeAccessException"> </exception>
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{


		var obj = JObject.Load(reader);
		var responseJToken = obj["response"] ?? obj;
		var response = new VkResponse(responseJToken);

		if (response[key: "university"] is null
			|| response[key: "university"]
				.ToString()
			== "0")
		{
			return null;
		}

		var education = new Education
		{
			UniversityId = Utilities.GetNullableLongId(response: response[key: "university"]),
			UniversityName = response[key: "university_name"],
			FacultyId = Utilities.GetNullableLongId(response: response[key: "faculty"]),
			FacultyName = response[key: "faculty_name"],
			Graduation = (int?) Utilities.GetNullableLongId(response: response[key: "graduation"])
		};

		if (education.UniversityId.HasValue && education.UniversityId == 0)
		{
			education.UniversityId = null;
		}

		if (education.FacultyId.HasValue && education.FacultyId == 0)
		{
			education.FacultyId = null;
		}

		if (education.Graduation.HasValue && education.Graduation == 0)
		{
			education.Graduation = null;
		}

		education.EducationForm = response[key: "education_form"]; // установлено экcпериментальным путем
		education.EducationStatus = response[key: "education_status"]; // установлено экcпериментальным путем

		return education;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => typeof(ReadOnlyCollection<>).IsAssignableFrom(c: objectType);
}