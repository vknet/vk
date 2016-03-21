---
layout: default
title: Метод Newsfeed.DeleteBan
permalink: newsfeed/deleteBan/
comments: true
---
# Метод Newsfeed.DeleteBan
Разрешает показывать новости от заданных пользователей и групп в ленте новостей текущего пользователя.

Страница документации ВКонтакте [newsfeed.deleteBan](https://vk.com/dev/newsfeed.deleteBan).

## Синтаксис
``` csharp
public bool DeleteBan(IEnumerable<long> userIds, IEnumerable<long> groupIds)
```

## Параметры
+ **userIds** - Идентификаторы пользователей, новости от которых необходимо вернуть в ленту. список положительных чисел, разделенных запятыми
+ **groupIds** - Идентификаторы сообществ, новости от которых необходимо вернуть в ленту. список положительных чисел, разделенных запятыми

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var deleteBan = _api.Newsfeed.DeleteBan();
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 13:09:42
