namespace VkToolkit.Enums
{
    /// <summary>
    /// Возможные значения параметра display, задающего внешний вид окна авторизации.
    /// </summary>
    internal sealed class Display
    {
        /// <summary>
        /// Значение параметра.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Обычная страница.
        /// </summary>
        public static readonly Display Page = new Display("page");

        /// <summary>
        /// Всплывающее окно.
        /// </summary>
        public static readonly Display Popup = new Display("popup");

        /// <summary>
        /// Для мобильных устройств.
        /// </summary>
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