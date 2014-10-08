---
layout: default
title: Метод Fave.GetPhotos
permalink: fave/getPhotos/
comments: true
---
# Метод Fave.GetPhotos
Возвращает фотографии, на которых текущий пользователь поставил отметку "Мне нравится".

## Синтаксис
```csharp
public ReadOnlyCollection<Photo> GetPhotos(int? count = null, int? offset = null)
```

## Параметры
+ **count** - Количество пользователей, информацию о которых необходимо вернуть.
+ **offset** - Смещение, необходимое для выборки определенного подмножества пользователей.

## Результат
После успешного выполнения возвращает список объектов фотографий.

## Исключения

## Пример
```csharp
// TODO:
```