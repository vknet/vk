---
layout: default
title: Метод Photos.GetOwnerPhotoUploadServer
permalink: photos/getOwnerPhotoUploadServer/
comments: true
---
# Метод Photos.GetOwnerPhotoUploadServer
Возвращает адрес сервера для загрузки главной фотографии на страницу пользователя или сообщества.

Страница документации ВКонтакте [photos.getOwnerPhotoUploadServer](https://vk.com/dev/photos.getOwnerPhotoUploadServer).
## Синтаксис
``` csharp
public UploadServerInfo GetOwnerPhotoUploadServer(long? ownerId = null)
```

## Параметры
+ **ownerId** - Идентификатор сообщества или текущего пользователя. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя

## Результат
После успешного выполнения возвращает объект с единственным полем **UploadUrl**.

## Пример
``` csharp
// Пример кода
```
