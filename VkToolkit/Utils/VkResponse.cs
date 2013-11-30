using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using VkToolkit.Enums;
using VkToolkit.Model;

namespace VkToolkit.Utils
{
    using System.Web;

    internal class VkResponse
    {
        private readonly JToken _token;

        public VkResponse(JToken token)
        {
            _token = token;
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

            var array = (JArray)response._token;
            return array == null ? null : new VkResponseArray(array);
        }

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

        public static implicit operator DateTime?(VkResponse response)
        {
            string dateStringValue = response;
            if (dateStringValue == null)
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

        public static implicit operator List<long>(VkResponse response)
        {
            return response == null ? null : response.ToListOf(i => (long)i);
        }

        public override string ToString()
        {
            return _token.ToString();
        }

        #region Model

        public static implicit operator Attachment(VkResponse response)
        {
            return response == null ? null : Attachment.FromJson(response);
        }

        public static implicit operator List<Attachment>(VkResponse response)
        {
            return response.ToListOf(r => (Attachment)r);
        }

        public static implicit operator Audio(VkResponse response)
        {
            return response == null ? null : Audio.FromJson(response);
        }

        public static implicit operator List<Audio>(VkResponse response)
        {
            return response.ToListOf(a => (Audio)a);
        }

        public static implicit operator Chat(VkResponse response)
        {
            return response == null ? null : Chat.FromJson(response);
        }

        public static implicit operator Comments(VkResponse response)
        {
            return response == null ? null : Comments.FromJson(response);
        }

        public static implicit operator Coordinates(VkResponse response)
        {
            return response == null ? null : Coordinates.FromJson(response);
        }

        public static implicit operator Counters(VkResponse response)
        {
            return response == null ? null : Counters.FromJson(response);
        }

        public static implicit operator Document(VkResponse response)
        {
            return response == null ? null : Document.FromJson(response);
        }

        public static implicit operator Link(VkResponse response)
        {
            return response == null ? null : Link.FromJson(response);
        }

        public static implicit operator Education(VkResponse response)
        {
            return response == null ? null : Education.FromJson(response);
        }

        public static implicit operator Geo(VkResponse response)
        {
            return response == null ? null : Geo.FromJson(response);
        }

        public static implicit operator Group(VkResponse response)
        {
            return response == null ? null : Group.FromJson(response);
        }

        public static implicit operator List<Group>(VkResponse response)
        {
            return response.ToListOf(g => (Group)g);
        }

        public static implicit operator LastActivity(VkResponse response)
        {
            return response == null ? null : LastActivity.FromJson(response);
        }

        public static implicit operator Likes(VkResponse response)
        {
            return response == null ? null : Likes.FromJson(response);
        }

        public static implicit operator LongPollServerResponse(VkResponse response)
        {
            return response == null ? null : LongPollServerResponse.FromJson(response);
        }

        public static implicit operator Lyrics(VkResponse response)
        {
            return response == null ? null : Lyrics.FromJson(response);
        }

        public static implicit operator Message(VkResponse response)
        {
            return response == null ? null : Message.FromJson(response);
        }

        public static implicit operator Note(VkResponse response)
        {
            return response == null ? null : Note.FromJson(response);
        }

        public static implicit operator Page(VkResponse response)
        {
            return response == null ? null : Page.FromJson(response);
        }

        public static implicit operator Photo(VkResponse response)
        {
            return response == null ? null : Photo.FromJson(response);
        }

        public static implicit operator Place(VkResponse response)
        {
            return response == null ? null : Place.FromJson(response);
        }

        public static implicit operator Reposts(VkResponse response)
        {
            return response == null ? null : Reposts.FromJson(response);
        }

        public static implicit operator Status(VkResponse response)
        {
            return response == null ? null : Status.FromJson(response);
        }

        public static implicit operator User(VkResponse response)
        {
            return response == null ? null : User.FromJson(response);
        }

        public static implicit operator List<User>(VkResponse response)
        {
            return response.ToListOf(g => (User)g);
        }

        public static implicit operator Video(VkResponse response)
        {
            return response == null ? null : Video.FromJson(response);
        }

        public static implicit operator WallRecord(VkResponse response)
        {
            return response == null ? null : WallRecord.FromJson(response);
        }

        public static implicit operator FriendStatus(VkResponse response)
        {
            if (response == null)
                return FriendStatus.NotFriend;

            return Utilities.EnumFrom<FriendStatus>(response);
        }

        public static implicit operator MessageType?(VkResponse response)
        {
            if (response == null)
                return null;

            return Utilities.NullableEnumFrom<MessageType>(response);
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

        public static implicit operator RelationType(VkResponse response)
        {
            if (response == null)
                return RelationType.Unknown;

            return Utilities.EnumFrom<RelationType>(response);
        }

        public static implicit operator List<string>(VkResponse response)
        {
            return response.ToListOf(s => (string)s);
        }

        public static implicit operator StandInLife(VkResponse response)
        {
            return response == null ? null : StandInLife.FromJson(response);
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

        public static implicit operator School(VkResponse response)
        {
            return response == null ? null : School.FromJson(response);
        }

        public static implicit operator List<School>(VkResponse response)
        {
            return response.ToListOf(g => (School)g);
        }

        public static implicit operator University(VkResponse response)
        {
            return response == null ? null : University.FromJson(response);
        }

        public static implicit operator List<University>(VkResponse response)
        {
            return response.ToListOf(g => (University)g);
        }

        public static implicit operator Relative(VkResponse response)
        {
            return response == null ? null : Relative.FromJson(response);
        }

        public static implicit operator List<Relative>(VkResponse response)
        {
            return response.ToListOf(g => (Relative)g);
        }

        public static implicit operator Connections(VkResponse response)
        {
            return response == null ? null : Connections.FromJson(response);
        }

        #endregion
    }
}
