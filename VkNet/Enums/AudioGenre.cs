using System;

namespace VkNet.Enums
{
	/// <summary>
	/// Идентификаторы жанров музыки.
	/// </summary>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio_object
	/// </remarks>
	[Serializable]
	public enum AudioGenre
	{
		/// <summary>
		/// Рок музыка.
		/// </summary>
		Rock = 1

		, /// <summary>
		/// Популярная музыка.
		/// </summary>
		Pop = 2

		, /// <summary>
		/// Реп и хип-хоп.
		/// </summary>
		RapAndHipHop = 3

		, /// <summary>
		/// Легкая музыка.
		/// </summary>
		EasyListening = 4

		, /// <summary>
		/// Танцевальная и хаус музыка.
		/// </summary>
		DanceAndHouse = 5

		, /// <summary>
		/// Инструментальная музыка.
		/// </summary>
		Instrumental = 6

		, /// <summary>
		/// Метал.
		/// </summary>
		Metal = 7

		, /// <summary>
		/// Альтернативная музыка.
		/// </summary>
		Alternative = 21

		, /// <summary>
		/// Дабстеп.
		/// </summary>
		Dubstep = 8

		, /// <summary>
		/// Джаз и блюз.
		/// </summary>
		JazzAndBlues = 1001

		, /// <summary>
		/// Драм-н-бэйс.
		/// </summary>
		DrumAndBass = 10

		, /// <summary>
		/// Транс.
		/// </summary>
		Trance = 11

		, /// <summary>
		/// Шансон.
		/// </summary>
		Chanson = 12

		, /// <summary>
		/// Этническая музыка.
		/// </summary>
		Ethnic = 13

		, /// <summary>
		/// Акустическая музыка и вокал.
		/// </summary>
		AcousticAndVocal = 14

		, /// <summary>
		/// Регги.
		/// </summary>
		Reggae = 15

		, /// <summary>
		/// Классическая музыка.
		/// </summary>
		Classical = 16

		, /// <summary>
		/// Инди-поп.
		/// </summary>
		IndiePop = 17

		, /// <summary>
		/// Спич.
		/// </summary>
		Speech = 19

		, /// <summary>
		/// Электро-поп и диско.
		/// </summary>
		ElectropopAndDisco = 22

		, /// <summary>
		/// Другая музыка.
		/// </summary>
		Other = 18
	}
}