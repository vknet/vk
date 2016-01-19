---
layout: default
title: Метод Users.GetNearby
permalink: users/getNearby/
comments: true
---
# Метод Users.GetNearby
Индексирует текущее местоположение пользователя и возвращает список пользователей, которые находятся вблизи.

Страница документации ВКонтакте [users.getNearby](https://vk.com/dev/users.getNearby).
## Синтаксис
``` csharp
public ReadOnlyCollection<User> GetNearby(UsersGetNearbyParams @params)
```

## Параметры
Класс **`UsersGetNearbyParams`** содержит следующие свойства:

+ **Latitude** - Географическая широта точки, в которой в данный момент находится пользователь, заданная в градусах (от -90 до 90). дробное число, обязательный параметр
+ **Longitude** - Географическая долгота точки, в которой в данный момент находится пользователь, заданная в градусах (от -180 до 180). дробное число, обязательный параметр
+ **Accuracy** - Точность текущего местоположения пользователя в метрах. положительное число
+ **Timeout** - Время в секундах через которое пользователь должен перестать находиться через поиск по местоположению. положительное число, по умолчанию 7200
+ **Radius** - Тип радиуса зоны поиска (от 1 до 4) 
1 — 300 метров; 
2 — 2400 метров; 
3 — 18 километров; 
4 — 150 километров. 
положительное число, по умолчанию 1
+ **Fields** - Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание. 
Доступные значения: photo_id, verified, sex, bdate, city, country, home_town, has_photo, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, lists, domain, has_mobile, contacts, site, education, universities, schools, status, last_seen, followers_count, common_count, occupation, nickname, relatives, relation, personal, connections, exports, wall_comments, activities, interests, music, movies, tv, books, games, about, quotes, can_post, can_see_all_posts, can_see_audio, can_write_private_message, can_send_friend_request, is_favorite, is_hidden_from_feed, timezone, screen_name, maiden_name, crop_photo, is_friend, friend_status, career, military, blacklisted, blacklisted_by_me. список строк, разделенных через запятую
+ **NameCase** - Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка

## Результат
После успешного выполнения возвращает список объектов user.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 12:44:46
