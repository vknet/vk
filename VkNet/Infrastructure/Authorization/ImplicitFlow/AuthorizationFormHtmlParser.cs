using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using JetBrains.Annotations;
using VkNet.Abstractions.Utils;
using VkNet.Exception;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	[UsedImplicitly]
	public sealed class AuthorizationFormHtmlParser : IAuthorizationFormHtmlParser
	{
		private readonly IRestClient _restClient;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="restClient"></param>
		public AuthorizationFormHtmlParser(IRestClient restClient)
		{
			_restClient = restClient;
		}

		/// <inheritdoc />
		public async Task<VkHtmlFormResult> GetFormAsync(Uri url)
		{
			var response = await _restClient.PostAsync(url, Enumerable.Empty<KeyValuePair<string, string>>());

			var doc = new HtmlDocument();
			doc.LoadHtml(response.Value);
			var formNode = GetFormNode(doc);
			var inputs = ParseInputs(formNode);

			var actionUrl = GetActionUrl(formNode, url);
			var method = GetMethod(formNode);

			return new VkHtmlFormResult
			{
				Fields = inputs,
				Action = actionUrl,
				Method = method
			};
		}

		/// <summary>
		/// Получить из HTML элемента.
		/// </summary>
		/// <returns> HTML элемент </returns>
		/// <exception cref="VkApiException"> Элемент не найден на форме. </exception>
		private static HtmlNode GetFormNode(HtmlDocument html)
		{
			HtmlNode.ElementsFlags.Remove("form");
			var form = html.DocumentNode.SelectSingleNode("//form");

			if (form == null)
			{
				throw new VkApiException("Form element not found.");
			}

			return form;
		}

		/// <summary>
		/// Разобрать поля ввода.
		/// </summary>
		/// <returns> Коллекция полей ввода </returns>
		private static Dictionary<string, string> ParseInputs(HtmlNode formNode)
		{
			var inputs = new Dictionary<string, string>();

			foreach (var node in formNode.SelectNodes("//input"))
			{
				var nameAttribute = node.Attributes["name"];
				var valueAttribute = node.Attributes["value"];

				var name = nameAttribute != null ? nameAttribute.Value : string.Empty;
				var value = valueAttribute != null ? valueAttribute.Value : string.Empty;

				if (string.IsNullOrEmpty(name))
				{
					continue;
				}

				inputs.Add(name, Uri.EscapeDataString(value));
			}

			return inputs;
		}

		/// <summary>
		/// URL действия.
		/// </summary>
		private static string GetActionUrl(HtmlNode formNode, Uri url)
		{
			var action = formNode.Attributes["action"];

			if (action == null)
			{
				return null;
			}

			var link = action.Value;

			if (!string.IsNullOrWhiteSpace(link) && !link.StartsWith("http", StringComparison.Ordinal)) // относительный URL
			{
				link = GetResponseBaseUrl(url) + link;
			}

			return string.IsNullOrWhiteSpace(link) ? url.ToString() : link; // абсолютный путь
		}

		/// <summary>
		/// URL действия.
		/// </summary>
		private static string GetMethod(HtmlNode formNode)
		{
			var method = formNode.Attributes["method"];

			return method?.Value;
		}

		private static string GetResponseBaseUrl(Uri uri)
		{
			return uri.Scheme + "://" + uri.Host + ":" + uri.Port;
		}
	}
}