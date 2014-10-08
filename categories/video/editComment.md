---
layout: default
title: Метод Video.EditComment
permalink: video/editComment/
comments: true
---
# Метод Video.EditComment
Изменяет текст комментария к видеозаписи.

## Синтаксис
```csharp
public bool EditComment(long commentId, string message, long? ownerId = null)
```

## Параметры
+ **commentId** - идентификатор комментария.
+ **message** - новый текст комментария.
+ **ownerId** - идентификатор пользователя или сообщества, которому принадлежит видеозапись.

## Результат
После успешного выполнения возвращает true.

## Исключения

## Пример
```csharp
// TODO:
```