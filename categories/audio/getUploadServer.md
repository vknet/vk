---
layout: default
title: Метод Audio.GetUploadServer
permalink: audio/getUploadServer/
comments: true
---
# Метод Audio.GetUploadServer
Возвращает адрес сервера для загрузки аудиозаписей.

Страница документации ВКонтакте [audio.getUploadServer](https://vk.com/dev/audio.getUploadServer).

## Синтаксис
``` csharp
public Uri GetUploadServer()
```

## Параметры
Данный метод не имеет входных параметров.

## Результат
После успешного выполнения возвращает объект с единственным полем upload_url.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.

## Пример
```csharp
// Получаем url для загрузки.
string url = vk.Audio.GetUploadServer();
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 19:20:10
