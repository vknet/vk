namespace VkToolkit.Model
{
    using System.Collections.Generic;

    using VkToolkit.Enums;
    using VkToolkit.Utils;

    /// <summary>
    /// Жизнанная позиция (Personal).
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
        public List<string> Languages { get; set; }
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

        internal static StandInLife FromJson(VkResponse standInLife)
        {
            var result = new StandInLife();

            result.Political = standInLife["political"];
            result.Languages = standInLife["langs"];
            result.Religion = standInLife["religion"];
            result.InspiredBy = standInLife["inspired_by"];
            result.PeopleMain = standInLife["people_main"];
            result.LifeMain = standInLife["life_main"];
            result.Smoking = standInLife["smoking"];
            result.Alcohol = standInLife["alcohol"];

            return result;
        }
    }
}