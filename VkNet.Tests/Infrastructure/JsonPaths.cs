using System.IO;
using VkNet.Utils;

namespace VkNet.Tests.Infrastructure;

/// <summary>
/// Пути к общим json файлам
/// </summary>
public static class JsonPaths
{
	/// <summary>
	/// Путь к json файлу с ответом <c>true</c>
	/// </summary>
	public static readonly string True = Path.Combine("Common", bool.TrueString);

	/// <summary>
	/// Путь к json файлу с ответом <c>false</c>
	/// </summary>
	public static readonly string False = Path.Combine("Common", bool.FalseString);

	/// <summary>
	/// Путь к json файлу с пустым ответом  <see cref="VkCollection{T}"/>
	/// </summary>
	public static readonly string EmptyVkCollection = Path.Combine("Common", nameof(EmptyVkCollection));

	/// <summary>
	/// Путь к json файлу с пустым массивом
	/// </summary>
	public static readonly string EmptyArray = Path.Combine("Common", nameof(EmptyArray));

	/// <summary>
	/// Путь к json файлу с пустым массивом
	/// </summary>
	public static readonly string EmptyObject = Path.Combine("Common", nameof(EmptyObject));

	/// <summary>
	/// Путь к json файлу с пустым объектом
	/// </summary>
	public static readonly string Object = Path.Combine("Common", "Object");
}