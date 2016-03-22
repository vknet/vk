---
layout: default
title: Метод Photos.SaveOwnerPhoto
permalink: photos/saveOwnerPhoto/
comments: true
---
# Метод Photos.SaveOwnerPhoto
Позволяет сохранить главную фотографию пользователя или сообщества.

Страница документации ВКонтакте [photos.saveOwnerPhoto](https://vk.com/dev/photos.saveOwnerPhoto).

## Синтаксис
``` csharp
public Photo SaveOwnerPhoto(string response)
```

## Параметры
+ **response** - Параметр, возвращаемый в результате загрузки фотографии на сервер. строка

## Результат
После успешного выполнения возвращает объект, содержащий поля photo_hash и photo_src (при работе через VK.api метод вернёт поля photo_src, photo_src_big, photo_src_small). Параметр photo_hash необходим для подтверждения пользователем изменения его фотографии через вызов метода saveProfilePhoto Javascript API. Поле photo_src содержит путь к загруженной фотографии.

## Пример
``` csharp
var saveOwnerPhoto = _api.Photos.SaveOwnerPhoto();
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
