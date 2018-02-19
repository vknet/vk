void GetFriendList()
        {

            var friends = vk.Friends.Get(new FriendsGetParams
            {
                UserId = vk.UserId,
                Fields = ProfileFields.FirstName | ProfileFields.LastName

            });

            foreach (var friend in friends)
            {
                Console.WriteLine($"{friend.FirstName} {friend.LastName}");
            }
        }
