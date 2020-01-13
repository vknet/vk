---
layout: default
title: Метод Friends.GetRecent
permalink: friends/getRecent/
comments: true
---
# Метод Friends.GetRecent
Возвращает список идентификаторов недавно добавленных друзей текущего пользователя

Страница документации ВКонтакте [friends.getRecent](https://vk.com/dev/friends.getRecent).

## Синтаксис
``` csharp
public ReadOnlyCollection<long> GetRecent(long? count = null)
```

## Параметры
+ **count** — Максимальное количество недавно добавленных друзей, которое необходимо получить. положительное число, по умолчанию 100, максимальное значение 1000

## Результат
После успешного выполнения возвращает отсортированный в антихронологическом порядке список идентификаторов (id) недавно добавленных друзей текущего пользователя.

## Пример
``` csharp
var getRecent = api.Friends.GetRecent(20);

foreach(var item in getRecent)
{
    //logic
}
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 13:09:06
