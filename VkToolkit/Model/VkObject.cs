using System;
using VkToolkit.Enums;
using VkToolkit.Utils;

namespace VkToolkit.Model
{
    /// <summary>
    /// Определяет тип объекта
    /// </summary>
    public class VkObject
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public float Id { get; set; }

        /// <summary>
        /// Тип объекта
        /// </summary>
        public VkObjectType Type { get; set; }

        internal static VkObject FromJson(VkResponse response)
        {
            var obj = new VkObject();

            obj.Id = response["object_id"];

            string type = response["type"];
            switch (type)
            {
                case "group":
                    obj.Type = VkObjectType.Group;
                    break;
 
                case "user":
                    obj.Type = VkObjectType.User;
                    break;

                case "application":
                    obj.Type = VkObjectType.Application;
                    break;
            }

            return obj;
        }
    }
}