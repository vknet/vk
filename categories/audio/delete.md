---
layout: default
title: Метод Audio.Delete
permalink: audio/delete/
comments: true
---
# Метод Audio.Delete
Удаляет аудиозапись со страницы пользователя или сообщества.

Страница документации ВКонтакте [audio.delete](https://vk.com/dev/audio.delete).

## Синтаксис
``` csharp
public bool Delete(long audioId, long ownerId)
```

## Параметры
+ **audioId** - Идентификатор аудиозаписи. положительное число, обязательный параметр
+ **ownerId** - Идентификатор владельца аудиозаписи (пользователь или сообщество). целое число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.

## Пример
```csharp
// Удаляем аудиозапись из "Мои аудиозаписи".
long userId = vk.UserId;
bool result = vk.Audio.Delete(159203048, userId);

// Удаляем аудиозапись из группы с id равным 2.
bool result = vk.Audio.Delete(159203048, -2);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 19:20:10
