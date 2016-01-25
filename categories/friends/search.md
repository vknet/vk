---
layout: default
title: Метод Friends.Search
permalink: friends/search/
comments: true
---
# Метод Friends.Search
Позволяет искать по списку друзей пользователей.

Страница документации ВКонтакте [friends.search](https://vk.com/dev/friends.search).
## Синтаксис
``` csharp
public ReadOnlyCollection<User> Search(FriendsSearchParams @params)
```

## Параметры
Класс **`FriendsSearchParams`** содержит следующие свойства:

+ **UserId** - Идентификатор пользователя, по списку друзей которого необходимо произвести поиск. положительное число, по умолчанию идентификатор текущего пользователя, обязательный параметр
+ **Query** - Строка запроса. строка
+ **Fields** - Список дополнительных полей, которые необходимо вернуть. 
Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities, domain список строк, разделенных через запятую
+ **NameCase** - Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка, по умолчанию Nom
+ **Offset** - Смещение, необходимое для выборки определенного подмножества друзей. положительное число
+ **Count** - Количество друзей, которое нужно вернуть. положительное число, по умолчанию 20, максимальное значение 1000

## Результат
После успешного выполнения метод  возвращает список объектов пользователей.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 13:09:06
