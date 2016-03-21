---
layout: default
title: Метод Groups.ApproveRequest
permalink: groups/approveRequest/
comments: true
---
# Метод Groups.ApproveRequest
Позволяет одобрить заявку в группу от пользователя.

Страница документации ВКонтакте [groups.approveRequest](https://vk.com/dev/groups.approveRequest).

## Синтаксис
``` csharp
public bool ApproveRequest(long groupId, long userId)
```

## Параметры
+ **groupId** - Идентификатор группы, заявку в которую необходимо одобрить. положительное число, обязательный параметр
+ **userId** - Идентификатор пользователя, заявку которого необходимо одобрить. положительное число, обязательный параметр

## Результат
В случае успешного выполнения возвращает **true**.

## Пример
``` csharp
var approveRequest = _api.Groups.ApproveRequest(groupId: 0, userId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
