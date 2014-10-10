---
layout: default
title: Метод Audio.GetLyrics
permalink: audio/getLyrics/
comments: true
---
# Метод Audio.GetLyrics
Возвращает текст аудиозаписи идентификатору текста аудиозаписи (Audio.LyricsId)

# Синтаксис
```csharp
public Lyrics GetLyrics(long lyricsId)
```

## Параметры
+ **id** - Идентификатор текста аудиозаписи.

## Результат
В случае успеха возвращает найденный текст адиозаписи. В качестве переводов строк в тексте используется \n.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.

## Пример
```csharp
// Получаем текст песни с id равным 2662381.
Lyrics lyrics = vk.Audio.GetLyrics(2662381);
```
