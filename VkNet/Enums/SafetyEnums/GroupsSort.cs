namespace VkNet.Enums.SafetyEnums
{
    /// <summary>
    /// Порядок сортировки членов группы.
    /// </summary>
    public sealed class GroupsSort : SafetyEnum<GroupsSort>
    {
        /// <summary>
        /// По возрастанию численных значений идентификаторов.
        /// </summary>
        public static readonly GroupsSort IdAsc = RegisterPossibleValue("id_asc");

        /// <summary>
        /// По убыванию численных значений идентификаторов.
        /// </summary>
        public static readonly GroupsSort IdDesc = RegisterPossibleValue("id_desc");

        /// <summary>
        /// По возрастанию времени присоединения к группе.
        /// </summary>
        public static readonly GroupsSort TimeAsc = RegisterPossibleValue("time_asc");

        /// <summary>
        /// По убыванию времени присоединения к группе.
        /// </summary>
        public static readonly GroupsSort TimeDesc = RegisterPossibleValue("time_desc");

    }
}