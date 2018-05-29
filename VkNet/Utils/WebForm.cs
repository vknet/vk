using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using VkNet.Exception;

namespace VkNet.Utils
{
	/// <summary>
	/// WEB форма
	/// </summary>
	internal sealed class WebForm
	{
		/// <summary>
		/// HTML документ
		/// </summary>
		private readonly HtmlDocument _html;

		/// <summary>
		/// Коллекция input на форме
		/// </summary>
		private readonly Dictionary<string, string> _inputs;

		/// <summary>
		/// Базовый URL-ответ
		/// </summary>
		/// <remarks>
		/// Если форма имеет относительный URL
		/// </remarks>
		private readonly string _responseBaseUrl;

		/// <summary>
		/// Наименование поля
		/// </summary>
		private string _lastName;

		/// <summary>
		/// WEB форма.
		/// </summary>
		/// <param name="result"> Результат. </param>
		private WebForm(WebCallResult result)
		{
			Cookies = result.Cookies;
			OriginalUrl = result.RequestUrl.OriginalString;

			_html = new HtmlDocument();
			_html.LoadHtml(html: result.Response);

			var uri = result.ResponseUrl;

			_responseBaseUrl = uri.Scheme + "://" + uri.Host + ":" + uri.Port;

			_inputs = ParseInputs();
		}

		/// <summary>
		/// Cookies.
		/// </summary>
		public Cookies Cookies { get; }

		/// <summary>
		/// URL действия.
		/// </summary>
		public string ActionUrl
		{
			get
			{
				var formNode = GetFormNode();

				if (formNode.Attributes[name: "action"] == null)
				{
					return OriginalUrl;
				}

				var link = formNode.Attributes[name: "action"].Value;

				if (!string.IsNullOrEmpty(value: link) && !link.StartsWith(value: "http", comparisonType: StringComparison.Ordinal)
				) // относительный URL
				{
					link = _responseBaseUrl + link;
				}

				return link; // абсолютный путь
			}
		}

		/// <summary>
		/// Gets the original URL.
		/// </summary>
		/// <value>
		/// The original URL.
		/// </value>
		public string OriginalUrl { get; }

		/// <summary>
		/// Из результата.
		/// </summary>
		/// <param name="result"> Результат. </param>
		/// <returns> WEB форма. </returns>
		public static WebForm From(WebCallResult result)
		{
			return new WebForm(result: result);
		}

		/// <summary>
		/// Проверка на отсутствие двухфакторной авторизации.
		/// </summary>
		/// <param name="result"> Результат. </param>
		/// <returns> WEB форма. </returns>
		public static bool IsOAuthBlank(WebCallResult result)
		{
			var html = new HtmlDocument();
			html.LoadHtml(html: result.Response);
			var title = html.DocumentNode.SelectSingleNode(xpath: "//head/title");

			return title.InnerText.ToLowerInvariant() == "oauth blank";
		}

		/// <summary>
		/// И.
		/// </summary>
		/// <returns> WEB форма. </returns>
		public WebForm And()
		{
			return this;
		}

		/// <summary>
		/// С полем.
		/// </summary>
		/// <param name="name"> Наименование поля. </param>
		/// <returns> WEB форма. </returns>
		public WebForm WithField(string name)
		{
			_lastName = name;

			return this;
		}

		/// <summary>
		/// Заполнить поле с.
		/// </summary>
		/// <param name="value"> Значение. </param>
		/// <returns> WEB форма. </returns>
		/// <exception cref="System.InvalidOperationException"> Field name not set! </exception>
		public WebForm FilledWith(string value)
		{
			if (string.IsNullOrEmpty(value: _lastName))
			{
				throw new InvalidOperationException(message: "Field name not set!");
			}

			var encodedValue = value;

			if (_inputs.ContainsKey(key: _lastName))
			{
				_inputs[key: _lastName] = encodedValue;
			} else
			{
				_inputs.Add(key: _lastName, value: encodedValue);
			}

			return this;
		}

		/// <summary>
		/// Получить запрос.
		/// </summary>
		/// <returns> Массив байт </returns>
		public byte[] GetRequest()
		{
			return Encoding.UTF8.GetBytes(s: GetRequestAsStringArray().JoinNonEmpty(separator: "&"));
		}

		/// <summary>
		/// Получить запрос.
		/// </summary>
		/// <returns> Массив байт </returns>
		public IEnumerable<string> GetRequestAsStringArray()
		{
			return _inputs.Select(selector: x => $"{x.Key}={x.Value}");
		}

		/// <summary>
		/// Получить значения полей.
		/// </summary>
		/// <returns> Словарь значений по именам полей. </returns>
		public IDictionary<string, string> GetFormFields()
		{
			return new Dictionary<string, string>(dictionary: _inputs, comparer: _inputs.Comparer);
		}

		/// <summary>
		/// Разобрать поля ввода.
		/// </summary>
		/// <returns> Коллекция полей ввода </returns>
		private Dictionary<string, string> ParseInputs()
		{
			var inputs = new Dictionary<string, string>();

			var form = GetFormNode();

			foreach (var node in form.SelectNodes(xpath: "//input"))
			{
				var nameAttribute = node.Attributes[name: "name"];
				var valueAttribute = node.Attributes[name: "value"];

				var name = nameAttribute != null ? nameAttribute.Value : string.Empty;
				var value = valueAttribute != null ? valueAttribute.Value : string.Empty;

				if (string.IsNullOrEmpty(value: name))
				{
					continue;
				}

				inputs.Add(key: name, value: Uri.EscapeDataString(stringToEscape: value));
			}

			return inputs;
		}

		/// <summary>
		/// Получить из HTML элемента.
		/// </summary>
		/// <returns> HTML элемент </returns>
		/// <exception cref="VkApiException"> Элемент не найден на форме. </exception>
		private HtmlNode GetFormNode()
		{
			HtmlNode.ElementsFlags.Remove(key: "form");
			var form = _html.DocumentNode.SelectSingleNode(xpath: "//form");

			if (form == null)
			{
				throw new VkApiException(message: "Form element not found.");
			}

			return form;
		}
	}
}