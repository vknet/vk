namespace VkNet.Model
{
    using System.Diagnostics;

    using Enums;
    using Utils;

    /// <summary>
    /// Определяет тип объекта
    /// </summary>
    [DebuggerDisplay("Id = {Id}, Type = {Type}")]
    public class VkObject
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Тип объекта
        /// </summary>
        public VkObjectType Type { get; set; }

        internal static VkObject FromJson(VkResponse response)
		{
			var obj = new VkObject
			{
				Id = Utilities.GetNullableLongId(response["object_id"])
			};

			string type = response["type"];
			switch (type)
			{
				case "group":
					{
						obj.Type = VkObjectType.Group;
						break;
					}
				case "user":
					{
						obj.Type = VkObjectType.User;
						break;
					}
				case "application":
					{
						obj.Type = VkObjectType.Application;
						break;
					}
			}

			return obj;
		}
	}
}