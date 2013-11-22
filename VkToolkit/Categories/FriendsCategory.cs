using System;
using System.Collections.Generic;
using System.Linq;
using VkToolkit.Enums;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Categories
{
    public class FriendsCategory
    {
        private readonly VkApi _vk;

        public FriendsCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Returns a list of identifiers of the current user's friends or advanced information about the user's friends (when using the fields parameter).
        /// </summary>
        /// <param name="uid">User id</param>
        /// <param name="fields">Profile fields that are necessary to obtain</param>
        /// <param name="count">Count of records to fetch</param>
        /// <param name="offset">Recors offset</param>
        /// <param name="order">Friends order(only for standalone desktop applications) </param>
        /// <returns>List of users</returns>
        public List<User> Get(long uid, ProfileFields fields = null, int? count = null, int? offset = null, Order order = null)
        {
            var parameters = new VkParameters
                {
                    { "uid", uid }, 
                    { "fields", fields }, 
                    { "count", count }, 
                    { "offset", offset }, 
                    { "order", order }
                };

            var response = _vk.Call("friends.get", parameters);

            if (fields != null)
                return response;
            
            return response.ToListOf(id => new User { Id = id });
        }

        /// <summary>
        /// Returns a list of identifiers of the current user's friends that have installed the given application.
        /// </summary>
        /// <returns></returns>
        public List<long> GetAppUsers()
        {
            return _vk.Call("friends.getAppUsers", VkParameters.Empty);
        }

        /// <summary>
        /// Get list of ids of the user.
        /// </summary>
        /// <param name="uid">User id</param>
        /// <returns>List of ids.</returns>
        public List<long> GetOnline(long uid)
        {
            var parameters = new VkParameters { { "uid", uid } };

            return _vk.Call("friends.getOnline", parameters);
        }

        /// <summary>
        /// Get list of ids of mutual friends for both users.
        /// </summary>
        /// <param name="targetUid">Target user id</param>
        /// <param name="sourceUid">Source user id</param>
        /// <returns></returns>
        public List<long> GetMutual(long targetUid, long sourceUid)
        {
            var parameters = new VkParameters { { "target_uid", targetUid }, { "source_uid", sourceUid } };

            return _vk.Call("friends.getMutual", parameters);
        }

        /// <summary>
        /// Get info about friends status between current user and another users.
        /// </summary>
        /// <param name="uids">List of ids of another users</param>
        /// <returns>Dictionary, key is user id and value is friend status.</returns>
        public IDictionary<long, FriendStatus> AreFriends(IEnumerable<long> uids)
        {
            if (uids == null)
                throw new ArgumentNullException("uids");

            var parameters = new VkParameters { { "uids", uids } };

            VkResponseArray ids = _vk.Call("friends.areFriends", parameters);

            return ids.ToDictionary(r => (long)r["uid"], r => (FriendStatus)r["friend_status"]);
        }
    }
}