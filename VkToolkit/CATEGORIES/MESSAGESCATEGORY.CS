using System;

namespace VkToolkit.Categories
{
    public class MessagesCategory
    {
        private readonly VkApi _vk;
        public MessagesCategory(VkApi vk)
        {
            _vk = vk;
        }

        public void Get()
        {
            _vk.IfAccessTokenNotDefinedThrowException();
            throw new NotImplementedException();
        }
    }
}