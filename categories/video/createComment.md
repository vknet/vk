---
layout: default
title: Метод Video.CreateComment
permalink: video/createComment/
comments: true
---
# Метод Video.CreateComment
Cоздает новый комментарий к видеозаписи.

## Синтаксис
```csharp
public long CreateComment(long videoId, string message, long? ownerId = null, bool isFromGroup)
```

## Параметры
+ **videoId** - идентификатор видеозаписи.
+ **message** - текст комментария.
+ **ownerId** - идентификатор пользователя или сообщества, которому принадлежит видеозапись.
+ **isFromGroup** - Данный параметр учитывается, если oid &lt; false (комментарий к видеозаписи группы). True — комментарий будет опубликован от имени группы, false — комментарий будет опубликован от имени пользователя (по умолчанию).

## Результат
После успешного выполнения возвращает идентификатор созданного комментария.

## Исключения

## Пример
```csharp
// TODO:
```