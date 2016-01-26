---
layout: default
title: Метод Photos.GetChatUploadServer
permalink: photos/getChatUploadServer/
comments: true
---
# Метод Photos.GetChatUploadServer
Позволяет получить адрес для загрузки фотографий мультидиалогов.

Страница документации ВКонтакте [photos.getChatUploadServer](https://vk.com/dev/photos.getChatUploadServer).
## Синтаксис
``` csharp
public UploadServerInfo GetChatUploadServer(ulong chatId, ulong? cropX = null, ulong? cropY = null, ulong? cropWidth = null)
```

## Параметры
+ **chatId** - Идентификатор беседы, для которой нужно загрузить фотографию. положительное число, обязательный параметр
+ **cropX** - Координата x для обрезки фотографии. положительное число
+ **cropY** - Координата y для обрезки фотографии. положительное число
+ **cropWidth** - Ширина фотографии после обрезки в px. положительное число, минимальное значение 200

## Результат
После успешного выполнения возвращает объект с единственным полем **UploadUrl**.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
