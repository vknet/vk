---
layout: default
title: Метод Fave.GetVideos
permalink: fave/getVideos/
comments: true
---
# Метод Fave.GetVideos
Возвращает список видеозаписей, на которых текущий пользователь поставил отметку «Мне нравится».

Страница документации ВКонтакте [fave.getVideos](https://vk.com/dev/fave.getVideos).

## Синтаксис
``` csharp
public ReadOnlyCollection<Video> GetVideos(int? count = null, int? offset = null)
public FaveVideoEx GetVideosEx(int? count = null, int? offset = null)
```

## Параметры
+ **offset** - Смещение, необходимое для выборки определенного подмножества видеозаписей. положительное число
+ **count** - Количество видеозаписей, информацию о которых необходимо вернуть. положительное число, по умолчанию 50
+ **extended** - 1 — возвращать дополнительные объекты profiles и groups, которые содержат id и имя/название владельцев видео. флаг, может принимать значения 1 или 0

## Результат
После успешного выполнения возвращает список объектов видеозаписей.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 13:59:16
