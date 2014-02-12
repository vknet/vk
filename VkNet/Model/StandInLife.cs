namespace VkNet.Model
{
    using System.Collections.ObjectModel;    

    using Enums;
    using Utils;

    /// <summary>
    /// Жизненная позиция (Personal).
    /// Данная информация не документирована в официальном API ВКонтакте и восстановлена по ответам.
    /// </summary>
    public class StandInLife
    {
        /// <summary>
        /// Политические предпочтения пользователя.
        /// </summary>
        public PoliticalPreferences Political { get; set; }

        /// <summary>
        /// Языки, на которых говорит пользователь.
        /// </summary>
        public Collection<string> Languages { get; set; }

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

        internal static StandInLife FromJson(VkResponse response)
        {
            var standInLife = new StandInLife();

            standInLife.Political = response["political"];
            standInLife.Languages = response["langs"];
            standInLife.Religion = response["religion"];
            standInLife.InspiredBy = response["inspired_by"];
            standInLife.PeopleMain = response["people_main"];
            standInLife.LifeMain = response["life_main"];
            standInLife.Smoking = response["smoking"];
            standInLife.Alcohol = response["alcohol"];

            return standInLife;
        }

        #endregion
    }
}