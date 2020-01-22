---
layout: default
title: Метод Friends.GetRecent
permalink: friends/getRecent/
comments: true
---
# Метод Friends.GetRecent
Возвращает список идентификаторов недавно добавленных друзей текущего пользователя

Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token). Требуются [права доступа](https://vk.com/dev/permissions): **friends**.

Страница документации ВКонтакте [friends.getRecent](https://vk.com/dev/friends.getRecent).

## Синтаксис
``` csharp
public ReadOnlyCollection<long> GetRecent(long? count = null)
```

## Параметры
+ **count** — максимальное количество недавно добавленных друзей, которое необходимо получить. Положительное число, по умолчанию *100*, максимальное значение *1000*.

## Результат
После успешного выполнения возвращает отсортированный в антихронологическом порядке список идентификаторов (**id**) недавно добавленных друзей текущего пользователя.

## Исключения
+ В ходе выполнения могут произойти общие ошибки. Их описание находится на [отдельной странице](https://vk.com/dev/errors).

## Пример
``` csharp
var getRecent = api.Friends.GetRecent(20);

foreach(var item in getRecent)
{
    //logic
}
```

## Версия Вконтакте API v.5.103
Дата обновления: 17.01.2020 16:40.
