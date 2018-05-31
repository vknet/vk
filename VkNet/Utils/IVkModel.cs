namespace VkNet.Utils
{
	/// <summary>
	/// Модель данных vk.com
	/// </summary>
	public interface IVkModel
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		long Id { get; set; }

		/// <summary>
		/// Преобразовать из JSON
		/// </summary>
		/// <param name="response"> Ответ от сервера. </param>
		/// <returns> </returns>
		IVkModel FromJson(VkResponse response);
	}
}