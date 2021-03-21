using System;

namespace VkNet.Model
{
	/// <summary>
	/// Габариты товара
	/// </summary>
	[Serializable]
	public class Dimensions
	{
		/// <summary>
		/// Ширина в миллиметрах
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// Высота в миллиметрах
		/// </summary>
		public int Height { get; set; }

		/// <summary>
		/// Длина в миллиметрах
		/// </summary>
		public int Length { get; set; }
	}
}