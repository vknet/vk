---
layout: default
title: Метод Newsfeed.UnignoreItem
permalink: newsfeed/unignoreItem/
comments: true
---
# Метод Newsfeed.UnignoreItem
Позволяет вернуть ранее скрытый объект в ленту новостей.

Страница документации ВКонтакте [newsfeed.unignoreItem](https://vk.com/dev/newsfeed.unignoreItem).

## Синтаксис
``` csharp
public bool UnignoreItem(NewsObjectTypes type, long ownerId, long itemId)
```

## Параметры
+ **type** — Тип объекта. Возможные значения: 
wall — запись на стене; 
tag — отметка на фотографии; 
profilephoto — фотография профиля; 
video — видеозапись; 
photo — фотография; 
audio — аудиозапись. 
строка, обязательный параметр
+ **ownerId** — Идентификатор владельца объекта (пользователь или сообщество). Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **itemId** — Идентификатор объекта. положительное число, обязательный параметр

## Результат
В результате успешного выполнения возвращает **true**.

## Пример
``` csharp
var unignoreItem = _api.Newsfeed.UnignoreItem(type: "type", ownerId: 0, itemId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 13:09:42
