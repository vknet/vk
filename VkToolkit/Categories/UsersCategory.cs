using System;
using System.Collections.Generic;
using System.Linq;
using VkToolkit.Enums;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Categories
{
    public class UsersCategory
    {
        private readonly VkApi _vk;

        public UsersCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Search users by query.
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="itemsCount">Count of users by query.</param>
        /// <param name="fields">Additional fields for retrieving.</param>
        /// <param name="count">Count of records in fetch.</param>
        /// <param name="offset">Offset of records in fetch.</param>
        /// <returns></returns>
        public List<User> Search(string query, out int itemsCount, ProfileFields fields = null, int count = 20, int offset = 0)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Query can not be null or empty.");

            var parameters = new VkParameters { { "q", query }, { "fields", fields }, { "count", count } };
            if (offset > 0)
                parameters.Add("offset", offset);

            VkResponseArray response = _vk.Call("users.search", parameters);

            itemsCount = response[0];

            return response.Skip(1).ToListOf(r => (User)r);
        }

        /// <summary>
        /// Returns the application settings of the current user.
        /// </summary>
        /// <param name="uid">User Id</param>
        /// <returns>Returns bitmask settings of the current user in the given application.
        /// 
        /// For example, if the method returns 3, it means that the user allows the application to send them notifications and have access to their list of friends.
        /// </returns>
        public int GetUserSettings(long uid)
        {
            var parameters = new VkParameters { { "uid", uid } };

            return _vk.Call("getUserSettings", parameters);
        }

        /// <summary>
        /// Returns the balance of the current user in the given application in one hundredths of a vote.
        /// </summary>
        /// <returns>Returns the number of votes (in one hundredths) that are on the balance of the current user in an application. </returns>
        public int GetUserBalance()
        {
            return _vk.Call("getUserBalance", VkParameters.Empty);
        }

        /// <summary>
        /// Get users' groups.
        /// </summary>
        /// <param name="uid">User Id</param>
        /// <returns>List of group Ids</returns>
        public List<Group> GetGroups(int uid)
        {
            var parameters = new VkParameters { { "uid", uid } };

            var response = _vk.Call("getGroups", parameters);

            return response.ToListOf(id => new Group { Id = id });
        }

        /// <summary>
        /// Returns information on whether a user has installed an application or not.
        /// </summary>
        /// <param name="uid">User Id</param>
        /// <returns>Returns true if the user has installed the given application, otherwise – false.</returns>
        public bool IsAppUser(long uid)
        {
            var parameters = new VkParameters { { "uid", uid } };

            return _vk.Call("isAppUser", parameters);
        }
        
        /// <summary>
        /// Returns standard information about groups of which the current user is a member
        /// </summary>
        /// <returns>Returns standard information about groups of which the current user is a member. </returns>
        public List<Group> GetGroupsFull()
        {
            return _vk.Call("getGroupsFull", VkParameters.Empty);
        }

        /// <summary>
        /// Returns standard information about groups from the "gids" list.
        /// </summary>
        /// <param name="gids">List of group IDs</param>
        /// <returns></returns>
        public List<Group> GetGroupsFull(IEnumerable<long> gids)
        {
            if (gids == null)
                throw new ArgumentNullException("gids");
            
            var parameters = new VkParameters { { "gids", gids } };

            return _vk.Call("getGroupsFull", parameters);
        }

        /// <summary>
        /// Get info about user.
        /// </summary>
        /// <param name="uid">User Id</param>
        /// <param name="fields">Fields of the profile (can be combined).</param>
        /// <returns>User object.</returns>
        public User Get(long uid, ProfileFields fields = null)
        {
            var parameters = new VkParameters { { "uid", uid }, { "fields", fields } };

            VkResponseArray response = _vk.Call("getProfiles", parameters);

            return response[0];
        }

        /// <summary>
        /// Get info about users.
        /// </summary>
        /// <param name="uids">List of users' Ids.</param>
        /// <param name="fields">Fields of the profile (can be combined).</param>
        /// <returns>List of User objects.</returns>
        public List<User> Get(IEnumerable<long> uids, ProfileFields fields = null)
        {
            if (uids == null)
                throw new ArgumentNullException("uids");
            
            var parameters = new VkParameters { { "uids", uids }, { "fields", fields } };

            return _vk.Call("getProfiles", parameters);
        }
    }
}