using System;

namespace VkNet.Utils
{
	/// <summary>
	/// Игнорирование генерации неявного преобразования
	/// </summary>
	[AttributeUsage(AttributeTargets.Enum|AttributeTargets.Class)]
	public class VkNetIgnoreDefaultValueAttribute : Attribute
	{
	}
}