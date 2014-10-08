---
layout: default
title: Метод Video.ReportComment
permalink: video/reportComment/
comments: true
---
# Метод Video.ReportComment
Позволяет пожаловаться на комментарий к видеозаписи.

## Синтаксис
```csharp
public bool ReportComment(long commentId, long ownerId, VideoReportType reason)
```

## Параметры
+ **commentId** - идентификатор комментария.
+ **ownerId** - идентификатор владельца видеозаписи, к которой оставлен комментарий.
+ **reason** - тип жалобы.

## Результат
После успешного выполнения возвращает true.

## Исключения

## Пример
```csharp
// TODO:
```