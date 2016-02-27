---
layout: default
title: Метод Friends.GetAvailableForCall
permalink: friends/getAvailableForCall/
comments: true
---
# Метод Friends.GetAvailableForCall
Позволяет получить список идентификаторов пользователей, доступных для вызова в приложении, используя метод JSAPI callUser. 
Подробнее о схеме вызова из приложений.

Страница документации ВКонтакте [friends.getAvailableForCall](https://vk.com/dev/friends.getAvailableForCall).

## Синтаксис
``` csharp
public ReadOnlyCollection<User> GetAvailableForCall(ProfileFields fields, NameCase nameCase)
```

## Параметры
+ **fields** - Список дополнительных полей, которые необходимо вернуть. 
Доступные значения: nickname, domain, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список строк, разделенных через запятую
+ **nameCase** - Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка, по умолчанию Nom

## Результат
После успешного выполнения возвращает список идентификаторов (id) друзей пользователя, доступных для вызова, если параметр fields не использовался. 
При использовании параметра fields  возвращает список объектов пользователей.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 13:09:06
