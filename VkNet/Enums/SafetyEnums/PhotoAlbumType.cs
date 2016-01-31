﻿namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип служебного альбома с фотографиями
	/// </summary>
	public sealed class PhotoAlbumType : SafetyEnum<PhotoAlbumType>
	{
		/// <summary>
		/// Фотографии со стены
		/// </summary>
		public static readonly PhotoAlbumType Wall = RegisterPossibleValue("wall");

		/// <summary>
		/// Аватары
		/// </summary>
		public static readonly PhotoAlbumType Profile = RegisterPossibleValue("profile");

		/// <summary>
		/// Сохраненные фотографии
		/// </summary>
		public static readonly PhotoAlbumType Saved = RegisterPossibleValue("saved");

		/// <summary>
		/// Идентификатор альбома
		/// </summary>
		/// <param name="number">Номер списка.</param>
		/// <returns>Номер списка.</returns>
		public static PhotoAlbumType Id(long number)
		{
			return RegisterPossibleValue(number + "");
		}
	}
}