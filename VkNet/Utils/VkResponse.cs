namespace VkNet.Utils
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
            if (!(_token is JObject))
                return false;

            var token = _token[key];
            return token != null;
        }

        public VkResponse this[object key]
        {
            get
            {
                if (_token is JArray && key is string)
                    return null;

                var token = _token[key];
                return token != null ? new VkResponse(_token[key]) : null;
            }
        }

        public static implicit operator VkResponseArray(VkResponse response)
        {
            if (response == null)
                return null;

            VkResponse resp = response.ContainsKey("items") ? response["items"] : response;

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
                return false;

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
            if (response == null)
                return null;

            string dateStringValue = response.ToString();
            if (string.IsNullOrEmpty(dateStringValue))
                return null;

            long unixTimeStamp;
            if (long.TryParse(dateStringValue, out unixTimeStamp) && unixTimeStamp > 0)
            {
                // Unix timestamp is seconds past epoch
                var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                return dt.AddSeconds(unixTimeStamp).ToLocalTime();
            }

            return null;
        }

		public static implicit operator Uri(VkResponse response)
        {
            return response != null ? new Uri(response) : null;
        }

		#endregion

	    #region Enums

		public static implicit operator PageAccessKind?(VkResponse response)
	    {
		    if (response == null)
			    return null;

		    return Utilities.NullableEnumFrom<PageAccessKind>(response);
	    }

	    public static implicit operator GroupPublicity?(VkResponse response)
	    {
		    if (response == null)
			    return null;

		    return Utilities.NullableEnumFrom<GroupPublicity>(response);
	    }

	    public static implicit operator AdminLevel?(VkResponse response)
	    {
		    if (response == null)
			    return null;

		    return Utilities.NullableEnumFrom<AdminLevel>(response);
	    }

	    public static implicit operator AudioGenre?(VkResponse response)
	    {
		    if (response == null)
			    return null;

		    return Utilities.NullableEnumFrom<AudioGenre>(response);
	    }

		public static implicit operator MessageType?(VkResponse response)
		{
			if (response == null)
				return null;

			return Utilities.NullableEnumFrom<MessageType>(response);
		}

		
		
		public static implicit operator LinkAccessType(VkResponse response)
		{
			return response == null ? null : LinkAccessType.FromJson(response);
		}

		public static implicit operator PoliticalPreferences(VkResponse response)
	    {
		    if (response == null)
			    return PoliticalPreferences.Unknown;

		    return Utilities.EnumFrom<PoliticalPreferences>(response);
	    }

	    public static implicit operator PeopleMain(VkResponse response)
	    {
		    if (response == null)
			    return PeopleMain.Unknown;

		    return Utilities.EnumFrom<PeopleMain>(response);
	    }

	    public static implicit operator LifeMain(VkResponse response)
	    {
		    if (response == null)
			    return LifeMain.Unknown;

		    return Utilities.EnumFrom<LifeMain>(response);
	    }

	    public static implicit operator Attitude(VkResponse response)
	    {
		    if (response == null)
			    return Attitude.Unknown;

		    return Utilities.EnumFrom<Attitude>(response);
	    }

	    public static implicit operator FriendStatus(VkResponse response)
		{
			if (response == null)
				return FriendStatus.NotFriend;

			return Utilities.EnumFrom<FriendStatus>(response);
		}

		public static implicit operator AddFriendStatus(VkResponse response)
		{
			if (response == null)
				return AddFriendStatus.Unknown;

			return Utilities.EnumFrom<AddFriendStatus>(response);
		}

		public static implicit operator DeleteFriendStatus(VkResponse response)
		{
			if (response == null)
				return DeleteFriendStatus.Unknown;

			return Utilities.EnumFrom<DeleteFriendStatus>(response);
		}

		public static implicit operator MessageReadState?(VkResponse response)
		{
			if (response == null)
				return null;

			return Utilities.NullableEnumFrom<MessageReadState>(response);
		}

		public static implicit operator Sex(VkResponse response)
		{
			if (response == null)
				return Sex.Unknown;

			return Utilities.EnumFrom<Sex>(response);
		}

		public static implicit operator BanReason(VkResponse response)
		{
			if (response == null)
				return BanReason.Other;

			return Utilities.EnumFrom<BanReason>(response);
		}

		public static implicit operator RelationType(VkResponse response)
		{
			if (response == null)
				return RelationType.Unknown;

			int value = Convert.ToInt32(response.ToString());
			return Utilities.EnumFrom<RelationType>(value);
		}

	    #endregion

    }
}