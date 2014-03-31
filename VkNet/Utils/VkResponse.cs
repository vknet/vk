namespace VkNet.Utils
{
    using System;
    using System.Collections.ObjectModel;
    using System.Web;

    using Newtonsoft.Json.Linq;

    using Enums;
    using Model;

    internal sealed class VkResponse
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

        public static implicit operator float(VkResponse response)
        {
            return (float) response._token;
        }

        public static implicit operator float?(VkResponse response)
        {
            return response != null ? (float?) response._token : null;
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

        public static implicit operator Collection<long>(VkResponse response)
        {
            return response == null ? null : response.ToCollectionOf<long>(i => i);
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

        public static implicit operator Collection<Attachment>(VkResponse response)
        {
            return response.ToCollectionOf<Attachment>(r => r);
        }

//        public static implicit operator List<Attachment>(VkResponse response)
//        {
//            return response.ToListOf(r => (Attachment)r);
//        }

        public static implicit operator Audio(VkResponse response)
        {
            return response == null ? null : Audio.FromJson(response);
        }

        public static implicit operator Collection<Audio>(VkResponse response)
        {
            return response.ToCollectionOf<Audio>(a => a);
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

        public static implicit operator Collection<Group>(VkResponse response)
        {
            return response.ToCollectionOf<Group>(g => g);
        }

        public static implicit operator LastActivity(VkResponse response)
        {
            return response == null ? null : LastActivity.FromJson(response);
        }

        public static implicit operator Likes(VkResponse response)
        {
            return response == null ? null : Likes.FromJson(response);
        }

        public static implicit operator Comment(VkResponse response)
        {
            return response == null ? null : Comment.FromJson(response);
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

        public static implicit operator Collection<Message>(VkResponse response)
        {
            return response.ToCollectionOf<Message>(g => g);
        }

        public static implicit operator Note(VkResponse response)
        {
            return response == null ? null : Note.FromJson(response);
        }

        public static implicit operator Page(VkResponse response)
        {
            return response == null ? null : Page.FromJson(response);
        }

        public static implicit operator Album(VkResponse response)
        {
            return response == null ? null : Album.FromJson(response);
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

        public static implicit operator Collection<User>(VkResponse response)
        {
            return response.ToCollectionOf<User>(g => g);
        }

        public static implicit operator Video(VkResponse response)
        {
            return response == null ? null : Video.FromJson(response);
        }

        public static implicit operator Post(VkResponse response)
        {
            return response == null ? null : Post.FromJson(response);
        }

        public static implicit operator Collection<Post>(VkResponse response)
        {
            return response.ToCollectionOf<Post>(r => r);
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

        public static implicit operator Collection<string>(VkResponse response)
        {
            return response.ToCollectionOf<string>(s => s);
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

        public static implicit operator Collection<School>(VkResponse response)
        {
            return response.ToCollectionOf<School>(g => g);
        }

        public static implicit operator University(VkResponse response)
        {
            return response == null ? null : University.FromJson(response);
        }

        public static implicit operator Collection<University>(VkResponse response)
        {
            return response.ToCollectionOf<University>(g => g);
        }

        public static implicit operator Relative(VkResponse response)
        {
            return response == null ? null : Relative.FromJson(response);
        }

        public static implicit operator Collection<Relative>(VkResponse response)
        {
            return response.ToCollectionOf<Relative>(g => g);
        }

        public static implicit operator Connections(VkResponse response)
        {
            return response == null ? null : Connections.FromJson(response);
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

        public static implicit operator Previews(VkResponse response)
        {
            return response == null ? null : Previews.FromJson(response);
        }

        public static implicit operator PageAccessKind?(VkResponse response)
        {
            if (response == null)
                return null;

            return Utilities.NullableEnumFrom<PageAccessKind>(response);
        }

        public static implicit operator PostSource(VkResponse response)
        {
            return response == null ? null : PostSource.FromJson(response);
        }

        public static implicit operator Graffiti(VkResponse response)
        {
            return response == null ? null : Graffiti.FromJson(response);
        }

        public static implicit operator ApplicationContent(VkResponse response)
        {
            return response == null ? null : ApplicationContent.FromJson(response);
        }

        public static implicit operator Poll(VkResponse response)
        {
            return response == null ? null : Poll.FromJson(response);
        }

        public static implicit operator Country(VkResponse response)
        {
            return response == null ? null : Country.FromJson(response);
        }

        public static implicit operator Region(VkResponse response)
        {
            return response == null ? null : Region.FromJson(response);
        }

        public static implicit operator LinkAccessType(VkResponse response)
        {
            return response == null ? null : LinkAccessType.FromJson(response);
        }

        public static implicit operator VkObject(VkResponse response)
        {
            // TODO Возможно сделать так для всех
            return response == null || response._token == null || !response._token.HasValues ? null : VkObject.FromJson(response);
        }

        public static implicit operator City(VkResponse response)
        {
            return response == null ? null : City.FromJson(response);
        }

        public static implicit operator Street(VkResponse response)
        {
            return response == null ? null : Street.FromJson(response);
        }

        public static implicit operator Faculty(VkResponse response)
        {
            return response == null ? null : Faculty.FromJson(response);
        }

        public static implicit operator AudioAlbum(VkResponse response)
        {
            return response == null ? null : AudioAlbum.FromJson(response);
        }

        public static implicit operator FriendList(VkResponse response)
        {
            return response == null ? null : FriendList.FromJson(response);
        }

        public static implicit operator BanInfo(VkResponse response)
        {
            return response == null ? null : BanInfo.FromJson(response);
        }

        public static implicit operator VideoAlbum(VkResponse response)
        {
            return response == null ? null : VideoAlbum.FromJson(response);
        }

        public static implicit operator Tag(VkResponse response)
        {
            return response == null ? null : Tag.FromJson(response);
        }

        #endregion
    }
}