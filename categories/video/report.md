---
layout: default
title: Метод Video.Report
permalink: video/report/
comments: true
---
# Метод Video.Report
Позволяет пожаловаться на видеозапись.

Страница документации ВКонтакте [video.report](https://vk.com/dev/video.report).

## Синтаксис
``` csharp
public bool Report(
	long videoId,
	ReportReason reason,
	long? ownerId,
	string comment = null,
	string searchQuery = null
)
```

## Параметры
+ **ownerId** - Идентификатор пользователя или сообщества, которому принадлежит видеозапись. целое число, обязательный параметр
+ **videoId** - Идентификатор видеозаписи. положительное число, обязательный параметр
+ **reason** - Тип жалобы: 
0 – это спам 
1 – детская порнография 
2 – экстремизм 
3 – насилие 
4 – пропаганда наркотиков 
5 – материал для взрослых 
6 – оскорбление положительное число
+ **comment** - Комментарий для жалобы. строка
+ **searchQuery** - Поисковой запрос, если видеозапись была найдена через поиск. строка

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var report = _api.Video.Report(ownerId: 0, videoId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 14:50:41
