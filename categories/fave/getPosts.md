---
layout: default
title: Метод Fave.GetPosts
permalink: fave/getPosts/
comments: true
---
# Метод Fave.GetPosts
Возвращает записи, на которых текущий пользователь поставил отметку «Мне нравится».

Страница документации ВКонтакте [fave.getPosts](https://vk.com/dev/fave.getPosts).

## Синтаксис
``` csharp
public ReadOnlyCollection<Post> GetPosts(int? count = null, int? offset = null)
public WallGetObject GetPostsEx(int? count = null, int? offset = null)
```

## Параметры
+ **offset** — Смещение, необходимо для выборки определенного подмножества записей. По умолчанию — 0. положительное число
+ **count** — Количество записей, информацию о которых нужно вернуть (но не более 100). положительное число, по умолчанию 50
+ **extended** — 1 — будут возвращены три массива wall, profiles и groups. По умолчанию дополнительные поля не возвращаются. флаг, может принимать значения 1 или 0

## Результат
После успешного выполнения возвращает список объектов записей на стене.

## Пример
``` csharp
var getPosts = _api.Fave.GetPosts();
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 13:59:16
