---
layout: default
title: Метод Newsfeed.GetBanned
permalink: newsfeed/getBanned/
comments: true
---
# Метод Newsfeed.GetBanned
Возвращает список пользователей и групп, которые текущий пользователь скрыл из ленты новостей.

Страница документации ВКонтакте [newsfeed.getBanned](https://vk.com/dev/newsfeed.getBanned).
## Синтаксис
``` csharp
public NewsBannedList GetBanned()
public NewsBannedExList GetBannedEx(UsersFields fields = null, NameCase nameCase = null)
```

## Параметры
+ **fields** - Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание. 
Доступные значения: sex, bdate, city, country, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, online_mobile, domain, has_mobile, contacts, connections, site, education, universities, schools, can_post, can_see_all_posts, can_see_audio, can_write_private_message, status, last_seen, common_count, relation, relatives, counters, screen_name, maiden_name, timezone, occupation,activities, interests, music, movies, tv, books, games, about, quotes список слов, разделенных через запятую
+ **nameCase** - Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка

## Результат
В случае успеха возвращает объект, в котором содержатся поля groups и members или profiles, в зависимости от параметра extended. 

В поле groups содержится массив идентификаторов сообществ, которые пользователь скрыл из ленты новостей. 
В поле members содержится массив идентификаторов друзей, которые пользователь скрыл из ленты новостей (возвращается, если extended = 0). 
В поле profiles содержится массив объектов с информациией о друзьях, которых пользователь скрыл из ленты новостей (возвращается, если extended = 1).

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 13:09:42
