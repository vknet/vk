using VkNet.Enums.Filters;

namespace VkNet.Categories
{
    using JetBrains.Annotations;
	using Model;
	using Utils;

	/// <summary>
	/// Методы для работы со статусом пользователя или сообщества.
	/// </summary>
	public partial class StatusCategory
	{
		private readonly VkApi _vk;

	    public StatusCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Получает статус пользователя или сообщества.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя или сообщества, информацию о статусе которого нужно получить.</param>
		/// <param name="groupId">Идентификатор сообщества, статус которого необходимо получить. положительное число (Положительное число).</param>
		/// <returns>
		/// В случае успеха возвращается статус пользователдя или сообщества.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Status"/>. 
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/status.get"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public Status Get(long userId, long? groupId = null)
		{
			var parameters = new VkParameters {
				{ "user_id", userId },
				{ "group_id", groupId }
			};

			return _vk.Call("status.get", parameters);
		}

		/// <summary>
		/// Устанавливает новый статус текущему пользователю. 
		/// </summary>
		/// <param name="text">
		/// Текст статуса, который необходимо установить текущему пользователю. Если параметр 
		/// равен пустой строке, то статус текущего пользователя будет очищен.
		/// </param>
		/// <param name="groupId"> Идентификатор сообщества, в котором будет установлен статус. По умолчанию статус устанавливается текущему пользователю. </param>
		/// <returns>Возвращает true, если статус был успешно установлен, false в противном случае.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Status"/>. 
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/status.set"/>.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool Set(string text, long? groupId = null)
		{
			var parameters = new VkParameters
			{
				{ "text", text },
				{ "group_id", groupId }
			};

			return _vk.Call("status.set", parameters);
		}
	}
}