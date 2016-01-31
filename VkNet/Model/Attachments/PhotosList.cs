using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	[Obsolete("Для версии API ниже 5.0")]
    public class PhotosList : MediaAttachment
    {
        static PhotosList()
        {
            RegisterType(typeof(PhotosList), "photos_list");
        }

        #region Private Methods

        internal static PhotosList FromJson(VkResponse response)
        {
            var list = new PhotosList();

            return list;
        }

        #endregion
    }
}