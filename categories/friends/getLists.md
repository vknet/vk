---
layout: default
title: Метод Friends.GetLists
permalink: friends/getLists/
comments: true
---
# Метод Friends.GetLists
Возвращает список меток друзей текущего пользователя.

Страница документации ВКонтакте [friends.getLists](https://vk.com/dev/friends.getLists).

## Синтаксис
``` csharp
public ReadOnlyCollection<FriendList> GetLists(long? userId = null, bool? returnSystem = null)
```

## Параметры
+ **userId** — Идентификатор пользователя. положительное число, по умолчанию идентификатор текущего пользователя
+ **returnSystem** — Возвращать ли системный список публичных меток друзей пользователя. флаг, может принимать значения 1 или 0

## Результат
После успешного выполнения возвращает список объектов, каждый из которых содержит следующие поля: 

name — название списка друзей; 
id — идентификатор списка друзей.

## Пример
``` csharp
var getLists = _api.Friends.GetLists();
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 13:09:06
