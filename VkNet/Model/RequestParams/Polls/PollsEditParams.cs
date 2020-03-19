using System;
using System.Collections.Generic;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода polls.edit
	/// </summary>
	[Serializable]
	public struct PollsEditParams
	{
		/// <summary>
		/// Идентификатор владельца опроса.
		/// </summary>
		public long OwnerId { get; set; }

		/// <summary>
		/// Идентификатор опроса.
		/// </summary>
		public long PollId { get; set; }

		/// <summary>
		/// Текст опроса.
		/// </summary>
		public string Question { get; set; }

		/// <summary>
		/// Список новых вариантов ответов.
		/// </summary>
		public List<string> AddAnswers { get; set; }

		/// <summary>
		/// Список для изменения существующих вариантов ответа.
		/// </summary>
		public Dictionary<long, string> EditAnswers { get; set; }

		/// <summary>
		/// Список для удаления вариантов ответа.
		/// </summary>
		public List<long> DeleteAnswers { get; set; }
	}
}