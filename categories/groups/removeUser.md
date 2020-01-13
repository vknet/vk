---
layout: default
title: Метод Groups.RemoveUser
permalink: groups/removeUser/
comments: true
---
# Метод Groups.RemoveUser
Позволяет исключить пользователя из группы или отклонить заявку на вступление.

Страница документации ВКонтакте [groups.removeUser](https://vk.com/dev/groups.removeUser).

## Синтаксис
``` csharp
public bool RemoveUser(long groupId, long userId)
```

## Параметры
+ **groupId** — Идентификатор группы, из которой необходимо исключить пользователя. положительное число, обязательный параметр
+ **userId** — Идентификатор пользователя, которого нужно исключить. положительное число, обязательный параметр

## Результат
В случае успешного выполнения возвращает **true**.

## Пример
``` csharp
var removeUser = _api.Groups.RemoveUser(groupId: 0, userId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
