using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Медиа вложение.
	/// </summary>
	[Serializable]
	public abstract class MediaAttachment
	{
		/// <summary>
		/// Коллекция вложений
		/// </summary>
		private static readonly IDictionary<Type, string> Types = new Dictionary<Type, string>();

		/// <summary>
		/// Идентификатор вложенеия.
		/// </summary>
		[JsonProperty("id")]
		public long? Id { get; set; }

		/// <summary>
		/// Идентификатор владельца вложения.
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Преобразовать вложение в строку.
		/// </summary>
		public override string ToString()
		{
			return $"{MatchType(type: GetType())}{OwnerId}_{Id}";
		}

		/// <summary>
		/// Зарегистрировать тип.
		/// </summary>
		/// <param name="type"> тип вложения. </param>
		/// <param name="match"> Соответствие. </param>
		protected static void RegisterType(Type type, string match)
		{
			Types.Add(key: type, value: match);
		}

		/// <summary>
		/// Соответствие типу.
		/// </summary>
		/// <param name="type"> Тип вложения. </param>
		/// <returns> </returns>
		private static string MatchType(Type type)
		{
			return Types[key: type];
		}
	}
}