---
layout: default
title: Метод Messages.GetChat
permalink: messages/getChat/
comments: true
---
# Метод Messages.GetChat
Возвращает информацию о беседе.

Страница документации ВКонтакте [messages.getChat](https://vk.com/dev/messages.getChat).

## Синтаксис
``` csharp
public ReadOnlyCollection<Chat> GetChat(
	IEnumerable<long> chatIds,
	ProfileFields fields = null,
	NameCase nameCase = null
)
```

## Параметры
+ **chatIds** — Список идентификаторов бесед. список целых чисел, разделенных запятыми
+ **fields** — Список дополнительных полей профилей, которые необходимо вернуть. 
Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, counters, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список слов, разделенных через запятую
+ **nameCase** — Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка

## Результат
После успешного выполнения возвращает объект (или список объектов) мультидиалога. 
Если был задан параметр fields, поле users содержит список объектов пользователей с дополнительным полем invited_by, содержащим идентификатор пользователя, пригласившего в беседу.

## Пример
``` csharp
var getChat = _api.Messages.GetChat();
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
