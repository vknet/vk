void GetFriendList()
+        {
+
+            var friends = vk.Friends.Get(new FriendsGetParams
+            {
+                UserId = vk.UserId, // Здесь хранится id авторизованного пользователя.
+                Fields = ProfileFields.FirstName | ProfileFields.LastName
+
+            });
+
+            foreach (var friend in friends)
+            {
+                Console.WriteLine($"{friend.FirstName} {friend.LastName}");
+            }
+
+        }
