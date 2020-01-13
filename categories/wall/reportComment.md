---
layout: default
title: Метод Wall.ReportComment
permalink: wall/reportComment/
comments: true
---
# Метод Wall.ReportComment
Позволяет пожаловаться на комментарий к записи.

Страница документации ВКонтакте [wall.reportComment](https://vk.com/dev/wall.reportComment).

## Синтаксис
``` csharp
public bool ReportComment(long ownerId, long commentId, ReportReason? reason)
```

## Параметры
+ **ownerId** — Идентификатор пользователя или сообщества, которому принадлежит комментарий. целое число, обязательный параметр
+ **commentId** — Идентификатор комментария. положительное число, обязательный параметр
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
var reportComment = _api.Wall.ReportComment(ownerId: 0, commentId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 17:04:31
