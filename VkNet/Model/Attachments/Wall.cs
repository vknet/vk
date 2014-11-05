using VkNet.Utils;

namespace VkNet.Model.Attachments
{
    public class Wall : MediaAttachment
    {
        static Wall()
        {
            RegisterType(typeof(Wall), "wall");
        }

#warning add properties to wall class, see MessagesCategoryTest.GetHistory_ContainsRepost_Error46 method.
        // TODO add properties, 

        internal static Wall FromJson(VkResponse response)
        {
            var wall = new Wall();

            return wall;
        }
    }
}