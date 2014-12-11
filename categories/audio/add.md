---
layout: default
title: Метод Audio.Add
permalink: audio/add/
comments: true
---

<script type="text/javascript" src="https://gist.githubusercontent.com/azhidkov/b4adcf3725721e0fd222/raw/aed2653e4c3bbd4c21edf929ac11fd84168e1541/gistfile1.txt"></script>
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
