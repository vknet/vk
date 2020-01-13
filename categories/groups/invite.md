---
layout: default
title: Метод Groups.Invite
permalink: groups/invite/
comments: true
---
# Метод Groups.Invite
Позволяет приглашать друзей в группу.

Страница документации ВКонтакте [groups.invite](https://vk.com/dev/groups.invite).

## Синтаксис
``` csharp
public bool Invite(long groupId, long userId)
```

## Параметры
+ **groupId** — Идентификатор группы, в которую необходимо выслать приглашение положительное число, обязательный параметр
+ **userId** — Идентификатор пользователя, которому необходимо выслать приглашение положительное число, обязательный параметр

## Результат
В случае успешного выполнения возвращает **true**.

## Пример
``` csharp
var invite = _api.Groups.Invite(groupId: 0, userId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
