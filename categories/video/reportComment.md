---
layout: default
title: Метод Video.ReportComment
permalink: video/reportComment/
comments: true
---
# Метод Video.ReportComment
Позволяет пожаловаться на комментарий к видеозаписи.

Страница документации ВКонтакте [video.reportComment](https://vk.com/dev/video.reportComment).

## Синтаксис
``` csharp
public bool ReportComment(long commentId, long ownerId, ReportReason reason)
```

## Параметры
+ **ownerId** — Идентификатор владельца видеозаписи, к которой оставлен комментарий. целое число, обязательный параметр
+ **commentId** — Идентификатор комментария. положительное число, обязательный параметр
+ **reason** — Тип жалобы: 
0 – это спам 
1 – детская порнография 
2 – экстремизм 
3 – насилие 
4 – пропаганда наркотиков 
5 – материал для взрослых 
6 – оскорбление положительное число

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var reportComment = _api.Video.ReportComment(ownerId: 0, commentId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 14:50:41
