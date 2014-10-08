---
layout: default
title: Метод Audio.MoveToAlbum
permalink: audio/moveToAlbum/
comments: true
---
# Метод Audio.MoveToAlbum
Перемещает аудиозаписи в альбом.

## Синтаксис
```csharp
public bool MoveToAlbum(long albumId, IEnumerable<long> audioIds, long? groupId = null)
```

## Параметры
+ **albumId** - идентификатор альбома, в который нужно переместить аудиозаписи.
+ **audioIds** - идентификаторы аудиозаписей, которые требуется переместить.
+ **groupId** - идентификатор сообщества, в котором размещены аудиозаписи. Если параметр не указан, работа ведется с аудиозаписями текущего пользователя.

## Результат
После успешного выполнения возвращает true.

## Исключения

## Пример
```csharp
// TODO:
```