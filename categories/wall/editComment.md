---
layout: default
title: Метод Wall.EditComment
permalink: wall/editComment/
comments: true
---
# Метод Wall.EditComment
Редактирует комментарий на стене пользователя или сообщества.

Страница документации ВКонтакте [wall.editComment](https://vk.com/dev/wall.editComment).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).
Требуются [права доступа](https://vk.com/dev/permissions) wall.

## Синтаксис
``` csharp
public bool EditComment(long commentId, string message, long? ownerId = null, IEnumerable<MediaAttachment> attachments = null)
```

## Параметры
+ **OwnerId** - Идентификатор владельца стены. По умолчанию идентификатор текущего пользователя.
+ **CommentId** - Идентификатор комментария, который необходимо отредактировать. Обязательный параметр.
+ **Message** - Новый текст комментария. Обязательный параметр, если не передан параметр **Attachments**.
+ **Attachments** - Новые вложения к комментарию. список строк, разделенных через запятую

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
//не реализовано
```

## Версия Вконтакте API v.5.110
Дата обновления: 23.06.2020 1:52
