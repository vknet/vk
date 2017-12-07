using System;
using System.Runtime.Serialization;

namespace VkNet.Model
{
    using System.Collections.ObjectModel;

    using Enums;
    using Utils;

    /// <summary>
    /// Жизненная позиция (Personal).
    /// Данная информация не документирована в официальном API ВКонтакте и восстановлена по ответам.
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
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static StandInLife FromJson(VkResponse response)
		{
			var standInLife = new StandInLife
			{
				Political = response["political"],
				Languages = response["langs"].ToReadOnlyCollectionOf<string>(x => x),
				Religion = response["religion"],
				InspiredBy = response["inspired_by"],
				PeopleMain = response["people_main"],
				LifeMain = response["life_main"],
				Smoking = response["smoking"],
				Alcohol = response["alcohol"]
			};

			return standInLife;
		}

		#endregion
	}
}