---
layout: default
title: Метод Audio.Restore
permalink: audio/restore/
comments: true
---
# Метод Audio.Restore
Восстанавливает удаленную аудиозапись пользователя после удаления.

# Синтаксис
```csharp
public Audio Restore(long audioId, long? ownerId = null)
```

## Параметры
+ **audioId** - Id удаленной аудиозаписи.
+ **ownerId** - Id владельца аудиозаписи.

## Результат
В случае успешного восстановления аудиозаписи возвращает объект класса Audio. Если время хранения удаленной аудиозаписи истекло (обычно это 20 минут), сервер вернет ошибку 202 (Cache expired).

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.
+ **InvalidParamException** - нусуществующий audioId или ownerId.

## Пример
```csharp
// Восстановить только что удаленную запись из раздела "Мои аудиозаписи".
Audio a = vk.Audio.Restore(159209928);

// Восстановить только что удаленную запись из группы с id равным 2.
Audio a = vk.Audio.Restore(159209928, 2);
```
