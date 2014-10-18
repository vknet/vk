---
layout: default
title: Метод Video.Report
permalink: video/report/
comments: true
---
# Метод Video.Report
Позволяет пожаловаться на видеозапись.

## Синтаксис
```csharp
public bool Report(
	long videoId, 
	VideoReportType reason, 
	long? ownerId = null, 
	string comment, 
	string searchQuery
)
```

## Параметры
+ **videoId** - идентификатор видеозаписи.
+ **reason** - тип жалобы.
+ **ownerId** - идентификатор пользователя или сообщества, которому принадлежит видеозапись.
+ **comment** - комментарий для жалобы.
+ **searchQuery** - поисковой запрос, если видеозапись была найдена через поиск.

## Результат
После успешного выполнения возвращает true.

## Исключения

## Пример
```csharp
// TODO:
```