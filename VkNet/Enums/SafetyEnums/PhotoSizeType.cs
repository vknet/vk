using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Порядок сортировки членов группы.
	/// </summary>
	[Serializable]
	[JsonConverter(converterType: typeof(SafetyEnumJsonConverter))]
	public sealed class PhotoSizeType : SafetyEnum<PhotoSizeType>
	{
		/// <summary>
		/// Пропорциональная копия изображения с максимальной шириной 75px.
		/// </summary>
		public static readonly PhotoSizeType S = RegisterPossibleValue(value: "s");

		/// <summary>
		/// Пропорциональная копия изображения с максимальной шириной 130px.
		/// </summary>
		public static readonly PhotoSizeType M = RegisterPossibleValue(value: "m");

		/// <summary>
		/// Пропорциональная копия изображения с максимальной шириной 604px.
		/// </summary>
		public static readonly PhotoSizeType X = RegisterPossibleValue(value: "x");

		/// <summary>
		/// Если соотношение "ширина/высота" исходного изображения меньше или равно 3:2, то
		/// пропорциональная копия с
		/// максимальной шириной 130px. Если соотношение "ширина/высота" больше 3:2, то
		/// копия обрезанного слева изображения с
		/// максимальной шириной 130px и соотношением сторон 3:2.
		/// </summary>
		public static readonly PhotoSizeType O = RegisterPossibleValue(value: "o");

		/// <summary>
		/// Если соотношение "ширина/высота" исходного изображения меньше или равно 3:2, то
		/// пропорциональная копия с
		/// максимальной шириной 200px. Если соотношение "ширина/высота" больше 3:2, то
		/// копия обрезанного слева и справа
		/// изображения с максимальной шириной 200px и соотношением сторон 3:2.
		/// </summary>
		public static readonly PhotoSizeType P = RegisterPossibleValue(value: "p");

		/// <summary>
		/// Если соотношение "ширина/высота" исходного изображения меньше или равно 3:2, то
		/// пропорциональная копия с
		/// максимальной шириной 320px. Если соотношение "ширина/высота" больше 3:2, то
		/// копия обрезанного слева и справа
		/// изображения с максимальной шириной 320px и соотношением сторон 3:2.
		/// </summary>
		public static readonly PhotoSizeType Q = RegisterPossibleValue(value: "q");

		/// <summary>
		/// Если соотношение "ширина/высота" исходного изображения меньше или равно 3:2, то
		/// пропорциональная копия с
		/// максимальной шириной 510px. Если соотношение "ширина/высота" больше 3:2, то
		/// копия обрезанного слева и справа
		/// изображения с максимальной шириной 510px и соотношением сторон 3:2.
		/// </summary>
		public static readonly PhotoSizeType R = RegisterPossibleValue(value: "r");

		/// <summary>
		/// Пропорциональная копия изображения с максимальной стороной 807px.
		/// </summary>
		public static readonly PhotoSizeType Y = RegisterPossibleValue(value: "y");

		/// <summary>
		/// Пропорциональная копия изображения с максимальным размером 1280x1024.
		/// </summary>
		public static readonly PhotoSizeType Z = RegisterPossibleValue(value: "z");

		/// <summary>
		/// Пропорциональная копия изображения с максимальным размером 2560x2048px.
		/// </summary>
		public static readonly PhotoSizeType W = RegisterPossibleValue(value: "w");
	}
}