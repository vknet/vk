namespace VkNet
{
    using System;
    using Utils;

    /// <summary>
	/// API для работы с ВКонтакте. Выступает в качестве фабрики для различных категорий API (например, для работы с пользователями,
	/// группами и т.п.).
	/// </summary>
    public interface IVkApi: IAuthAsync, IDisposable, ICategoryPack, IInvoke, ICaptcha
    {
        /// <summary>
        /// Браузер.
        /// </summary>
        IBrowser Browser { get; set; }

        /// <summary>
		/// Ограничение на кол-во запросов в секунду
		/// </summary>
        float RequestsPerSecond { get; set; }
    }
}