---
layout: default
title: Метод Video.GetUserVideos
permalink: video/getUserVideos/
comments: true
---
# Метод Video.GetUserVideos
Возвращает список видеозаписей, на которых отмечен пользователь.

## Синтаксис
```csharp
public ReadOnlyCollection<Video> GetUserVideos(long userId, int? count = null, int? offset = null)
```

## Параметры
+ **userId** - идентификатор пользователя.
+ **count** - количество возвращаемых видеозаписей.
+ **offset** - смещение относительно первой найденной видеозаписи для выборки определенного подмножества.

## Результат
После успешного выполнения возвращает список объектов видеозаписей.

## Исключения
+ ЭТОТ МЕТОД ВЫБРАСЫВАЕТ ИСКЛЮЧЕНИЕ НА СЕРВЕРЕ ВК!!!

## Пример
```csharp
// TODO:
```