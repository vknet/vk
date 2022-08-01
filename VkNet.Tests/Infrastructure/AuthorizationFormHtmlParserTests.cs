using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using VkNet.Infrastructure.Authorization.ImplicitFlow;
using Xunit;

namespace VkNet.Tests.Infrastructure;

public class AuthorizationFormHtmlParserTests : BaseTest
{
	[Fact]
	public async Task LoginForm()
	{
		Url = "https://m.vk.com/login?act=authcheck&m=442";
		ReadHtmlFile("login");

		var parser = Mocker.CreateInstance<AuthorizationFormHtmlParser>();
		var result = await parser.GetFormAsync(new("https://m.vk.com/login?act=authcheck&m=442"));

		result.Should()
			.NotBeNull();

		result.Method.Should()
			.Be("post");

		result.Action.Should()
			.Be("https://login.vk.com/?act=login&amp;soft=1&amp;utf8=1");

		result.Fields.Should()
			.NotBeEmpty();
	}

	[Fact]
	public async Task CaptchaForm()
	{
		Url = "https://m.vk.com/login?act=authcheck&m=442";
		ReadHtmlFile("captcha");

		var parser = Mocker.CreateInstance<AuthorizationFormHtmlParser>();
		var result = await parser.GetFormAsync(new("https://m.vk.com/login?act=authcheck&m=442"));

		result.Should()
			.NotBeNull();

		result.Method.Should()
			.Be("post");

		result.Action.Should()
			.Be("https://login.vk.com/?act=login&amp;soft=1&amp;utf8=1");

		result.UrlToCaptcha.Should()
			.NotBeNull();

		var isCaptchaIndicated = result.UrlToCaptcha.Contains("captcha.php");

		isCaptchaIndicated.Should()
			.BeTrue();

		result.Fields.Should()
			.NotBeEmpty();
	}

	[Fact]
	public async Task TwoFaForm()
	{
		Url = "https://m.vk.com/login?act=authcheck&m=442";
		ReadHtmlFile("twofa");

		var parser = Mocker.CreateInstance<AuthorizationFormHtmlParser>();
		var result = await parser.GetFormAsync(new("https://m.vk.com/login?act=authcheck&m=442"));

		result.Should()
			.NotBeNull();

		result.Method.Should()
			.Be("post");

		result.Action.Should()
			.Be("https://m.vk.com/login?act=authcheck_code&amp;hash=1552162040_c98f31a6e83d3c91c1");

		result.Fields.Should()
			.NotBeEmpty();
	}

	[Fact]
	public async Task ConsentForm()
	{
		Url = "https://m.vk.com/login?act=authcheck&m=442";
		ReadHtmlFile("consent");

		var parser = Mocker.CreateInstance<AuthorizationFormHtmlParser>();
		var result = await parser.GetFormAsync(new("https://m.vk.com/login?act=authcheck&m=442"));

		result.Should()
			.NotBeNull();

		result.Method.Should()
			.Be("post");

		result.Action.Should()
			.Be(
				"https://login.vk.com/?act=grant_access&amp;client_id=4268118&amp;settings=140492255&amp;redirect_uri=https%3A%2F%2Foauth.vk.com%2Fblank.html&amp;response_type=token&amp;group_ids=&amp;token_type=0&amp;v=&amp;state=123&amp;display=mobile&amp;ip_h=5a4524d95f3521be68&amp;hash=1552162134_98614f6fce5d86d252&amp;https=1");

		result.Fields.Should()
			.NotBeEmpty();
	}

	private void ReadHtmlFile(string fileNameWithoutExtension)
	{
		var folders = new List<string>
		{
			AppContext.BaseDirectory,
			"TestData",
			"Authorization",
			fileNameWithoutExtension
		};

		var path = Path.Combine(folders.ToArray()) + ".html";

		if (!File.Exists(path))
		{
			throw new FileNotFoundException(path);
		}

		Json = File.ReadAllText(path, Encoding.UTF8);
	}
}