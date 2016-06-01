namespace VkNet.Utils
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using HtmlAgilityPack;

	using Exception;

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
		/// Наименование поля
		/// </summary>
		private string _lastName;

		/// <summary>
		/// Базовый URL-ответ
		/// </summary>
		/// <remarks>
		/// Если форма имеет относительный URL
		/// </remarks>
		private readonly string _responseBaseUrl;

		/// <summary>
		/// Cookies.
		/// </summary>
		public Cookies Cookies { get; private set; }

		/// <summary>
		/// WEB форма.
		/// </summary>
		/// <param name="result">Результат.</param>
		private WebForm(WebCallResult result)
		{
			Cookies = result.Cookies;
			OriginalUrl = result.RequestUrl.OriginalString;

			_html = new HtmlDocument();
			result.LoadResultTo(_html);

			_responseBaseUrl = result.ResponseUrl.GetLeftPart(UriPartial.Authority);

			_inputs = ParseInputs();
		}

		/// <summary>
		/// Из результата.
		/// </summary>
		/// <param name="result">Результат.</param>
		/// <returns>WEB форма.</returns>
		public static WebForm From(WebCallResult result)
		{
			return new WebForm(result);
		}

		/// <summary>
		/// И.
		/// </summary>
		/// <returns>WEB форма.</returns>
		public WebForm And()
		{
			return this;
		}

		/// <summary>
		/// С полем.
		/// </summary>
		/// <param name="name">Наименование поля.</param>
		/// <returns>WEB форма.</returns>
		public WebForm WithField(string name)
		{
			_lastName = name;

			return this;
		}

		/// <summary>
		/// Заполнить поле с.
		/// </summary>
		/// <param name="value">Значение.</param>
		/// <returns>WEB форма.</returns>
		/// <exception cref="System.InvalidOperationException">Field name not set!</exception>
		public WebForm FilledWith(string value)
		{
			if (string.IsNullOrEmpty(_lastName))
			{
				throw new InvalidOperationException("Field name not set!");
			}

			var encodedValue = Uri.EscapeDataString(value);
			if (_inputs.ContainsKey(_lastName))
			{
				_inputs[_lastName] = encodedValue;
			}
			else
			{
				_inputs.Add(_lastName, encodedValue);
			}

			return this;
		}

		/// <summary>
		/// URL действия.
		/// </summary>
		public string ActionUrl
		{
			get
			{
				var formNode = GetFormNode();

				if (formNode.Attributes["action"] == null)
				{
					return OriginalUrl;
				}

				var link = formNode.Attributes["action"].Value;
				if (!string.IsNullOrEmpty(link) && !link.StartsWith("http", StringComparison.Ordinal)) // относительный URL
				{
					link = _responseBaseUrl + link;
				}

				return link; // абсолютный путь
			}
		}

		public string OriginalUrl { get; }

		/// <summary>
		/// Получить запрос.
		/// </summary>
		/// <returns>Массив байт</returns>
		public byte[] GetRequest()
		{
			var uri = _inputs.Select(x => $"{x.Key}={x.Value}").JoinNonEmpty("&");
			return Encoding.UTF8.GetBytes(uri);
		}

		/// <summary>
		/// Разобрать поля ввода.
		/// </summary>
		/// <returns>Коллекция полей ввода</returns>
		private Dictionary<string, string> ParseInputs()
		{
			var inputs = new Dictionary<string, string>();

			var form = GetFormNode();
			foreach (var node in form.SelectNodes("//input"))
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
		/// Получить из HTML элемента.
		/// </summary>
		/// <returns>HTML элемент</returns>
		/// <exception cref="VkApiException">Элемент не найден на форме.</exception>
		private HtmlNode GetFormNode()
		{
			HtmlNode.ElementsFlags.Remove("form");
			var form = _html.DocumentNode.SelectSingleNode("//form");
			if (form == null)
			{
				throw new VkApiException("Form element not found.");
			}

			return form;
		}
	}
}