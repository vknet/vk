using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Жизненная позиция (Personal).
/// Данная информация не документирована в официальном API ВКонтакте и
/// восстановлена по ответам.
/// </summary>
[Serializable]
public class StandInLife
{
	/// <summary>
	/// Политические предпочтения пользователя.
	/// </summary>
	[JsonProperty("political")]
	public PoliticalPreferences Political { get; set; }

	/// <summary>
	/// Языки, на которых говорит пользователь.
	/// </summary>
	[JsonProperty("langs")]
	public ReadOnlyCollection<string> Languages { get; set; }

	/// <summary>
	/// Мировоззрение пользователя.
	/// </summary>
	[JsonProperty("religion")]
	public string Religion { get; set; }

	/// <summary>
	/// Источники вдохновения пользователя.
	/// </summary>
	[JsonProperty("inspired_by")]
	public string InspiredBy { get; set; }

	/// <summary>
	/// Главное в людях для пользователя.
	/// </summary>
	[JsonProperty("people_main")]
	public PeopleMain PeopleMain { get; set; }

	/// <summary>
	/// Главное в жизни для пользователя.
	/// </summary>
	[JsonProperty("life_main")]
	public LifeMain LifeMain { get; set; }

	/// <summary>
	/// Отношение к курению.
	/// </summary>
	[JsonProperty("smoking")]
	public Attitude Smoking { get; set; }

	/// <summary>
	/// Отношение к алкоголю.
	/// </summary>
	[JsonProperty("alcohol")]
	public Attitude Alcohol { get; set; }

	#region Методы

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static StandInLife FromJson(VkResponse response)
	{
		var standInLife = new StandInLife
		{
			Political = response[key: "political"],
			Languages = response[key: "langs"]
				.ToReadOnlyCollectionOf<string>(selector: x => x),
			Religion = response[key: "religion"],
			InspiredBy = response[key: "inspired_by"],
			PeopleMain = response[key: "people_main"],
			LifeMain = response[key: "life_main"],
			Smoking = response[key: "smoking"],
			Alcohol = response[key: "alcohol"]
		};

		return standInLife;
	}

	#endregion
}