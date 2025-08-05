using System;
using VkNet.Shared;

var api = Api.GetInstance();

api.Auth();
Console.WriteLine(api.Token);
var res = api.Groups.Get(new());

Console.WriteLine(res.TotalCount);

Console.ReadLine();