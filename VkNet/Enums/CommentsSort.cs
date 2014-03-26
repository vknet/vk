namespace VkNet.Enums
{
    /// <summary>
    /// Порядок сортировки комментариев к записи.
    /// </summary>
    public class CommentsSort
    {
        private readonly string _name;

        private CommentsSort(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Преобразует порядок сортировки в строку.
        /// </summary>
        /// <returns>Строка, соответствующая порядку сортировки.</returns>
        public override string ToString()
        {
            return _name;
        }

        /// <summary>
        /// В хронологическом порядке.
        /// </summary>
        public static CommentsSort Asc = new CommentsSort("asc");

        /// <summary>
        /// В порядке, обратном хронологическому.
        /// </summary>
        public static CommentsSort Desc = new CommentsSort("desc");
    }
}