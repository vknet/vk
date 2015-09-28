using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model
{
	using System;

	using VkNet.Categories;
	using VkNet.Enums;
	using VkNet.Utils;

	/// <summary>
	/// Информация о сообществе (группе).
	/// См. описание <see href="http://vk.com/dev/fields_groups"/>.
	/// </summary>
	public class GroupInfo
	{
		#region Стандартные поля

		/// <summary>
		/// Название сообщества.
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// Описание сообщества.
		/// </summary>
		public string Description
		{ get; set; }
		/// <summary>
		/// Gets or sets the address.
		/// </summary>
		public string Address
		{ get; set; }

		/// <summary>
		/// Место, указанное в информации о сообществе.
		/// </summary>
		public Place Place
		{ get; set; }
		/// <summary>
		/// Стена.
		/// </summary>
		public ContentAccess? Wall
		{ get; set; }
		/// <summary>
		/// Фотографии.
		/// </summary>
		public ContentAccess? Photos
		{ get; set; }
		/// <summary>
		/// Видеозаписи.
		/// </summary>
		public ContentAccess? Video
		{ get; set; }
		/// <summary>
		/// Аудиозаписи.
		/// </summary>
		public ContentAccess? Audio
		{ get; set; }
		/// <summary>
		/// Документы.
		/// </summary>
		public ContentAccess? Docs
		{ get; set; }
		/// <summary>
		/// Обсуждения.
		/// </summary>
		public ContentAccess? Topics
		{ get; set; }
		/// <summary>
		/// Материалы.
		/// </summary>
		public ContentAccess? Wiki
		{ get; set; }
		/// <summary>
		/// Тип группы.
		/// </summary>
		public GroupPublicity? Access
		{ get; set; }
		/// <summary>
		/// Тематика сообщества.
		/// </summary>
		public GroupSubjects? Subject
		{ get; set; }

		/// <summary>
		/// Адрес сайта, который будет указан в информации о группе 
		/// </summary>
		public string Website { get; set; }

		#endregion

		#region Методы

		/// <summary>
		/// Разобрать из JSON.
		/// </summary>
		/// <param name="response">Ответ от vk.</param>
		/// <returns></returns>
		internal static GroupInfo FromJson(VkResponse response)
		{
			var group = new GroupInfo();
			group.Title = response["title"];
			group.Description = response["description"];
			group.Address = response["address"];
			group.Place = response["place"];
			group.Wall = response["wall"];
			group.Photos = response["photos"];
			group.Video = response["video"];
			group.Audio = response["audio"];
			group.Docs = response["docs"];
			group.Topics = response["topics"];
			group.Wiki = response["wiki"];
			group.Access = response["access"];
			group.Subject = response["subject"];
			group.Website = response["website"];


			return group;
		}

		#endregion
	}
}