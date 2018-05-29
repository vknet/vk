using System;
using VkNet.Enums.Filters;

namespace VkNet.Model
{
	/// <inheritdoc />
	[Serializable]
	public class ApiAuthParams : IApiAuthParams
	{
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
		public long? CaptchaSid { get; set; }

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
	}
}