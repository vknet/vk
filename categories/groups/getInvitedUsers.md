---
layout: default
title: Метод Groups.GetInvitedUsers
permalink: groups/getInvitedUsers/
comments: true
---
# Метод Groups.GetInvitedUsers
Возвращает список пользователей, которые были приглашены в группу.

Страница документации ВКонтакте [groups.getInvitedUsers](https://vk.com/dev/groups.getInvitedUsers).

## Синтаксис
``` csharp
public ReadOnlyCollection<User> GetInvitedUsers(long groupId, out int userCount, long? offset = null, long? count = null, UsersFields fields = null, NameCase nameCase = null)
```

## Параметры
+ **groupId** - Идентификатор группы, список приглашенных в которую пользователей нужно вернуть. положительное число, обязательный параметр
+ **offset** - Смещение, необходимое для выборки определённого подмножества пользователей. положительное число
+ **count** - Количество пользователей, информацию о которых нужно вернуть. положительное число, по умолчанию 20
+ **fields** - Список дополнительных полей, которые необходимо вернуть. 
Доступные значения: nickname, domain, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список строк, разделенных через запятую
+ **nameCase** - Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка

## Результат


## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
