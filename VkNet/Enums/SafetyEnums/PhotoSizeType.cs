using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Порядок сортировки членов группы.
	/// </summary>
	public sealed class PhotoSizeType : SafetyEnum<PhotoSizeType>
	{
		/// <summary>
		/// Пропорциональная копия изображения с максимальной шириной 75px.
		/// </summary>
		public static readonly PhotoSizeType S = RegisterPossibleValue("s");

		/// <summary>
		/// Пропорциональная копия изображения с максимальной шириной 130px.
		/// </summary>
		public static readonly PhotoSizeType M = RegisterPossibleValue("m");

		/// <summary>
		/// Пропорциональная копия изображения с максимальной шириной 604px.
		/// </summary>
		public static readonly PhotoSizeType X = RegisterPossibleValue("x");

		/// <summary>
		/// Если соотношение "ширина/высота" исходного изображения меньше или равно 3:2, то пропорциональная копия с максимальной шириной 130px. Если соотношение "ширина/высота" больше 3:2, то копия обрезанного слева изображения с максимальной шириной 130px и соотношением сторон 3:2..
		/// </summary>
		public static readonly PhotoSizeType O = RegisterPossibleValue("o");

		/// <summary>
		/// Если соотношение "ширина/высота" исходного изображения меньше или равно 3:2, то пропорциональная копия с максимальной шириной 200px. Если соотношение "ширина/высота" больше 3:2, то копия обрезанного слева и справа изображения с максимальной шириной 200px и соотношением сторон 3:2..
		/// </summary>
		public static readonly PhotoSizeType P = RegisterPossibleValue("p");

		/// <summary>
		/// Если соотношение "ширина/высота" исходного изображения меньше или равно 3:2, то пропорциональная копия с максимальной шириной 320px. Если соотношение "ширина/высота" больше 3:2, то копия обрезанного слева и справа изображения с максимальной шириной 320px и соотношением сторон 3:2..
		/// </summary>
		public static readonly PhotoSizeType Q = RegisterPossibleValue("q");

		/// <summary>
		/// Если соотношение "ширина/высота" исходного изображения меньше или равно 3:2, то пропорциональная копия с максимальной шириной 510px. Если соотношение "ширина/высота" больше 3:2, то копия обрезанного слева и справа изображения с максимальной шириной 510px и соотношением сторон 3:2.
		/// </summary>
		public static readonly PhotoSizeType R = RegisterPossibleValue("r");

		/// <summary>
		/// Пропорциональная копия изображения с максимальной стороной 807px.
		/// </summary>
		public static readonly PhotoSizeType Y = RegisterPossibleValue("y");

		/// <summary>
		/// Пропорциональная копия изображения с максимальным размером 1280x1024.
		/// </summary>
		public static readonly PhotoSizeType Z = RegisterPossibleValue("z");

		/// <summary>
		/// Пропорциональная копия изображения с максимальным размером 2560x2048px..
		/// </summary>
		public static readonly PhotoSizeType W = RegisterPossibleValue("w");

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static PhotoSizeType FromJson(VkResponse response)
		{
			switch (response.ToString())
			{
				case "s":
					{
						return S;
					}
				case "m":
					{
						return M;
					}
				case "x":
					{
						return X;
					}
				case "o":
					{
						return O;
					}
				case "p":
					{
						return P;
					}
				case "q":
					{
						return Q;
					}
				case "r":
					{
						return R;
					}
				case "y":
					{
						return Y;
					}
				case "z":
					{
						return Z;
					}
				case "w":
					{
						return W;
					}
			}

			return null;
		}

	}
}