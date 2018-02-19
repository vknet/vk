## Пример работы метода Albums_Get

```csharp
void GetPhotoAlbumsList()
        {
            var albums = vk.Photo.GetAlbums(new PhotoGetAlbumsParams
            {
                OwnerId = vk.UserId, // Будет выведен список фотоальбомов авторизованного пользователя.
                NeedSystem = true,
            });

            foreach (var album in albums)
            {
                Console.WriteLine($"{album.Title} {album.Size}");
            }
        }

```
В результате работы метода отобразится список фотоальбомов текущего авторизованного пользователя.
