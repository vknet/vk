using System;
using VkNet.Abstractions.Core;

namespace VkNet.Infrastructure
{
	/// <inheritdoc />
	public class TokenManager : ITokenManager
	{
		/// <inheritdoc />
		public string Token { get; set; }

		/// <inheritdoc />
		public int ExpireTime { get; set; }

		/// <inheritdoc />
		public bool IsExpired { get; set; }

		/// <inheritdoc />
		public bool RefreshToken()
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public void SetToken(string token)
		{
			Token = token;
		}
	}
}