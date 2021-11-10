using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace VkNet.Utils
{
	/// <summary>
	/// Contains methods for building urls.
	/// </summary>
	public static class Url
	{
		/// <summary>
		/// Basically a Path.Combine for URLs. Ensures exactly one '/' separates each segment,
		/// and exactly on '&amp;' separates each query parameter.
		/// URL-encodes illegal characters but not reserved characters.
		/// </summary>
		/// <param name="parts">URL parts to combine.</param>
		public static string Combine(params string[] parts)
		{
			if (parts == null)
			{
				throw new ArgumentNullException(nameof(parts));
			}

			var result = "";

			var inQuery = false;
			var inFragment = false;

			static string CombineEnsureSingleSeparator(string a, string b, char separator)
			{
				if (string.IsNullOrWhiteSpace(a))
				{
					return b;
				}

				if (string.IsNullOrWhiteSpace(b))
				{
					return a;
				}

				return a.TrimEnd(separator) + separator + b.TrimStart(separator);
			}

			foreach (var part in parts)
			{
				if (string.IsNullOrEmpty(part))
				{
					continue;
				}

				if (result.EndsWith("?") || part.StartsWith("?"))
				{
					result = CombineEnsureSingleSeparator(result, part, '?');
				} else if (result.EndsWith("#") || part.StartsWith("#"))
				{
					result = CombineEnsureSingleSeparator(result, part, '#');
				} else if (inFragment)
				{
					result += part;
				} else if (inQuery)
				{
					result = CombineEnsureSingleSeparator(result, part, '&');
				} else
				{
					result = CombineEnsureSingleSeparator(result, part, '/');
				}

				if (part.Contains('#'))
				{
					inQuery = false;
					inFragment = true;
				} else if (!inFragment && part.Contains('?'))
				{
					inQuery = true;
				}
			}

			return EncodeIllegalCharacters(result);
		}

		/// <summary>
		/// URL-encodes characters in a string that are neither reserved nor unreserved. Avoids encoding reserved characters such as '/' and '?'. Avoids encoding '%' if it begins a %-hex-hex sequence (i.e. avoids double-encoding).
		/// </summary>
		/// <param name="s">The string to encode.</param>
		/// <param name="encodeSpaceAsPlus">If true, spaces will be encoded as + signs. Otherwise, they'll be encoded as %20.</param>
		/// <returns>The encoded URL.</returns>
		private static string EncodeIllegalCharacters(string s, bool encodeSpaceAsPlus = false)
		{
			if (string.IsNullOrWhiteSpace(s))
			{
				return s;
			}

			if (encodeSpaceAsPlus)
			{
				s = s.Replace(" ", "+");
			}

			// Uri.EscapeUriString mostly does what we want - encodes illegal characters only - but it has a quirk
			// in that % isn't illegal if it's the start of a %-encoded sequence https://stackoverflow.com/a/47636037/62600

			// no % characters, so avoid the regex overhead
			if (!s.Contains('%'))
			{
				return Uri.EscapeUriString(s);
			}

			// pick out all %-hex-hex matches and avoid double-encoding
			return Regex.Replace(s,
				"(.*?)((%[0-9A-Fa-f]{2})|$)",
				c =>
				{
					var a = c.Groups[1].Value; // group 1 is a sequence with no %-encoding - encode illegal characters
					var b = c.Groups[2].Value; // group 2 is a valid 3-character %-encoded sequence - leave it alone!

					return Uri.EscapeUriString(a) + b;
				});
		}

		/// <summary>
		/// Builds a query from pairs.
		/// </summary>
		/// <param name="pairs">Pairs to build the query.</param>
		/// <returns>The query string.</returns>
		public static string QueryFrom(params KeyValuePair<string, string>[] pairs)
		{
			if (pairs == null)
			{
				throw new ArgumentNullException(nameof(pairs));
			}

			return pairs.Any() ? string.Join("&", pairs.Select(pair => $"{pair.Key}={pair.Value}")) : string.Empty;
		}

		/// <summary>
		/// Получить словарь query параметров
		/// </summary>
		/// <param name="url">Исходный URL</param>
		/// <returns>Словарь query параметров</returns>
		/// <exception cref="UriFormatException">URL должен содержать query параметры</exception>
		public static Dictionary<string, string> ParseQueryString(string url)
		{
			var urlParts = url.Split('?');

			if (urlParts.Length <= 1)
			{
				throw new UriFormatException("URL должен содержать query параметры");
			}

			var query = urlParts[1];

			var result = query.Split('&')
				.Select(x =>
				{
					var keyValue = x.Split('=');

					return new KeyValuePair<string, string>(keyValue[0], keyValue.Length <= 1 ? null : keyValue[1]);
				})
				.ToDictionary(f => f.Key, v => Uri.UnescapeDataString(v.Value));

			return result;
		}
	}
}