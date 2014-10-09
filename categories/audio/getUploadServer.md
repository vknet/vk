---
layout: default
title: Метод Audio.GetUploadServer
permalink: audio/getUploadServer/
comments: true
---
# Метод Audio.GetUploadServer
Возвращает адрес сервера для загрузки аудиозаписей.

# Синтаксис
```csharp

```

## Параметры
Данный метод не имеет входных параметров.

## Результат
В случае успеха возвращает адрес сервера для загрузки аудиозаписей.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.

## Пример
```csharp
// Получаем url для загрузки.
string url = vk.Audio.GetUploadServer();
```
