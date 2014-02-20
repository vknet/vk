using Moq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Utils;

namespace VkNet.Tests.Categories
{
    [TestFixture]
    public class VideoCategoryTest
    {
         private VideoCategory GetMockedVideoCategory(string url, string json)
         {
             var browser = new Mock<IBrowser>();
             browser.Setup(m => m.GetJson(url)).Returns(json);

             return new VideoCategory(new VkApi{AccessToken = "token", Browser = browser.Object, Version = "5.9"});
         }


    }
}