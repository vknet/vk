using System;
using Newtonsoft.Json;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <inheritdoc />
	[Serializable]
	public class ApiAuthParams : IApiAuthParams
	{
		// TODO: добавить поле IsValid в котором проверять достаточно ли параметров для авторизации

		/// <inheritdoc />
		public ulong ApplicationId { get; set; }

		/// <inheritdoc />
		public string Login { get; set; }

		/// <inheritdoc />
		public string Password { get; set; }

		/// <inheritdoc />
		public Settings Settings { get; set; }

		/// <inheritdoc />
		public Func<string> TwoFactorAuthorization { get; set; }

		/// <inheritdoc />
		public string AccessToken { get; set; }

		/// <inheritdoc />
		public int TokenExpireTime { get; set; }

		/// <inheritdoc />
		public long UserId { get; set; }

		/// <inheritdoc />
		public ulong? CaptchaSid { get; set; }

		/// <inheritdoc />
		public string CaptchaKey { get; set; }

		/// <inheritdoc />
		public string Host { get; set; }

		/// <inheritdoc />
		public int? Port { get; set; }

		/// <inheritdoc />
		public string ProxyLogin { get; set; }

		/// <inheritdoc />
		public string ProxyPassword { get; set; }

		/// <inheritdoc />
		public string Phone { get; set; }

		/// <inheritdoc />
		public string ClientSecret { get; set; }

		/// <inheritdoc />
		public bool? ForceSms { get; set; }

		/// <inheritdoc />
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public Display Display { get; set; }

		/// <inheritdoc />
		public Uri RedirectUri { get; set; }

		/// <inheritdoc />
		public string State { get; set; }

		/// <inheritdoc />
		public bool? TwoFactorSupported { get; set; }

		/// <inheritdoc />
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public GrantType GrantType { get; set; }

		/// <inheritdoc />
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public ResponseType ResponseType { get; set; }

		/// <inheritdoc />
		public bool? Revoke { get; set; }

		/// <inheritdoc />
		public string Code { get; set; }

		/// <summary>
		/// Формирует параметры авторизации по минимальному набору необходимых полей
		/// </summary>
		/// <param name="appId"> </param>
		/// <param name="login"> </param>
		/// <param name="password"> </param>
		/// <param name="settings"> </param>
		/// <returns> </returns>
		public static ApiAuthParams Format(ulong appId, string login, string password, Settings settings)
		{
			return new ApiAuthParams
			{
				ApplicationId = appId,
				Login = login,
				Password = password,
				Settings = settings
			};
		}
	}
}