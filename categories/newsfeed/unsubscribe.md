---
layout: default
title: Метод Newsfeed.Unsubscribe
permalink: newsfeed/unsubscribe/
comments: true
---
# Метод Newsfeed.Unsubscribe
Отписывает текущего пользователя от комментариев к заданному объекту.

Страница документации ВКонтакте [newsfeed.unsubscribe](https://vk.com/dev/newsfeed.unsubscribe).

## Синтаксис
``` csharp
public bool Unsubscribe(CommentObjectType type, long itemId, long? ownerId = null)
```

## Параметры
+ **type** - Тип объекта, от комментариев к которому необходимо отписаться. 
Возможные типы:
post — запись на стене пользователя или группы;
photo — фотография;
video — видеозапись;
topic — обсуждение;
note — заметка. строка, обязательный параметр
+ **ownerId** - Идентификатор владельца объекта. целое число, по умолчанию идентификатор текущего пользователя
+ **itemId** - Идентификатор объекта. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var unsubscribe = _api.Newsfeed.Unsubscribe(type: "type", itemId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 13:09:42
