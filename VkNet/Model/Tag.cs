namespace VkNet.Model
{
	using System;
	using System.Diagnostics;

	using Utils;

	/// <summary>
	/// Отметка к видеозаписи.
	/// </summary>
	[DebuggerDisplay("Id = {Id}, TaggedName = {TaggedName}")]
	public class Tag
	{
		/// <summary>
		/// Идентификатор отметки.
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Название отметки.
		/// </summary>
		public string TaggedName { get; set; }

		/// <summary>
		/// Идентификатор пользователя, которому соответствует отметка.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор пользователя, сделавшего отметку.
		/// </summary>
		public long? PlacerId { get; set; }

		/// <summary>
		/// Дата добавления отметки.
		/// </summary>
		public DateTime? Date { get; set; }

		/// <summary>
		/// Статус отметки: true - подтвержденная, false - не подтвержденная.
		/// </summary>
		public bool? IsViewed { get; set; }

		/// <summary>
		/// Координаты прямоугольной области, на которой сделана отметка (верхний левый угол и нижний правый угол) в процентах.
		/// </summary>
		public decimal? X { get; set; }

		/// <summary>
		/// Координаты прямоугольной области, на которой сделана отметка (верхний левый угол и нижний правый угол) в процентах.
		/// </summary>
		public decimal? Y { get; set; }

		/// <summary>
		/// Координаты прямоугольной области, на которой сделана отметка (верхний левый угол и нижний правый угол) в процентах.
		/// </summary>
		public decimal? X2 { get; set; }

		/// <summary>
		/// Координаты прямоугольной области, на которой сделана отметка (верхний левый угол и нижний правый угол) в процентах.
		/// </summary>
		public decimal? Y2 { get; set; }
		#region Методы

		internal static Tag FromJson(VkResponse tag)
		{
			var result = new Tag
			{
				Id = tag["tag_id"],
				TaggedName = tag["tagged_name"],
				UserId = tag["uid"],
				PlacerId = tag["placer_id"],
				Date = tag["tag_created"] ?? tag["date"],
				IsViewed = tag["viewed"],
				X = tag["x"],
				Y = tag["y"],
				X2 = tag["x2"],
				Y2 = tag["y2"]
			};


			return result;
		}

		#endregion
	}
}