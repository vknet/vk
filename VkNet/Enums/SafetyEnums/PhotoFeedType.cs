namespace VkNet.Enums.SafetyEnums
{
    public sealed class PhotoFeedType : SafetyEnum<PhotoFeedType>
    {
        public static PhotoFeedType Photo = RegisterPossibleValue("photo");

        public static PhotoFeedType PhotoTag = RegisterPossibleValue("photo_tag");
    }
}