---
layout: default
title: Метод Wall.EditComment
permalink: wall/editComment/
comments: true
---
# Метод Wall.EditComment
Редактирует комментарий на стене пользователя или сообщества.

Страница документации ВКонтакте [wall.editComment](https://vk.com/dev/wall.editComment).
## Синтаксис
``` csharp
public bool EditComment(long? ownerId, long commentId, string message, IEnumerable<string> attachments)
```

## Параметры
+ **ownerId** - Идентификатор владельца стены. целое число, по умолчанию идентификатор текущего пользователя
+ **commentId** - Идентификатор комментария, который необходимо отредактировать. положительное число, обязательный параметр
+ **message** - Новый текст комментария. строка
+ **attachments** - Новые вложения к комментарию. список строк, разделенных через запятую

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 17:04:31
