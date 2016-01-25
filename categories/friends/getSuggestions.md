---
layout: default
title: Метод Friends.GetSuggestions
permalink: friends/getSuggestions/
comments: true
---
# Метод Friends.GetSuggestions
Возвращает список профилей пользователей, которые могут быть друзьями текущего пользователя.

Страница документации ВКонтакте [friends.getSuggestions](https://vk.com/dev/friends.getSuggestions).
## Синтаксис
``` csharp
public ReadOnlyCollection<User> GetSuggestions(FriendsFilter filter = null, long? count = null, long? offset = null, UsersFields fields = null, NameCase nameCase = null)
```

## Параметры
+ **filter** - Типы предлагаемых друзей, которые нужно вернуть, перечисленные через запятую. 
Может принимать следующие значения: 
mutual — пользователи, с которыми много общих друзей; 
contacts — пользователи, найденные с помощью метода account.importContacts; 
mutual_contacts — пользователи, которые импортировали те же контакты, что и текущий пользователь, используя метод account.importContacts;
По умолчанию будут возвращены все возможные друзья. список строк, разделенных через запятую
+ **count** - Количество рекомендаций, которое необходимо вернуть. положительное число, максимальное значение 500, по умолчанию 500
+ **offset** - Смещение, необходимое для выбора определённого подмножества списка. положительное число
+ **fields** - Список дополнительных полей, которые необходимо вернуть. 
Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, counters, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список строк, разделенных через запятую
+ **nameCase** - Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка

## Результат
После успешного выполнения возвращает список объектов пользователей с дополнительным полем found_with для пользователей, найденных через импорт контактов. Для некоторых пользователей, которые были найдены давно поле found_with может отсутствовать.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 13:09:06
