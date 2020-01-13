---
layout: default
title: Метод Wall.ReportPost
permalink: wall/reportPost/
comments: true
---
# Метод Wall.ReportPost
Позволяет пожаловаться на запись.

Страница документации ВКонтакте [wall.reportPost](https://vk.com/dev/wall.reportPost).

## Синтаксис
``` csharp
public bool ReportPost(long ownerId, long postId, ReportReason? reason = null)
```

## Параметры
+ **ownerId** — Идентификатор пользователя или сообщества, которому принадлежит запись. целое число, обязательный параметр
+ **postId** — Идентификатор записи. положительное число, обязательный параметр
+ **reason** — Причина жалобы: 

0 — спам; 
1 — детская порнография; 
2 — экстремизм; 
3 — насилие; 
4 — пропаганда наркотиков; 
5 — материал для взрослых; 
6 — оскорбление. 
положительное число

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var reportPost = _api.Wall.ReportPost(ownerId: 0, postId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 17:04:31
