## Пример работы метода Friends_Get

```csharp
void GetFriendList()
       {

          var friends = vk.Friends.Get(new FriendsGetParams
          {
               UserId = vk.UserId, // Здесь хранится id авторизованного пользователя.
              Fields = ProfileFields.FirstName | ProfileFields.LastName

          });

          foreach (var friend in friends)
          {
               Console.WriteLine($"{friend.FirstName} {friend.LastName}");+        
          }
     }

```
В результате работы метода отобразится список друзей текущего авторизованного пользователя.
