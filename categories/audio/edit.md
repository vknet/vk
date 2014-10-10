---
layout: default
title: Метод Audio.Edit
permalink: audio/edit/
comments: true
---
# Метод Audio.Edit
Редактирует данные аудиозаписи на странице пользователя или группы.

# Синтаксис
```csharp
public long Edit(long audioId, long ownerId, string artist, string title, string text, bool noSearch = false)
```

## Параметры
+ **audioId** - Id аудиозаписи.
+ **ownerId** - Id владельца аудиозаписи. Если редактируемая аудиозапись находится на странице группы, в этом параметре должно стоять значение, равное -id группы.
+ **artist** - Название исполнителя аудиозаписи.
+ **title** - Название аудиозаписи.
+ **text** - Текст аудиозаписи, если введен.
+ **noSearch** - true - скрывает аудиозапись из поиска по аудиозаписям, false (по умолчанию) - не скрывает.

## Результат
При успешном редактировании аудиозаписи сервер вернет id текста, введенного пользователем (lyrics_id).

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.
+ **InvalidParamException** - artist, title или text равен значению null.

## Пример
```csharp
// Редактируем запись.
long lyricsId = vk.Audio.Edit(159207130, 4793858, "Test Artist", "Test Title", "Test Text");
```
