---
layout: default
title: Метод Wall.DeleteComment
permalink: wall/deleteComment/
comments: true
---
# Метод Wall.DeleteComment
Удаляет комментарий текущего пользователя к записи на своей или чужой стене.

Страница документации ВКонтакте [wall.deleteComment](https://vk.com/dev/wall.deleteComment).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).  
Требуются [права доступа](https://vk.com/dev/permissions) wall.

## Синтаксис
``` csharp
public bool DeleteComment(long? ownerId, long commentId)
```

## Параметры
+ **ownerId** - Идентификатор пользователя, на чьей стене находится комментарий к записи.  
По умолчанию идентификатор текущего пользователя
+ **commentId** - Идентификатор комментария. Обязательный параметр.

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var deleteComment = _api.Wall.DeleteComment(commentId: 0);
```

## Версия Вконтакте API v.5.110
Дата обновления: 23.06.2020 0:02
