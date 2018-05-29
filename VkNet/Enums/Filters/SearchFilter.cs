using System;

namespace VkNet.Enums.Filters
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SearchFilter: MultivaluedFilter<SearchFilter>
    {
        /// <summary>
        /// друзья пользователя
        /// </summary>
        public static readonly SearchFilter Friends = RegisterPossibleValue("friends");
        
        /// <summary>
        /// подписки пользователя
        /// </summary>
        public static readonly SearchFilter Idols = RegisterPossibleValue("idols");
        
        /// <summary>
        /// публичные страницы, на которые подписан пользователь
        /// </summary>
        public static readonly SearchFilter Publics = RegisterPossibleValue("publics");

        /// <summary>
        /// группы пользователя
        /// </summary>
        public static readonly SearchFilter Groups = RegisterPossibleValue("groups");

        /// <summary>
        /// встречи пользователя
        /// </summary>
        public static readonly SearchFilter Events = RegisterPossibleValue("events");

        /// <summary>
        /// люди, у которых есть общие друзья с текущим пользователем (этот фильтр позволяет получить не всех пользователей, имеющих общих друзей).
        /// </summary>
        public static readonly SearchFilter MutualFriends = RegisterPossibleValue("mutual_friends");
        
    }
}