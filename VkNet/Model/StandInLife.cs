using System;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model
{
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
		public PoliticalPreferences Political { get; set; }

		/// <summary>
		/// Языки, на которых говорит пользователь.
		/// </summary>
		public ReadOnlyCollection<string> Languages { get; set; }

		/// <summary>
		/// Мировоззрение пользователя.
		/// </summary>
		public string Religion { get; set; }

		/// <summary>
		/// Источники вдохновения пользователя.
		/// </summary>
		public string InspiredBy { get; set; }

		/// <summary>
		/// Главное в людях для пользователя.
		/// </summary>
		public PeopleMain PeopleMain { get; set; }

		/// <summary>
		/// Главное в жизни для пользователя.
		/// </summary>
		public LifeMain LifeMain { get; set; }

		/// <summary>
		/// Отношение к курению.
		/// </summary>
		public Attitude Smoking { get; set; }

		/// <summary>
		/// Отношение к алкоголю.
		/// </summary>
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
					Political = response[key: "political"]
					, Languages = response[key: "langs"].ToReadOnlyCollectionOf<string>(selector: x => x)
					, Religion = response[key: "religion"]
					, InspiredBy = response[key: "inspired_by"]
					, PeopleMain = response[key: "people_main"]
					, LifeMain = response[key: "life_main"]
					, Smoking = response[key: "smoking"]
					, Alcohol = response[key: "alcohol"]
			};

			return standInLife;
		}

	#endregion
	}
}