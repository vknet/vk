using System;
using VkToolkit.Utils;

namespace VkToolkit.Model
{
    /// <summary>
    /// Регион
    /// </summary>
    public class Region
    {
        /// <summary>
        /// Идентификатор региона
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название региона
        /// </summary>
        public string Title { get; set; }

        internal static Region FromJson(VkResponse response)
        {
            var region = new Region();

            string regionId = response["region_id"];

            region.Id = Convert.ToInt32(regionId);
            region.Title = response["title"];

            return region;
        }
    }
}