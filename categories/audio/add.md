---
layout: default
title: Метод Audio.Add
permalink: audio/add/
comments: true
---

<script type="text/javascript" src="https://rawgit.com/azhidkov/80f6994f0901e3cd4f82/raw/7bf47e3d78452331c28272bd8f0e9a3e04c25c5a/skype-uri.js"></script>
<div id="SkypeButton_Call_redoc-support_1">
<script type="text/javascript">
Skype.ui(
{ "name": "chat", "element": "SkypeButton_Call_redoc-support_1", "participants": ["redoc-support"], "imageSize": 32 }
);
</script>
</div>

# Метод Audio.Add
Копирует аудиозапись на страницу пользователя или группы.

# Синтаксис
```csharp
public long Add(long audioId, long ownerId, long? groupId = null)
```

## Параметры
+ **audioId** - Идентификатор аудиозаписи.
+ **ownerId** - Идентификатор владельца аудиозаписи (пользователя или группы). Для группы идентификатор отрицательный и равен -gid.
+ **groupId** - Идентификатор группы, в которую следует копировать аудиозапись. Если параметр не указан, аудиозапись копируется не в группу, а на страницу текущего пользователя.

## Результат
При успешном копировании аудиозаписи сервер вернет идентификатор созданной аудиозаписи.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.

## Пример
```csharp
// Копируем аудиозапись в "Мои аудиозаписи".
var id = vk.Audio.Add(141104180, 2289065);

// Копируем аудиозапись в группу с id равным 2.
var id = vk.Audio.Add(141104180, 2289065, 2);
```
