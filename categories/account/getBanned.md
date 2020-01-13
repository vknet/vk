---
layout: default
title: Метод Account.GetBanned
permalink: account/getBanned/
comments: true
---
# Метод Account.GetBanned
Возвращает список пользователей, находящихся в черном списке.

Страница документации ВКонтакте [account.getBanned](https://vk.com/dev/account.getBanned).

## Синтаксис
``` csharp
public ReadOnlyCollection<User> GetBanned(out int total, int? offset = null, int? count = null)
```

## Параметры
+ **offset** — Смещение необходимое для выборки определенного подмножества черного списка. положительное число
+ **count** — Количество записей, которое необходимо вернуть. положительное число, по умолчанию 20, максимальное значение 200

## Результат
Возвращает набор объектов пользователей, находящихся в черном списке.

## Пример
``` csharp
var bannedUsers = _api.Account.GetBanned(0, 1);
Console.WriteLine(bannedUsers.Count.ToString());
foreach (var item in bannedUsers)
{ 
Console.WriteLine(item.FirstName + " " + item.LastName); 
}
Console.ReadKey();
```

## Версия Вконтакте API v.5.92
Дата обновления: 06.12.2018 22:33:10
