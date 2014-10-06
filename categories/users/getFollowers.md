---
layout: default
title: Метод Users.Followers
permalink: users/getFollowers/
comments: true
---
# Метод Users.Followers
Возвращает список идентификаторов пользователей, которые являются подписчиками пользователя.

## Синтаксис
```csharp
public ReadOnlyCollection<User> GetFollowers(long? userId = null, int? count = null, int? offset = null, ProfileFields fields, NameCase nameCase)
```

## Параметры
+ **userId** - Идентификатор пользователя.
+ **count** - Количество подписчиков, информацию о которых нужно получить.
+ **offset** - Смещение, необходимое для выборки определенного подмножества подписчиков.
+ **fields** - Список дополнительных полей, которые необходимо вернуть.
+ **nameCase** - Падеж для склонения имени и фамилии пользователя.

## Результат
Список подписчиков

## Исключения

## Пример
```csharp
// TODO: 
```
