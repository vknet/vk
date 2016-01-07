---
layout: default
title: Метод Photos.Copy
permalink: photos/copy/
comments: true
---
# Метод Photos.Copy
Позволяет скопировать фотографию в альбом "Сохраненные фотографии"

Страница документации ВКонтакте [photos.copy](https://vk.com/dev/photos.copy).
## Синтаксис
``` csharp
public long Copy(long ownerId, ulong photoId, string accessKey = null)
```

## Параметры
+ **ownerId** - Идентификатор владельца фотографии целое число, обязательный параметр
+ **photoId** - Индентификатор фотографии положительное число, обязательный параметр
+ **accessKey** - Специальный код доступа для приватных фотографий строка

## Результат
Возвращает идентификатор созданной фотографии.

## Пример
``` csharp
// Пример кода
```
