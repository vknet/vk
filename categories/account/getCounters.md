---
layout: default
title: Метод Account.GetCounters
permalink: account/getCounters/
comments: true
---
# Метод Account.GetCounters
Возвращает ненулевые значения счетчиков пользователя.

Страница документации ВКонтакте [account.getCounters](https://vk.com/dev/account.getCounters).

Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token).

## Синтаксис
``` csharp
public Counters GetCounters(CountersFilter filter)
```

## Параметры
+ **filter** - Счетчики, информацию о которых нужно вернуть 
    - **Friends** — Новые заявки в друзья
    - **FriendsSuggestions** — Предлагаемые друзья
    - **Messages** — Новые сообщения
    - **Photos** — Новые отметки на фотографиях
    - **Videos** — Новые отметки на видеозаписях
    - **Gifts** — Подарки
    - **Events** — События
    - **Groups** — Сообщества
    - **Notifications** — Ответы
    - **Sdk** — Запросы в мобильных играх
    - **AppRequests** — Уведомления от приложений
    - **friends_recommendations** — Рекомендации друзей
    - **All** - Все фильтры

Передавать как список слов, разделенных через запятую.

## Результат
Возвращает объект, который может содержать поля 
+ **friends** - 
+ **messages** - 
+ **photos** - 
+ **videos** - 
+ **notes** - 
+ **gifts** - 
+ **events** - 
+ **groups** -
+ **notifications** - 
+ **sdk**
+ **app_requests**  
со значениями счетчиков (число).

## Пример
``` csharp
            var counters = _api.Account.GetCounters(CountersFilter.All);
            Console.WriteLine(counters.Groups.ToString());
            Console.ReadKey();
```

## Версия Вконтакте API v.5.110
Дата обновления: 19.06.2020 4:02
