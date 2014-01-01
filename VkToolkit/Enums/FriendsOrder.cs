namespace VkToolkit.Enums
{
    /// <summary>
    /// Порядок, в котором необходимо вернуть список друзей.
    /// </summary>
    public sealed class FriendsOrder
    {
        private readonly string _name;

        /// <summary>
        /// Сортировать по имени (работает только при переданном параметре fields). 
        /// </summary>
        public static readonly FriendsOrder Name = new FriendsOrder("name");

        /// <summary>
        /// Сортировать по рейтингу, аналогично тому, как друзья сортируются в разделе "Мои друзья".
        /// </summary>
        public static readonly FriendsOrder Hints = new FriendsOrder("hints");

        /// <summary>
        /// Возвращает друзей в случайном порядке.
        /// </summary>
        public static readonly FriendsOrder Random = new FriendsOrder("random ");

        private FriendsOrder(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}