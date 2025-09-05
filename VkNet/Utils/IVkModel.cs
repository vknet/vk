namespace VkNet.Utils;

/// <summary>
/// Модель данных vk.ru
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
	/// <returns>
	/// Модель данных vk.ru
	/// </returns>
	IVkModel FromJson(VkResponse response);
}