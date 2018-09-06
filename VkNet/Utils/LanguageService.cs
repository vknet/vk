using VkNet.Abstractions.Core;
using VkNet.Enums;

namespace VkNet.Utils
{
	/// <inheritdoc />
	public class LanguageService : ILanguageService
	{
		/// <summary>
		/// Язык получаемых данных
		/// </summary>
		private Language? Language { get; set; }

		/// <inheritdoc />
		public void SetLanguage(Language language)
		{
			Language = language;
		}

		/// <inheritdoc />
		public Language? GetLanguage()
		{
			return Language;
		}
	}
}