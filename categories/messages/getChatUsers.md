---
layout: default
title: Метод Messages.GetChatUsers
permalink: messages/getChatUsers/
comments: true
---
# Метод Messages.GetChatUsers
Позволяет получить список пользователей мультидиалога по его id.

Страница документации ВКонтакте [messages.getChatUsers](https://vk.com/dev/messages.getChatUsers).
## Синтаксис
``` csharp
public ReadOnlyCollection<User> GetChatUsers(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase)
```

## Параметры
+ **chatIds** - Идентификаторы бесед. список целых чисел, разделенных запятыми
+ **fields** - Список дополнительных полей профилей, которые необходимо вернуть. 
Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, counters, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список слов, разделенных через запятую
+ **nameCase** - Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка

## Результат
После успешного выполнения возвращает список идентификаторов участников беседы. 
Если был задан параметр fields, возвращает список объектов пользователей с дополнительным полем invited_by, содержащим идентификатор пользователя, пригласившего в беседу.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
