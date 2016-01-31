﻿namespace VkNet.Utils
{
	using System;
	using System.Collections.ObjectModel;
	using System.Web;

	using Newtonsoft.Json.Linq;

	using Enums;

	internal sealed partial class VkResponse
	{
		private readonly JToken _token;
		public string RawJson { get; set; }

		public VkResponse(JToken token)
		{
			_token = token;
		}

		public bool ContainsKey(string key)
		{
			if (!(_token is JObject)) { return false;}

			var token = _token[key];
			return token != null;
		}

		public VkResponse this[object key]
		{
			get
			{
				if (_token is JArray && key is string) { return null;}

				var token = _token[key];
				return token != null ? new VkResponse(_token[key]) : null;
			}
		}

		public static implicit operator VkResponseArray(VkResponse response)
		{
			if (response == null) { return null;}

			var resp = response.ContainsKey("items") ? response["items"] : response;

			var array = (JArray)resp._token;
			return array == null ? null : new VkResponseArray(array);
		}

		public override string ToString()
		{
			return _token.ToString();
		}

		#region System types

		public static implicit operator bool(VkResponse response)
		{
			if (response == null)
			{
				return false;
			}
			return response == 1;
		}

		public static implicit operator bool?(VkResponse response)
		{
			return response == null ? (bool?)null : response == 1;
		}

		public static implicit operator long(VkResponse response)
		{
			return (long)response._token;
		}

		public static implicit operator long?(VkResponse response)
		{
			return response != null ? (long?)response._token : null;
		}

		public static implicit operator ulong (VkResponse response)
		{
			return (ulong)response._token;
		}

		public static implicit operator ulong? (VkResponse response)
		{
			return response != null ? (ulong?)response._token : null;
		}

		public static implicit operator Collection<long>(VkResponse response)
		{
			return response == null ? null : response.ToCollectionOf<long>(i => i);
		}

		public static implicit operator float(VkResponse response)
		{
			return (float) response._token;
		}

		public static implicit operator float?(VkResponse response)
		{
			return response != null ? (float?) response._token : null;
		}

		public static implicit operator decimal (VkResponse response)
		{
			return (decimal)response._token;
		}

		public static implicit operator decimal? (VkResponse response)
		{
			return response != null ? (decimal?)response._token : null;
		}

		public static implicit operator uint (VkResponse response)
		{
			return (uint)response._token;
		}

		public static implicit operator uint? (VkResponse response)
		{
			return response != null ? (uint?)response._token : null;
		}

		public static implicit operator int(VkResponse response)
		{
			return (int)response._token;
		}

		public static implicit operator int?(VkResponse response)
		{
			return response != null ? (int?)response._token : null;
		}

		public static implicit operator string(VkResponse response)
		{
			return response == null ? null : HttpUtility.HtmlDecode((string)response._token);
		}

		public static implicit operator Collection<string>(VkResponse response)
		{
			return response.ToCollectionOf<string>(s => s);
		}

		public static implicit operator DateTime?(VkResponse response)
		{
			if (response == null) { return null;}

			var dateStringValue = response.ToString();
			if (string.IsNullOrWhiteSpace(dateStringValue))
			{
				return null;
			}
			long unixTimeStamp;
			if (long.TryParse(dateStringValue, out unixTimeStamp) && unixTimeStamp > 0)
			{
				// Unix timestamp is seconds past epoch
				var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
				return dt.AddSeconds(unixTimeStamp).ToLocalTime();
			}

			return null;
		}

		public static implicit operator DateTime(VkResponse response)
		{
			if (response == null)
			{
				throw new ArgumentNullException("response");
			}
			var dateStringValue = response.ToString();
			if (string.IsNullOrWhiteSpace(dateStringValue))
			{
				throw new ArgumentException("Пустое значение невозможно преобразовать в дату", "response");
			}
			long unixTimeStamp;
			if (long.TryParse(dateStringValue, out unixTimeStamp) && unixTimeStamp > 0)
			{
				// Unix timestamp is seconds past epoch
				var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
				return dt.AddSeconds(unixTimeStamp).ToLocalTime();
			}

			throw new ArgumentException("Невозможно преобразовать в дату", "response");
		}

		public static implicit operator Uri(VkResponse response)
		{
			return !string.IsNullOrWhiteSpace(response) ? new Uri(response) : null;
		}

		#endregion

		#region Enums

		public static implicit operator PageAccessKind?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<PageAccessKind>(response);
		}

		public static implicit operator GroupPublicity?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<GroupPublicity>(response);
		}

		public static implicit operator ContentAccess? (VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<ContentAccess>(response);
		}

		public static implicit operator GroupSubjects? (VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<GroupSubjects>(response);
		}

		public static implicit operator AdminLevel?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<AdminLevel>(response);
		}

		public static implicit operator AudioGenre?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<AudioGenre>(response);
		}

		public static implicit operator MessageType?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<MessageType>(response);
		}

		public static implicit operator MessageReadState?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<MessageReadState>(response);
		}

		#endregion

	}
}