using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Информация о военной службе пользователя.
/// </summary>
[Serializable]
public class Military
{
	/// <summary>
	/// Номер части.
	/// </summary>
	[JsonProperty("unit")]
	public string Unit { get; set; }

	/// <summary>
	/// Идентификатор части в базе данных.
	/// </summary>
	[JsonProperty("unit_id")]
	public ulong? UnitId { get; set; }

	/// <summary>
	/// Идентификатор страны, в которой находится часть.
	/// </summary>
	[JsonProperty("country_id")]
	public long? CountryId { get; set; }

	/// <summary>
	/// Год начала службы.
	/// </summary>
	[JsonProperty("from")]
	public int? From { get; set; }

	/// <summary>
	/// Год окончания службы.
	/// </summary>
	[JsonProperty("until")]
	public int? Until { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static Military FromJson(VkResponse response)
	{
		var military = new Military
		{
			Unit = response[key: "unit"],
			UnitId = response[key: "unit_id"],
			CountryId = response[key: "country_id"],
			From = response[key: "from"],
			Until = response[key: "until"]
		};

		return military;
	}
}