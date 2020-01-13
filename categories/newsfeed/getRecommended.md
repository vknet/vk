---
layout: default
title: Метод Newsfeed.GetRecommended
permalink: newsfeed/getRecommended/
comments: true
---
# Метод Newsfeed.GetRecommended
Получает список новостей, рекомендованных пользователю.

Страница документации ВКонтакте [newsfeed.getRecommended](https://vk.com/dev/newsfeed.getRecommended).

## Синтаксис
``` csharp
public NewsFeed GetRecommended(NewsFeedGetRecommendedParams @params)
```

## Параметры
Класс **`NewsfeedGetRecommendedParams`** содержит следующие свойства:

+ **StartTime** — Время в формате unixtime, начиная с которого следует получить новости для текущего пользователя. Если параметр не задан, то он считается равным значению времени, которое было сутки назад. положительное число
+ **EndTime** — Время в формате unixtime, до которого следует получить новости для текущего пользователя. Если параметр не задан, то он считается равным текущему времени. положительное число
+ **MaxPhotos** — Максимальное количество фотографий, информацию о которых необходимо вернуть. По умолчанию 5. положительное число
+ **StartFrom** — Идентификатор, необходимый для получения следующей страницы результатов. Значение, необходимое для передачи в этом параметре, возвращается в поле ответа next_from. строка, доступен начиная с версии 5.13
+ **Count** — Указывает, какое максимальное число новостей следует возвращать, но не более 100. По умолчанию 50. положительное число
+ **Fields** — Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание. 
Доступные значения: sex, bdate, city, country, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, online_mobile, domain, has_mobile, contacts, connections, site, education, universities, schools, can_post, can_see_all_posts, can_see_audio, can_write_private_message, status, last_seen, common_count, relation, relatives, counters, screen_name, maiden_name, timezone, occupation,activities, interests, music, movies, tv, books, games, about, quotes список слов, разделенных через запятую

## Результат
После успешного выполнения возвращает объект, содержащий следующие поля: 

+ **items** — массив новостей для текущего пользователя; 
+ **profiles** — информация о пользователях, которые находятся в списке новостей; 
+ **groups** — информация о группах, которые находятся в списке новостей; 
+ **new_offset** — содержит offset, который необходимо передать, для того, чтобы получить следующую часть новостей; 
+ **new_from** — содержит from, который необходимо передать, для того, чтобы получить следующую часть новостей. Позволяет избавиться от дубликатов, которые могут возникнуть при появлении новых новостей между вызовами этого метода. 

## Пример
``` csharp
var getRecommended = _api.Newsfeed.GetRecommended(new NewsfeedGetRecommendedParams{
	
});
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 13:09:42
