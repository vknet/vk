using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Пол.
	/// </summary>
	[DataContract]
	public enum Sex
    {
        /// <summary>
        /// Не указан
        /// </summary>
		[DefaultValue]
		
		Unknown = 0,

		/// <summary>
		/// Женский
		/// </summary>
		
		Female = 1,

		/// <summary>
		/// Мужской
		/// </summary>
		
		Male = 2
    }
}