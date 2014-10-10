---
layout: default
title: Метод Audio.Get
permalink: audio/get/
comments: true
---
# Метод Audio.Get
Возвращает список аудиозаписей пользователя и краткую информацию о нем.

# Синтаксис
```csharp
public ReadOnlyCollection<Audio> Get(long uid, out User user, long? albumId = null, IEnumerable<long> aids = null, int? count = null, int? offset = null)

 public ReadOnlyCollection<Audio> Get(long uid, long? albumId = null, IEnumerable<long> aids = null, int? count = null, int? offset = null)
```

## Параметры
+ **uid** - Идентификатор пользователя, у которого необходимо получить аудиозаписи.
+ **user** - Базовая информация о владельце аудиозаписей - пользователе с идентификатором uid (идентификатор, имя, фотография).
+ **albumId** - Идентификатор альбома пользователя, аудиозаписи которого необходимо получить (по умолчанию возвращаются аудиозаписи из всех альбомов).
+ **aids** - Список идентификаторов аудиозаписей пользователя, по которым необходимо получить информацию.
+ **count** - Требуемое количество аудиозаписей.
+ **offset** - Смещение относительно первой найденной аудиозаписи (для выборки определенного подмножества).

## Результат
В случае успеха возвращает затребованный список аудиозаписей пользователя.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.

## Пример
```csharp
// Получаем список аудиозаписей Павла Дурова и краткую информацию о нем.
Profile user;
var audios = vk.Audio.Get(1, out user);

// Получаем три аудиозаписи Павла Дурова, начиная с пятой.
Profile user;
var audios = vk.Audio.Get(1, out user, null, null, 3, 5);

// Получаем только идентификаторы аудиозаписей Павла Дурова.
Profile user;
var ids = vk.Audio.Get(1, out user).Select(x => x.Id).ToList();
```
