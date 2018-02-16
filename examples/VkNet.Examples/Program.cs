using System;
using VkNet.Model.RequestParams;
using VkNet.Shared;

namespace VkNet.Examples
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var api = new VkApi();
            
            api.Auth();
            Console.WriteLine(api.Token);
            var res = api.Groups.Get(new GroupsGetParams());

            Console.WriteLine(res.TotalCount);

            Console.ReadLine();
        }
    }
}