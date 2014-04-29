using System;

namespace VkNet.Utils
{
	/// <summary>
	/// Версия VK API, для которой реализован метод.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	internal class ApiVersionAttribute : Attribute
	{
		/// <summary>
		/// Версия VK API
		/// </summary>
		public string Version { get; private set; }

		/// <summary>
		/// Создает экземпляр атрибута <see cref="ApiVersionAttribute"/> с заданой версией API
		/// </summary>
		/// <param name="version">Версия API</param>
		public ApiVersionAttribute(string version)
		{
			Version = version;
		}

	}
}