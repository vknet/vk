using System;

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