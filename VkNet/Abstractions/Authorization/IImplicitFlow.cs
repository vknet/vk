using System;
using JetBrains.Annotations;

namespace VkNet.Abstractions.Authorization
{
	/// <inheritdoc />
	/// <summary>
	/// Implicit flow — самый короткий и простой вариант.
	/// Ключ возвращается на устройство пользователя, где был открыт диалог авторизации
	/// (в виде дополнительного параметра URL).
	/// Такой ключ может быть использован только для запросов непосредственно с
	/// устройства пользователя
	/// (например, для выполнения вызовов из Javascript на веб-сайте или из мобильного
	/// приложения).
	/// </summary>
	/// <remarks>
	/// https://vk.com/dev/implicit_flow_user
	/// </remarks>
	[UsedImplicitly]
	public interface IImplicitFlow : IAuthorizationFlow
	{
		/// <summary>
		/// Установить URL полученный после авторизации.
		/// </summary>
		void SetResponseUri(Uri uri);
	}
}