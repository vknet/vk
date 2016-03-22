---
layout: default
title: Метод Photos.ConfirmTag
permalink: photos/confirmTag/
comments: true
---
# Метод Photos.ConfirmTag
Подтверждает отметку на фотографии.

Страница документации ВКонтакте [photos.confirmTag](https://vk.com/dev/photos.confirmTag).

## Синтаксис
``` csharp
public bool ConfirmTag(ulong photoId, ulong tagId, long? ownerId = null)
```

## Параметры
+ **ownerId** - Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя
+ **photoId** - Идентификатор фотографии. обязательный параметр
+ **tagId** - Идентификатор отметки на фотографии. целое число, обязательный параметр

## Результат
После успешного выполнения возвращает 1.

## Пример
``` csharp
var confirmTag = _api.Photos.ConfirmTag(photoId: "photo_id", tagId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
