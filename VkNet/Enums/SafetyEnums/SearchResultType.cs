using System;

namespace VkNet.Enums.SafetyEnums
{
    /// <summary>
    /// тип объекта поиска
    /// </summary>
    [Serializable]
    public class SearchResultType: SafetyEnum<SearchResultType>
    {
        /// <summary>
        /// сообщество
        /// </summary>
        public static readonly SearchResultType Group = RegisterPossibleValue("group");

        /// <summary>
        /// профиль
        /// </summary>
        public static readonly SearchResultType Profile = RegisterPossibleValue("profile");        
    }
}