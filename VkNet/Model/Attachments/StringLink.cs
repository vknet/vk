using System;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Строковая ссылка
	/// </summary>
	[Serializable]
	public class StringLink : MediaAttachment
	{
		/// <inheritdoc />
		static StringLink()
		{
			RegisterType(type: typeof(string), match: "string");
		}

		/// <summary>
		/// Ссылка
		/// </summary>
		public string Link { get; set; }

		/// <inheritdoc />
		public override string ToString()
		{
			return Link;
		}
	}
}