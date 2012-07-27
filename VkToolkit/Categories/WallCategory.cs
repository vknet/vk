using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VkToolkit.Enums;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Categories
{
    public class WallCategory
    {
        private readonly VkApi _vk;
        public WallCategory(VkApi vk)
        {
            _vk = vk;
        }

        public IEnumerable<WallRecord> Get(long ownerId, out int totalCount, int? count = null, int? offset = null, WallFilter filter = WallFilter.All/*, bool isExtended = false*/)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("owner_id", ownerId + "");
            if (count.HasValue && count.Value > 0)
                values.Add("count", count.Value + "");
            if (offset.HasValue && offset.Value > 0)
                values.Add("offset", offset.Value + "");
            values.Add("filter", filter.ToString().ToLowerInvariant());
            // TODO add it later
            //if (isExtended)
            //    values.Add("extended", "1");

            string url = _vk.GetApiUrl("wall.get", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var array = (JArray)obj["response"];

            totalCount = (int) array[0];

            var output = new List<WallRecord>();
            for (int i = 1; i < array.Count; i++ )
            {
                WallRecord record = Utilities.GetWallRecord((JObject) array[i]);
                output.Add(record);
            }
            return output;
        }

        public void GetComments()
        {
            throw new NotImplementedException();
        }

        public void GetById()
        {
            throw new NotImplementedException();
        }

        public void Post()
        {
            throw new NotImplementedException();
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Restore()
        {
            throw new NotImplementedException();
        }

        public void AddComment()
        {
            throw new NotImplementedException();
        }

        public void DeleteComment()
        {
            throw new NotImplementedException();
        }

        public void RestoreComment()
        {
            throw new NotImplementedException();
        }

        public void AddLike()
        {
            throw new NotImplementedException();
        }

        public void DeleteLike()
        {
            throw new NotImplementedException();
        }
    }
}