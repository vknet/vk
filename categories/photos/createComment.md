---
layout: default
title: Метод Photos.CreateComment
permalink: photo/createComment/
comments: true
---
# Метод Photos.CreateComment
Создает новый комментарий к фотографии.

## Синтаксис
```csharp
long CreateComment(long photoId, long? ownerId = null, string message = null, IEnumerable<string> attachments = null, bool? fromGroup = null, bool? replyToComment = null, string accessKey = null)
```

## Параметры
+ **ownerId** - идентификатор пользователя или сообщества, которому принадлежит фотография.
+ **photoId** - индентификатор фотографии
+ **message** - текст комментария (является обязательным, если не задан параметр attachments).
+ **attachments** - список объектов, приложенных к комментарию
+ **fromGroup** - Данный параметр учитывается, если oid < 0 (комментарий к фотографии группы). 1 — комментарий будет опубликован от имени группы, 0 — комментарий будет опубликован от имени пользователя (по умолчанию).
+ **replyToComment**
+ **accessKey**

## Результат
После успешного выполнения возвращает идентификатор созданного комментария.

## Пример
```csharp
// TODO:
```

