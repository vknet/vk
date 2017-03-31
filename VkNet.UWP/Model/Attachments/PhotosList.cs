using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// 
	/// </summary>
	[Obsolete("Для версии API ниже 5.0")]
	[DataContract]
	public class PhotosList : MediaAttachment
    {
        static PhotosList()
        {
            RegisterType(typeof(PhotosList), "photos_list");
        }

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static PhotosList FromJson(VkResponse response)
        {
            var list = new PhotosList();

            return list;
        }

        #endregion
    }
}