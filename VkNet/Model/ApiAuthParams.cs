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
		public bool? TwoFactorSupported { get; set; }

		/// <inheritdoc />
		public string Code { get; set; }

		/// <inheritdoc />
		public string ClientSecret { get; set; }

		/// <inheritdoc />
		public long ClientId { get; set; }

		/// <inheritdoc />
		public Uri RedirectUri { get; set; }

		/// <inheritdoc />
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public Display Display { get; set; }

		/// <inheritdoc />
		public Settings Scope { get; set; }

		/// <inheritdoc />
		public string State { get; set; }

		/// <inheritdoc />
		public string Login { get; set; }

		/// <inheritdoc />
		public string Password { get; set; }

		/// <inheritdoc />
		public long? CaptchaSid { get; set; }

		/// <inheritdoc />
		public string CaptchaKey { get; set; }
	}
}