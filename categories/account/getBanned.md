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
public IEnumerable<User> GetBanned(out int total, int? offset = null, int? count = null)
```

## Параметры
+ **offset** - Смещение необходимое для выборки определенного подмножества черного списка. положительное число
+ **count** - Количество записей, которое необходимо вернуть. положительное число, по умолчанию 20, максимальное значение 200

## Результат
Возвращает набор объектов пользователей, находящихся в черном списке.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.45
Дата обновления: 10.02.2016 13:55:10
