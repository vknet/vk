using System;
using System.Collections.Generic;
using VkToolkit.Enums;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Categories
{
    using System.Linq;

    public class WallCategory
    {
        private readonly VkApi _vk;

        public WallCategory(VkApi vk)
        {
            _vk = vk;
        }

        public List<WallRecord> Get(long ownerId, out int totalCount, int? count = null, int? offset = null, WallFilter filter = WallFilter.All/*, bool isExtended = false*/)
        {
            var parameters = new VkParameters
                {
                    { "owner_id", ownerId },
                    { "count", count },
                    { "offset", offset },
                    { "filter", filter.ToString().ToLowerInvariant() }
                };
            // TODO: add it later
            //if (isExtended)
            //    values.Add("extended", "1");

            VkResponseArray response = _vk.Call("wall.get", parameters);

            totalCount = response[0];

            return response.Skip(1).ToListOf(r => (WallRecord)r);
        }

        public void GetComments()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void GetById()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void Post()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void Edit()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void Delete()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void Restore()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void AddComment()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void DeleteComment()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void RestoreComment()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void AddLike()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void DeleteLike()
        {
            // TODO:
            throw new NotImplementedException();
        }
    }
}