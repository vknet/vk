---
layout: default
title: Метод Groups.Create
permalink: groups/create/
comments: true
---
# Метод Groups.Create
Создает новое сообщество.

Страница документации ВКонтакте [groups.create](https://vk.com/dev/groups.create).

## Синтаксис
``` csharp
public Group Create(string title, string description, GroupType type, GroupSubType? subtype)
```

## Параметры
+ **title** — Название сообщества. строка, обязательный параметр
+ **description** — Описание сообщества, (не учитывается при type=public). строка
+ **type** — Тип создаваемого сообщества: 

group — группа; 
event — мероприятие; 
public — публичная страница. 
строка, по умолчанию group
+ **subtype** — Вид публичной страницы (только при type=public): 

1 — место или небольшая компания; 
2 — компания, организация или веб-сайт; 
3 — известная личность или коллектив; 
4 — произведение или продукция. 
положительное число

## Результат
Возвращает идентификатор созданного сообщества.

## Пример
``` csharp
var create = _api.Groups.Create(title: "title");
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
