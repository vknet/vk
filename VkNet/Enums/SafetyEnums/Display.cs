namespace VkNet.Enums.SafetyEnums
{
    /// <summary>
    /// Возможные значения параметра display, задающего внешний вид окна авторизации.
    /// </summary>
    internal sealed class Display : SafetyEnum<Display>
    {
		/// <summary>
        /// Обычная страница.
        /// </summary>
        public static readonly Display Page = RegisterPossibleValue("page");

        /// <summary>
        /// Всплывающее окно.
        /// </summary>
        public static readonly Display Popup = RegisterPossibleValue("popup");

        /// <summary>
        /// Для мобильных устройств.
        /// </summary>
        public static readonly Display Wap = RegisterPossibleValue("wap");

    }
}