---
layout: default
title: Метод Messages.SearchDialogs
permalink: messages/searchDialogs/
comments: true
---
# Метод Messages.SearchDialogs
Возвращает список найденных диалогов текущего пользователя по введенной строке поиска.

Страница документации ВКонтакте [messages.searchDialogs](https://vk.com/dev/messages.searchDialogs).

## Синтаксис
``` csharp
public SearchDialogsResponse SearchDialogs(
	string query,
	ProfileFields fields = null,
	uint? limit = null
)
```

## Параметры
+ **query** — Подстрока, по которой будет производиться поиск. строка
+ **limit** — Положительное число, по умолчанию 20
+ **fields** — Список дополнительных полей профилей, которые необходимо вернуть. 
Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, counters, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список слов, разделенных через запятую

## Результат
В результате выполнения данного метода будет возвращён массив объектов, которые могут иметь тип: profile, chat и email 
Поле profiles содержит список объектов пользователей. 
Поле chats содержит список объектов бесед.

## Пример
``` csharp
var searchDialogs = _api.Messages.SearchDialogs();
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
