---
layout: default
title: Метод Friends.GetLists
permalink: friends/getLists/
comments: true
---
# Метод Friends.GetLists
Возвращает список меток друзей текущего пользователя.

Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token). Требуются [права доступа](https://vk.com/dev/permissions): **friends**.

Страница документации ВКонтакте [friends.getLists](https://vk.com/dev/friends.getLists).

## Синтаксис
``` csharp
public ReadOnlyCollection<FriendList> GetLists(long? userId = null, bool? returnSystem = null)
```

## Параметры
+ **user_id** — идентификатор пользователя. Положительное число, по умолчанию идентификатор текущего пользователя.
+ **return_system** — возвращать ли системный список публичных меток друзей пользователя. Флаг, может принимать значения *1* или *0*.

## Результат
После успешного выполнения возвращает список объектов, каждый из которых содержит следующие поля: 
    + **name** — название списка друзей,
    + **id** — идентификатор списка друзей.

## Исключения
+ **30** - This profile is private.
+ В ходе выполнения могут произойти общие ошибки. Их описание находится на [отдельной странице](https://vk.com/dev/errors).

## Пример
``` csharp
var getLists = _api.Friends.GetLists();
```

## Версия Вконтакте API v.5.103
Дата обновления: 17.01.2020 13:24.
