namespace VkToolkit.Enum
{
    public sealed class GroupsSort
    {
        private readonly string _name;

        public static readonly GroupsSort IdAsc = new GroupsSort("id_asc");
        public static readonly GroupsSort IdDesc = new GroupsSort("id_desc");
        public static readonly GroupsSort TimeAsc = new GroupsSort("time_asc");
        public static readonly GroupsSort TimeDesc = new GroupsSort("time_desc");

        private GroupsSort(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}