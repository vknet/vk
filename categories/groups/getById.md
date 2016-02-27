---
layout: default
title: Метод Groups.GetById
permalink: groups/getById/
comments: true
---
# Метод Groups.GetById
Возвращает информацию о заданном сообществе или о нескольких сообществах.

Страница документации ВКонтакте [groups.getById](https://vk.com/dev/groups.getById).

## Синтаксис
``` csharp
public ReadOnlyCollection<Group> GetById(IEnumerable<string> groupIds, string groupId, GroupsFields fields)
```

## Параметры
+ **groupIds** - Идентификаторы или короткие имена сообществ. Максимальное число идентификаторов — 500. список строк, разделенных через запятую
+ **groupId** - Идентификатор или короткое имя сообщества. строка
+ **fields** - Список дополнительных полей, которые необходимо вернуть. Возможные значения: city, country, place, description, wiki_page, members_count, counters, start_date, finish_date, can_post, can_see_all_posts, activity, status, contacts, links, fixed_post, verified, site,ban_info. 
Обратите внимание, для получения некоторых полей требуется право доступа groups. Подробнее см. описание полей объекта group список строк, разделенных через запятую

## Результат
После успешного выполнения возвращает массив объектов group.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.
+ **InvalidParamException** - Неправильный идентификатор группы.

## Пример
```csharp
// Получаем основную информацию о группе с id равным 2.
var groups = vk.Groups.GetById(2);

// Получаем всю информацию о группе с id равным 2.
var groups = vk.Groups.GetById(2, GroupsFields.All);

// Получаем основную информацию о трех группах
var gids = new long[] {1, 2, 3};
var groups = vk.Groups.GetById(gids);

// Получаем всю информацию о трех группах
var gids = new long[] {1, 2, 3};
var groups = vk.Groups.GetById(gids, GroupsFields.All);
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
