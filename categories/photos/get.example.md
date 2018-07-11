### Пример работы метода Photos_Get.
### Получение ссылок на фотографии в исходном разрешении.

```csharp
public List<string> GetPhotoList(long ownerID, long albumID) // Первый параметр ID пользователя. Второй параметр ID альбома.
        {
            var photolist = new List<string>();

            var photos = vkApi.Photo.Get(new PhotoGetParams
            {
                OwnerId = ownerID,
                AlbumId = PhotoAlbumType.Id(albumID)
            });

            photolist = photos.Where(x => x.Photo2560 != null || x.Photo1280 != null || x.Photo807 != null || x.Photo604 != null)
                              .Select(x => x.Photo2560?.ToString() ?? x.Photo1280?.ToString() ?? x.Photo807?.ToString() ?? x.Photo604.ToString())
                              .ToList();
            return photolist;
        }
```
В результате работы метода будет получен список ссылок на фотографии в исходном разрешении, по которым в дальнейшем можно будет скачать фотографии.
