using System;
using System.Collections.Generic;

namespace VkNet.Model.Attachments
{
    [Serializable]
	/// <summary>
	/// Приложенный объект, имеющий идентификатор и владельца.
	/// </summary>
	public abstract class MediaAttachment
	{
		private static readonly IDictionary<Type, string> Types = new Dictionary<Type, string>();  

		/// <summary>
		/// Идентификатор приложенного объекта.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор владельца приложенного объекта.
		/// </summary>
		public long? OwnerId { get; set; }

		public override string ToString()
		{
			return string.Format("{0}{1}_{2}", MatchType(GetType()), OwnerId, Id);
		}

		protected static void RegisterType(Type type, string match)
		{
			Types.Add(type, match);
		}

		private static string MatchType(Type type)
		{
			return Types[type];
		}
	}
}