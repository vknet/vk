using System.Runtime.Serialization;

namespace VkNet.Model
{
	using System;
	using System.Diagnostics;

	using Utils;

	/// <summary>
	/// Отметка к видеозаписи.
	/// </summary>
	[DebuggerDisplay("Id = {Id}, TaggedName = {TaggedName}")]
	[DataContract]
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
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static Tag FromJson(VkResponse response)
		{
			var result = new Tag
			{
				Id = response["tag_id"],
				TaggedName = response["tagged_name"],
				UserId = response["user_id"] ?? response["uid"],
				PlacerId = response["placer_id"],
				Date = response["tag_created"] ?? response["date"],
				IsViewed = response["viewed"],
				X = response["x"],
				Y = response["y"],
				X2 = response["x2"],
				Y2 = response["y2"]
			};

			return result;
		}

		#endregion
	}
}