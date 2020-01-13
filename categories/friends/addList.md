---
layout: default
title: Метод Friends.AddList
permalink: friends/addList/
comments: true
---
# Метод Friends.AddList
Создает новый список друзей у текущего пользователя.

Страница документации ВКонтакте [friends.addList](https://vk.com/dev/friends.addList).

## Синтаксис
``` csharp
public long AddList(string name, IEnumerable<long> userIds)
```

## Параметры
+ **name** — Название создаваемого списка друзей. строка, обязательный параметр
+ **userIds** — Идентификаторы пользователей, которых необходимо поместить в созданный список. список положительных чисел, разделенных запятыми

## Результат
После успешного выполнения возвращает идентификатор (list_id) созданного списка друзей.

## Пример
``` csharp
var addList = _api.Friends.AddList(name: "name");
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 13:09:06
