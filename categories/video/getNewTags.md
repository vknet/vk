---
layout: default
title: Метод Video.GetNewTags
permalink: video/getNewTags/
comments: true
---
# Метод Video.GetNewTags
Возвращает список видеозаписей, на которых есть непросмотренные отметки. 

# Синтаксис
```csharp
public ReadOnlyCollection<Video> GetNewTags(
	int? count = null, 
	int? offset = null
)
```

## Параметры
+ **count** - Количество видеозаписей, которые необходимо вернуть (максимальное значение 100, по умолчанию 20).
+ **offset** - Смещение, необходимое для получения определённого подмножества видеозаписей.

## Результат
После успешного выполнения возвращает список объектов*Video* с дополнительным полем *Tag*.
## Исключения

## Пример
```csharp
// TODO:
```