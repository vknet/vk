using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип размера изображения
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum PhotoSizeType
{
	/// <summary>
	/// Пропорциональная копия изображения с максимальной шириной 75px.
	/// </summary>
	S,

	/// <summary>
	/// Пропорциональная копия изображения с максимальной шириной 130px.
	/// </summary>
	M,

	/// <summary>
	/// Пропорциональная копия изображения с максимальной шириной 604px.
	/// </summary>
	X,

	/// <summary>
	/// Если соотношение "ширина/высота" исходного изображения меньше или равно 3:2, то
	/// пропорциональная копия с
	/// максимальной шириной 130px. Если соотношение "ширина/высота" больше 3:2, то
	/// копия обрезанного слева изображения с
	/// максимальной шириной 130px и соотношением сторон 3:2.
	/// </summary>
	O,

	/// <summary>
	/// Если соотношение "ширина/высота" исходного изображения меньше или равно 3:2, то
	/// пропорциональная копия с
	/// максимальной шириной 200px. Если соотношение "ширина/высота" больше 3:2, то
	/// копия обрезанного слева и справа
	/// изображения с максимальной шириной 200px и соотношением сторон 3:2.
	/// </summary>
	P,

	/// <summary>
	/// Если соотношение "ширина/высота" исходного изображения меньше или равно 3:2, то
	/// пропорциональная копия с
	/// максимальной шириной 320px. Если соотношение "ширина/высота" больше 3:2, то
	/// копия обрезанного слева и справа
	/// изображения с максимальной шириной 320px и соотношением сторон 3:2.
	/// </summary>
	Q,

	/// <summary>
	/// Если соотношение "ширина/высота" исходного изображения меньше или равно 3:2, то
	/// пропорциональная копия с
	/// максимальной шириной 510px. Если соотношение "ширина/высота" больше 3:2, то
	/// копия обрезанного слева и справа
	/// изображения с максимальной шириной 510px и соотношением сторон 3:2.
	/// </summary>
	R,

	/// <summary>
	/// Пропорциональная копия изображения с максимальной стороной 807px.
	/// </summary>
	Y,

	/// <summary>
	/// Пропорциональная копия изображения с максимальным размером 1280x1024.
	/// </summary>
	Z,

	/// <summary>
	/// Пропорциональная копия изображения с максимальным размером 2560x2048px.
	/// </summary>
	W,

	/// <summary>
	/// Максимальная ширина изображения
	/// </summary>
	Max,

	/// <summary>
	/// В документации отсутствует описание
	/// </summary>
	/// <remarks>
	/// <see href="https://dev.vk.com/ru/reference/objects/photo-sizes">Документация</see>
	/// </remarks>
	A,

	/// <summary>
	/// В документации отсутствует описание
	/// </summary>
	/// <remarks>
	/// <see href="https://dev.vk.com/ru/reference/objects/photo-sizes">Документация</see>
	/// </remarks>
	B,

	/// <summary>
	/// В документации отсутствует описание
	/// </summary>
	/// <remarks>
	/// <see href="https://dev.vk.com/ru/reference/objects/photo-sizes">Документация</see>
	/// </remarks>
	C,

	/// <summary>
	/// В документации отсутствует описание
	/// </summary>
	/// <remarks>
	/// <see href="https://dev.vk.com/ru/reference/objects/photo-sizes">Документация</see>
	/// </remarks>
	D,

	/// <summary>
	/// В документации отсутствует описание
	/// </summary>
	/// <remarks>
	/// <see href="https://dev.vk.com/ru/reference/objects/photo-sizes">Документация</see>
	/// </remarks>
	E,

	/// <summary>
	/// В документации отсутствует описание
	/// </summary>
	/// <remarks>
	/// <see href="https://dev.vk.com/ru/reference/objects/photo-sizes">Документация</see>
	/// </remarks>
	K,

	/// <summary>
	/// В документации отсутствует описание
	/// </summary>
	/// <remarks>
	/// <see href="https://dev.vk.com/ru/reference/objects/photo-sizes">Документация</see>
	/// </remarks>
	Temp,

	/// <summary>
	/// В документации отсутствует описание
	/// </summary>
	/// <remarks>
	/// <see href="https://dev.vk.com/ru/reference/objects/photo-sizes">Документация</see>
	/// </remarks>
	I,

	/// <summary>
	/// В документации отсутствует описание
	/// </summary>
	/// <remarks>
	/// <see href="https://dev.vk.com/ru/reference/objects/photo-sizes">Документация</see>
	/// </remarks>
	L
}