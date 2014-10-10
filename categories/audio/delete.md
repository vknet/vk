---
layout: default
title: Метод Audio.Delete
permalink: audio/delete/
comments: true
---
# Метод Audio.Delete
Удаляет аудиозапись со страницы пользователя или группы.

# Синтаксис
```csharp
public bool Delete(long audioId, long ownerId)
```

## Параметры
+ **audioId** - Id аудиозаписи.
+ **ownerId** - Id владельца аудиозаписи.

## Результат
При успешном удалении аудиозаписи сервер вернет true.

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
