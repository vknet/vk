---
layout: default
title: Метод Users.Get
permalink: users/get/
comments: true
---
# Метод Users.Get
Возвращает расширенную информацию о пользователях.

Страница документации ВКонтакте [users.get](https://vk.com/dev/users.get).
## Синтаксис
``` csharp
public ReadOnlyCollection<Group> Get(IEnumerable<string> userIds, IEnumerable<string> fields, string nameCase)
```

## Параметры
+ **UserIds** - Перечисленные через запятую идентификаторы пользователей или их короткие имена (screen_name). По умолчанию — идентификатор текущего пользователя. список строк, разделенных через запятую, количество элементов должно составлять не более 1000
+ **Fields** - Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание. 
/// Доступные значения: photo_id, verified, sex, bdate, city, country, home_town, has_photo, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, lists, domain, has_mobile, contacts, site, education, universities, schools, status, last_seen, followers_count, common_count, occupation, nickname, relatives, relation, personal, connections, exports, wall_comments, activities, interests, music, movies, tv, books, games, about, quotes, can_post, can_see_all_posts, can_see_audio, can_write_private_message, can_send_friend_request, is_favorite, is_hidden_from_feed, timezone, screen_name, maiden_name, crop_photo, is_friend, friend_status, career, military, blacklisted, blacklisted_by_me. список строк, разделенных через запятую
+ **NameCase** - Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка

## Результат
После успешного выполнения возвращает массив объектов user.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.

## Пример
```csharp
// Получаем базовую информацию о Павле Дурове.
var p = vk.Users.Get(1);
Console.WriteLine(p.Uid);        // 1
Console.WriteLine(p.FirstName); // "Павел"
Console.WriteLine(p.LastName); // "Дуров"

// Получаем информацию о счетчиках различных объектов у пользователя
var p = users.Get(1, ProfileFields.Counters);
Console.WriteLine(p.Uid);                      // 1
Console.WriteLine(p.FirstName,);           // "Павел"
Console.WriteLine(p.LastName);            // "Дуров"
Console.WriteLine(p.Counters.Albums);  // 3
Console.WriteLine(p.Counters.Videos);   // 183
Console.WriteLine(p.Counters.Audios);   // 78
Console.WriteLinet(p.Counters.Notes);   // 5
Console.WriteLine(p.Counters.Photos);   // 783
Console.WriteLine(p.Counters.Groups);  // 24
Console.WriteLine(p.Counters.Friends);  // 641
...

// Получаем базовую информацию о трех пользователях.
var ids = new long[] {2, 3, 6};
var users = vk.Users.Get(ids);
foreach(var p in users)
{
   ....
}

// Получаем информацию о высшем образовании трех пользователей.
var ids = new long[] {2, 3, 6};
var users = vk.Users.Get(ids, ProfileFields.Education);
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 12:44:46
