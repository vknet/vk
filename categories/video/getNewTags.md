---
layout: default
title: Метод Video.GetNewTags
permalink: video/getNewTags/
comments: true
---
# Метод Video.GetNewTags
Возвращает список видеозаписей, на которых есть непросмотренные отметки.

Страница документации ВКонтакте [video.getNewTags](https://vk.com/dev/video.getNewTags).

## Синтаксис
``` csharp
public ReadOnlyCollection<Video> GetNewTags(int? count = null, int? offset = null)
```

## Параметры
+ **offset** — Смещение, необходимое для получения определённого подмножества видеозаписей. целое число
+ **count** — Количество видеозаписей, которые необходимо вернуть. положительное число, максимальное значение 100, по умолчанию 20

## Результат
После успешного выполнения возвращает список объектов video с дополнительными полями: 

placer_id — идентификатор пользователя, сделавшего отметку; 
tag_created — дата создания отметки в формате unixtime; 
tag_id — идентификатор отметки.

## Пример
``` csharp
var getNewTags = _api.Video.GetNewTags();
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 14:50:41
