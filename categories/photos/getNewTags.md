---
layout: default
title: Метод Photos.GetNewTags
permalink: photos/getNewTags/
comments: true
---
# Метод Photos.GetNewTags
Возвращает список фотографий, на которых есть непросмотренные отметки.

Страница документации ВКонтакте [photos.getNewTags](https://vk.com/dev/photos.getNewTags).
## Синтаксис
``` csharp
public ReadOnlyCollection<Photo> GetNewTags(out int countTotal, uint? offset = null, uint? count = null)
```

## Параметры
+ **Offset** - Смещение, необходимое для получения определённого подмножества фотографий. целое число
+ **Count** - Количество фотографий, которые необходимо вернуть. положительное число, максимальное значение 100, по умолчанию 20

## Результат
После успешного выполнения возвращает список объектов photo с дополнительными полями: 

+ **PlacerId** — идентификатор пользователя, сделавшего отметку; 
+ **TagCreated** — дата создания отметки в формате unixtime; 
+ **TagId** — идентификатор отметки.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
