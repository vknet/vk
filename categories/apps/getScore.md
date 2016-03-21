---
layout: default
title: Метод Apps.GetScore
permalink: apps/getScore/
comments: true
---
# Метод Apps.GetScore
Метод возвращает количество очков пользователя в этой игре.

Страница документации ВКонтакте [apps.getScore](https://vk.com/dev/apps.getScore).

## Синтаксис
``` csharp
public long GetScore(long userId)
```

## Параметры
+ **userId** - Идентификатор пользователя. положительное число, по умолчанию идентификатор текущего пользователя, обязательный параметр

## Результат
После успешного выполнения возвращает число очков для пользователя.

## Пример
``` csharp
var getScore = _api.Apps.GetScore(userId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:30:11
