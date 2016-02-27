---
layout: default
title: Метод Users.GetFollowers
permalink: users/getFollowers/
comments: true
---
# Метод Users.GetFollowers
Возвращает список идентификаторов пользователей, которые являются подписчиками пользователя.

Страница документации ВКонтакте [users.getFollowers](https://vk.com/dev/users.getFollowers).

## Синтаксис
``` csharp
public ReadOnlyCollection<User> GetFollowers(long? userId = null, int? count = null, int? offset = null, ProfileFields fields = null, NameCase nameCase = null)
```

## Параметры
+ **userId** - Идентификатор пользователя. положительное число, по умолчанию идентификатор текущего пользователя
+ **offset** - Смещение, необходимое для выборки определенного подмножества подписчиков. положительное число
+ **count** - Количество подписчиков, информацию о которых нужно получить. положительное число, по умолчанию 100, максимальное значение 1000
+ **fields** - Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание. 
Доступные значения: photo_id, verified, sex, bdate, city, country, home_town, has_photo, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, lists, domain, has_mobile, contacts, site, education, universities, schools, status, last_seen, followers_count, common_count, occupation, nickname, relatives, relation, personal, connections, exports, wall_comments, activities, interests, music, movies, tv, books, games, about, quotes, can_post, can_see_all_posts, can_see_audio, can_write_private_message, can_send_friend_request, is_favorite, is_hidden_from_feed, timezone, screen_name, maiden_name, crop_photo, is_friend, friend_status, career, military, blacklisted, blacklisted_by_me. список строк, разделенных через запятую
+ **nameCase** - Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка

## Результат
После успешного выполнения возвращает список объектов user, — пользователей, которые являются подписчиками пользователя uid. 
Идентификаторы пользователей в списке отсортированы в порядке убывания времени их добавления.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 12:44:46
