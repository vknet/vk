using System;

namespace VkToolkit.Categories
{
    public class GroupsCategory
    {
        private VkApi _vk;

        public GroupsCategory(VkApi vk)
        {
            _vk = vk;
        }

        public bool Join(long gid, bool notSure = false)
        {
            throw new NotImplementedException();
        }

        public bool Leave(long gid)
        {
            throw new NotImplementedException();
        }

    }
}