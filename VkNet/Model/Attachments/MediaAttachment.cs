using System;
using System.Collections.Generic;

namespace VkNet.Model.Attachments
{
    /// <summary>
    /// Приложенный объект, имеющий идентификатор и владельца.
    /// </summary>
    [Serializable]
    public abstract class MediaAttachment
	{
		/// <summary>
		/// Словарь типов
		/// </summary>
		private static readonly IDictionary<Type, string> Types = new Dictionary<Type, string>();

		/// <summary>
		/// Идентификатор приложенного объекта.
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Идентификатор владельца приложенного объекта.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Привести объект к строке.
		/// </summary>
		public override string ToString()
		{
			return string.Format("{0}{1}_{2}", MatchType(GetType()), OwnerId, Id);
		}

		/// <summary>
		/// Зарегистрировать тип.
		/// </summary>
		/// <param name="type">Тип вложения.</param>
		/// <param name="match">Соответствие.</param>
		protected static void RegisterType(Type type, string match)
		{
			Types.Add(type, match);
		}

		/// <summary>
		/// Соответствие типа.
		/// </summary>
		/// <param name="type">Тип вложения.</param>
		/// <returns></returns>
		private static string MatchType(Type type)
		{
			return Types[type];
		}
	}
}