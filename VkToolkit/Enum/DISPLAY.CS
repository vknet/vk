namespace VkToolkit.Enum
{
    public sealed class Display
    {
        private readonly string _name;
        
        public static readonly Display Page = new Display("page");
        public static readonly Display Popup = new Display("popup");
        public static readonly Display Touch = new Display("touch");
        public static readonly Display Wap = new Display("wap");

        private Display(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}