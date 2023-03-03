using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums;

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
}