---
layout: default
title: Метод Apps.Get
permalink: apps/get/
comments: true
---
# Метод Apps.Get
Возвращает данные о запрошенном приложении на платформе ВКонтакте

Страница документации ВКонтакте [apps.get](https://vk.com/dev/apps.get).

## Синтаксис
``` csharp
public ReadOnlyCollection<App> Get(out long totalCount, AppGetParams @params)
```

## Параметры
+**totalCount** - Количество приложений.

Класс **`AppsGetParams`** содержит следующие свойства:

+ **AppId** - Идентификатор приложения, данные которого необходимо получить положительное число
+ **AppIds** - Список идентификаторов приложений, данные которых необходимо получить список слов, разделенных через запятую, количество элементов должно составлять не более 100
+ **Platform** - Платформа, для которой необходимо вернуть platform_id, принимает значения: ios, android, winphone, web. строка, по умолчанию web
+ **Extended** - Позволяет получить дополнительные поля: screenshots. По умолчанию возвращает только основные поля приложений. флаг, может принимать значения 1 или 0, по умолчанию 0
+ **ReturnFriends** - 1 – возвращает список друзей, установивших приложение. (Данный параметр работает только, если пользователь передал валидный access_token) 0 – не возвращать список друзей, по умолчанию. флаг, может принимать значения 1 или 0, по умолчанию 0
+ **Fields** - (работает при использовании return_friends) список дополнительных полей, которые необходимо вернуть для профилей пользователей. 
Доступные значения: sex, bdate, city, country, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, online_mobile, lists, domain, has_mobile, contacts, connections, site, education, universities, schools, can_post, can_see_all_posts, can_see_audio, can_write_private_message, status, last_seen, common_count, relation, relatives, counters,screen_name,timezone список слов, разделенных через запятую
+ **NameCase** - (работает при использовании return_friends) падеж для склонения имени и фамилии пользователей. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка

## Результат
После успешного выполнения возвращает объект приложения.

## Пример
``` csharp
var get = _api.Apps.Get(new AppsGetParams{
	
});
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:30:11
