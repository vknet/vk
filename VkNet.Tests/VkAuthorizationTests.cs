﻿using FluentAssertions;
using VkNet.Exception;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests
{
	public class VkAuthorizationTests
	{
		private const string Input =
			"http://oauth.vk.com/blank.html"
			+ "#access_token=token"
			+ "&expires_in=86400"
			+ "&user_id=32190123"
			+ "&email=inyutin_maxim@mail.ru"
			+ "&state=123456";

		[Fact]
		public void Authorize_InvalidLoginOrPassword_NotAuthorizedAndAuthorizationNotRequired()
		{
			const string urlWithBadLoginOrPassword = "http://oauth.vk.com/oauth/authorize"
													+ "?client_id=1"
													+ "&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html"
													+ "&response_type=token"
													+ "&scope=2"
													+ "&v="
													+ "&state="
													+ "&display=wap"
													+ "&m=4"
													+ "&email=mail";

			var authorization = VkAuthorization2.From(urlWithBadLoginOrPassword);

			authorization.IsAuthorized.Should().BeFalse();
			authorization.IsAuthorizationRequired.Should().BeFalse();
		}

		[Fact]
		public void CorrectParseInputString()
		{
			var auth = VkAuthorization2.From(Input);

			auth.AccessToken.Should().Be("token");

			auth.ExpiresIn.Should().Be(86400);
			auth.UserId.Should().Be(32190123L);
			auth.Email.Should().Be("inyutin_maxim@mail.ru");
		}

		[Fact]
		public void GetExpiresIn_Exception()
		{
			var auth = VkAuthorization2.From(Input.Replace("86400", "qwe"));

			FluentActions.Invoking(() =>
				{
					var expiresIn = auth.ExpiresIn;
					expiresIn.Should().NotBe(0);
				})
				.Should()
				.ThrowExactly<VkApiException>()
				.WithMessage("ExpiresIn is not integer value.");
		}

		[Fact]
		public void GetUserId_Exception()
		{
			var auth = VkAuthorization2.From(Input.Replace("32190123", "qwe"));

			FluentActions.Invoking(() =>
				{
					var authUserId = auth.UserId;
					authUserId.Should().NotBe(0);
				})
				.Should()
				.ThrowExactly<VkApiException>()
				.WithMessage("UserId is not long value.");
		}

		[Fact]
		public void IsAuthorizationRequired_False()
		{
			var auth = VkAuthorization2.From(Input);
			auth.IsAuthorizationRequired.Should().BeFalse();
		}

		[Fact]
		public void IsAuthorizationRequired_True()
		{
			const string uriQuery = "https://oauth.vk.com/authorize"
									+ "?client_id=4268118"
									+ "&redirect_uri=https:%2F%2Foauth.vk.com%2Fblank.html"
									+ "&response_type=token"
									+ "&scope=140426399"
									+ "&v="
									+ "&state="
									+ "&display=page"
									+ "&__q_hash=90f3ddf308ca69fca660e32b09e3617b";

			var auth = VkAuthorization2.From(uriQuery);
			auth.IsAuthorizationRequired.Should().BeTrue();
		}

		[Fact]
		public void IsAuthorized_Failed()
		{
			var auth = VkAuthorization2.From(Input.Replace("access_token", "qwe"));
			auth.IsAuthorized.Should().BeFalse();
		}

		[Fact]
		public void IsAuthorized_Success()
		{
			var auth = VkAuthorization2.From(Input);
			auth.IsAuthorized.Should().BeTrue();
		}
	}
}