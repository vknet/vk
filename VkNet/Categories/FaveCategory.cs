namespace VkNet.Categories
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Model;
    using Utils;

    public class FaveCategory
    {
        private readonly VkApi _vk;

        public FaveCategory(VkApi vk)
        {
            _vk = vk;
        }

        public ReadOnlyCollection<User> GetUsers(int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"count", count},
                    {"offset", offset}
                };

            VkResponseArray response = _vk.Call("fave.getUsers", parameters);

            return response.ToReadOnlyCollectionOf<User>(x => x);
        }

        public ReadOnlyCollection<Photo> GetPhotos(int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"count", count},
                    {"offset", offset}
                };

            VkResponseArray response = _vk.Call("fave.getPhotos", parameters);
            return response.ToReadOnlyCollectionOf<Photo>(x => x);
        }

        public void GetPosts()
        {
            throw new NotImplementedException();
        }

        public void GetVideos()
        {
            throw new NotImplementedException();
        }

        public void GetLinks()
        {
            throw new NotImplementedException();
        }
    }
}