---
layout: default
title: Метод Photos.GetAlbumsCount
permalink: photos/getAlbumsCount/
comments: true
---
# Метод Photos.GetAlbumsCount
Возвращает количество доступных альбомов пользователя или сообщества.

Страница документации ВКонтакте [photos.getAlbumsCount](https://vk.com/dev/photos.getAlbumsCount).
## Синтаксис
``` csharp
public int GetAlbumsCount(long? userId, long? groupId)
```

## Параметры
+ **userId** - Идентификатор пользователя, количество альбомов которого необходимо получить. целое число, по умолчанию идентификатор текущего пользователя
+ **groupId** - Идентификатор сообщества, количество альбомов которого необходимо получить. целое число

## Результат
После успешного выполнения возвращает количество альбомов  с учетом настроек приватности.

## Пример
``` csharp
// Пример кода
```
