---
layout: default
title: Метод Photo.CreateComment
permalink: photo/createcomment
comments: true
---
# Метод Copy
Создает новый комментарий к фотографии.

## Синтаксис
```csharp
long CreateComment(long photoId, long? ownerId = null, string message = null, IEnumerable<string> attachments = null, bool? fromGroup = null, bool? replyToComment = null, string accessKey = null)
```

## Параметры
+ **owner_id** - идентификатор пользователя или сообщества, которому принадлежит фотография.
+ **photoID** - индентификатор фотографии
+ **message** - текст комментария (является обязательным, если не задан параметр attachments).
+ **attachments** - список объектов, приложенных к комментарию
+ **from_group** - Данный параметр учитывается, если oid < 0 (комментарий к фотографии группы). 1 — комментарий будет опубликован от имени группы, 0 — комментарий будет опубликован от имени пользователя (по умолчанию).
+ **reply_to_comment**
+ **sticker_id**
+ **access_key**

## Результат
После успешного выполнения возвращает идентификатор созданного комментария.
