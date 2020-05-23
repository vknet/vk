using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using VkNet.Exception;

// ReSharper disable once CheckNamespace
namespace VkNet.Utils
{
	/// <summary>
	/// WEB форма
	/// </summary>
	[Obsolete(ObsoleteText.ObsoleteClass)]
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
		private WebForm(HttpResponse<string> result)
		{
			if (!result.IsSuccess)
			{
				throw new VkApiException(result.Message);
			}

			OriginalUrl = result.ResponseUri.ToString();

			_responseBaseUrl = $"{result.ResponseUri.Scheme}://{result.RequestUri.Host}";

			_html = new HtmlDocument();
			_html.LoadHtml(result.Value);

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

				if (formNode.Attributes["action"] == null)
				{
					return OriginalUrl;
				}

				var link = formNode.Attributes["action"].Value;

				if (!string.IsNullOrWhiteSpace(link) && !link.StartsWith("http", StringComparison.Ordinal)
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
		public static WebForm From(HttpResponse<string> result)
		{
			return new WebForm(result);
		}

		/// <summary>
		/// Проверка на отсутствие двухфакторной авторизации.
		/// </summary>
		/// <param name="result"> Результат. </param>
		/// <returns> WEB форма. </returns>
		public static bool IsOAuthBlank(WebCallResult result)
		{
			var html = new HtmlDocument();
			html.LoadHtml(result.Response);
			var title = html.DocumentNode.SelectSingleNode("//head/title");

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
		/// С полем.
		/// </summary>
		/// <param name="name"> Наименование поля. </param>
		/// <returns> WEB форма. </returns>
		public string GetFieldValue(string name)
		{
			return _inputs.TryGetValue(name, out var result)
				? result
				: default;
		}

		/// <summary>
		/// Заполнить поле с.
		/// </summary>
		/// <param name="value"> Значение. </param>
		/// <returns> WEB форма. </returns>
		/// <exception cref="System.InvalidOperationException"> Field name not set! </exception>
		public WebForm FilledWith(string value)
		{
			if (string.IsNullOrEmpty(_lastName))
			{
				throw new InvalidOperationException("Field name not set!");
			}

			var encodedValue = value;

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
		/// Получить запрос.
		/// </summary>
		/// <returns> Массив байт </returns>
		public byte[] GetRequest()
		{
			return Encoding.UTF8.GetBytes(GetRequestAsStringArray().JoinNonEmpty("&"));
		}

		/// <summary>
		/// Получить запрос.
		/// </summary>
		/// <returns> Массив байт </returns>
		public IEnumerable<string> GetRequestAsStringArray()
		{
			return _inputs.Select(x => $"{x.Key}={x.Value}");
		}

		/// <summary>
		/// Получить значения полей.
		/// </summary>
		/// <returns> Словарь значений по именам полей. </returns>
		public IDictionary<string, string> GetFormFields()
		{
			return new Dictionary<string, string>(_inputs, _inputs.Comparer);
		}

		/// <summary>
		/// Разобрать поля ввода.
		/// </summary>
		/// <returns> Коллекция полей ввода </returns>
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
		/// <returns> HTML элемент </returns>
		/// <exception cref="VkApiException"> Элемент не найден на форме. </exception>
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