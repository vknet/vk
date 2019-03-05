using System;
using System.Collections.Generic;
using Flurl;
using HtmlAgilityPack;
using VkNet.Exception;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	public class AuthorizationFormHtmlParser : IAuthorizationFormHtmlParser
	{
		/// <inheritdoc />
		public VkHtmlFormResult GetForm(Url url)
		{
			var uri = url.ToUri();
			var responseBaseUrl = uri.Scheme + "://" + uri.Host + ":" + uri.Port;

			var web = new HtmlWeb();
			var doc = web.Load(url);
			var formNode = GetFormNode(doc);
			var inputs = ParseInputs(formNode);

			var actionUrl = GetActionUrl(formNode, responseBaseUrl);
			var method = GetMethod(formNode);

			return new VkHtmlFormResult
			{
				Fields = inputs,
				Action = string.IsNullOrWhiteSpace(actionUrl) ? url.ToString() : actionUrl,
				Method = method
			};
		}

		/// <summary>
		/// Получить из HTML элемента.
		/// </summary>
		/// <returns> HTML элемент </returns>
		/// <exception cref="VkApiException"> Элемент не найден на форме. </exception>
		private HtmlNode GetFormNode(HtmlDocument html)
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
		private Dictionary<string, string> ParseInputs(HtmlNode formNode)
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
		private string GetActionUrl(HtmlNode formNode, string responseBaseUrl)
		{
			var action = formNode.Attributes["action"];

			if (action == null)
			{
				return null;
			}

			var link = action.Value;

			if (!string.IsNullOrEmpty(link) && !link.StartsWith("http", StringComparison.Ordinal)
			) // относительный URL
			{
				link = Url.Combine(responseBaseUrl, link);
			}

			return link; // абсолютный путь
		}

		/// <summary>
		/// URL действия.
		/// </summary>
		private string GetMethod(HtmlNode formNode)
		{
			var method = formNode.Attributes["method"];

			return method?.Value;
		}
	}
}