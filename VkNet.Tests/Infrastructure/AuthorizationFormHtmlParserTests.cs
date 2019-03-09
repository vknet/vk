using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http.Testing;
using Moq.AutoMock;
using NUnit.Framework;
using VkNet.Infrastructure.Authorization.ImplicitFlow;

namespace VkNet.Tests.Infrastructure
{
	[TestFixture]
	public class AuthorizationFormHtmlParserTests
	{
		[Test]
		public async Task LoginForm()
		{
			using (var httpTest = new HttpTest())
			{
				httpTest.RespondWith(ReadHtmlFile("login"));
				var mocker = new AutoMocker();

				var parser = mocker.CreateInstance<AuthorizationFormHtmlParser>();
				var result = await parser.GetFormAsync(new Url("https://m.vk.com/login?act=authcheck&m=442"));

				Assert.NotNull(result);
				Assert.AreEqual("post", result.Method);
				Assert.AreEqual("https://login.vk.com/?act=login&amp;soft=1&amp;utf8=1", result.Action);
				Assert.IsNotEmpty(result.Fields);
			}
		}

		[Test]
		public async Task CaptchaForm()
		{
			using (var httpTest = new HttpTest())
			{
				httpTest.RespondWith(ReadHtmlFile("captcha"));
				var mocker = new AutoMocker();

				var parser = mocker.CreateInstance<AuthorizationFormHtmlParser>();
				var result = await parser.GetFormAsync(new Url("https://m.vk.com/login?act=authcheck&m=442"));

				Assert.NotNull(result);
				Assert.AreEqual("post", result.Method);
				Assert.AreEqual("https://login.vk.com/?act=login&amp;soft=1&amp;utf8=1", result.Action);
				Assert.IsNotEmpty(result.Fields);
			}
		}

		[Test]
		public async Task TwoFaForm()
		{
			using (var httpTest = new HttpTest())
			{
				httpTest.RespondWith(ReadHtmlFile("twofa"));
				var mocker = new AutoMocker();

				var parser = mocker.CreateInstance<AuthorizationFormHtmlParser>();
				var result = await parser.GetFormAsync(new Url("https://m.vk.com/login?act=authcheck&m=442"));

				Assert.NotNull(result);
				Assert.AreEqual("post", result.Method);
				Assert.AreEqual("https://m.vk.com/login?act=authcheck_code&amp;hash=1552162040_c98f31a6e83d3c91c1", result.Action);
				Assert.IsNotEmpty(result.Fields);
			}
		}

		[Test]
		public async Task ConsentForm()
		{
			using (var httpTest = new HttpTest())
			{
				httpTest.RespondWith(ReadHtmlFile("consent"));
				var mocker = new AutoMocker();

				var parser = mocker.CreateInstance<AuthorizationFormHtmlParser>();
				var result = await parser.GetFormAsync(new Url("https://m.vk.com/login?act=authcheck&m=442"));

				Assert.NotNull(result);
				Assert.AreEqual("post", result.Method);
				Assert.AreEqual("https://login.vk.com/?act=grant_access&amp;client_id=4268118&amp;settings=140492255&amp;redirect_uri=https%3A%2F%2Foauth.vk.com%2Fblank.html&amp;response_type=token&amp;group_ids=&amp;token_type=0&amp;v=&amp;state=123&amp;display=mobile&amp;ip_h=5a4524d95f3521be68&amp;hash=1552162134_98614f6fce5d86d252&amp;https=1", result.Action);
				Assert.IsNotEmpty(result.Fields);
			}
		}

		private string ReadHtmlFile(string fileNameWithoutExtension)
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

			return File.ReadAllText(path, Encoding.UTF8);
		}
	}
}