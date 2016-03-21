---
layout: default
title: Метод Groups.GetBanned
permalink: groups/getBanned/
comments: true
---
# Метод Groups.GetBanned
Возвращает список забаненных пользователей в сообществе.

Страница документации ВКонтакте [groups.getBanned](https://vk.com/dev/groups.getBanned).

## Синтаксис
``` csharp
public ReadOnlyCollection<User> GetBanned(long groupId, long? offset = null, long? count = null, GroupsFields fields = null, long? userId = null)
```

## Параметры
+ **groupId** - Идентификатор сообщества. положительное число, обязательный параметр
+ **offset** - Смещение, необходимое для выборки определенного подмножества черного списка. положительное число
+ **count** - Количество пользователей, которое необходимо вернуть. положительное число, по умолчанию 20, максимальное значение 200
+ **fields** - Список дополнительных полей, которые необходимо вернуть. 
Доступные значения: sex, bdate, city, country, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, online_mobile, lists, domain, has_mobile, contacts, connections, site, education, universities, schools, can_post, can_see_all_posts, can_see_audio, can_write_private_message, status, last_seen, common_count, relation, relatives, counters список строк, разделенных через запятую
+ **userId** - Идентификатор пользователя, который можно передать для получения статуса бана отдельного пользователя. положительное число

## Результат
После успешного выполнения возвращает список объектов user с дополнительным полем ban_info. 
Объект ban_info — информация о внесении в черный список сообщества.  
admin_id идентификатор администратора, который добавил пользователя в черный список. 
 положительное число date дата добавления пользователя в черный список в формате Unixtime. 
 положительное число reason причина добавления пользователя в черный список. Возможные значения: 

0 — другое (по умолчанию); 
1 — спам; 
2 — оскорбление участников; 
3 — нецензурные выражения; 
4 — сообщения не по теме. 

 int (числовое значение) comment текст комментария. 
 строка end_date дата окончания блокировки (0 — блокировка вечная). 
 int (числовое значение)

## Пример
``` csharp
var getBanned = _api.Groups.GetBanned(groupId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
