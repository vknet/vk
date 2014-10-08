---
layout: default
title: Метод Audio.GetPopular
permalink: audio/getPopular/
comments: true
---
# Метод Audio.GetPopular
Возвращает список аудиозаписей из раздела "Популярное".

## Синтаксис
```csharp
public ReadOnlyCollection<Audio> GetPopular(bool onlyEng, AudioGenre? genre = null, int? count = null, int? offset = null)
```

## Параметры
+ **onlyEng** - true – возвращать только зарубежные аудиозаписи. false – возвращать все аудиозаписи.
+ **genre** - идентификатор жанра.
+ **count** - количество возвращаемых аудиозаписей.
+ **offset** - смещение, необходимое для выборки определенного подмножества аудиозаписей.

## Результат
Список аудиозаписей из раздела "Популярное"

## Исключения

## Пример
```csharp
// TODO:
```