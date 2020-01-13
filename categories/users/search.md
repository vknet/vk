---
layout: default
title: Метод Users.Search
permalink: users/search/
comments: true
---
# Метод Users.Search
Возвращает список пользователей в соответствии с заданным критерием поиска.

Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token). 

Страница документации ВКонтакте [users.search](https://vk.com/dev/users.search).

## Синтаксис
``` csharp
public ReadOnlyCollection<User> Search(out int itemsCount, UserSearchParams @params)
```

## Параметры
Класс **`UsersSearchParams`** содержит следующие свойства:

+ **q** — строка поискового запроса. Например, Вася Бабич. 
+ **sort** — сортировка результатов. Возможные значения: *1* — по дате регистрации, *0* — по популярности.
+ **offset** — смещение относительно первого найденного пользователя для выборки определенного подмножества. 
+ **count** — количество возвращаемых пользователей. Обратите внимание — даже при использовании параметра offset для получения информации доступны только первые 1000 результатов. положительное число, по умолчанию 20, максимальное значение 1000.
+ **fields** — список дополнительных полей профилей, которые необходимо вернуть. См. [подробное описание](https://vk.com/dev/objects/user). Доступные значения: *photo_id*, *verified, *sex*, *bdate*, *city*, *country*, *home_town*, *has_photo*, *photo_50*, *photo_100*, *photo_200_orig*, *photo_200*, *photo_400_orig*, *photo_max*, *photo_max_orig*, *online*, *lists*, *domain*, *has_mobile*, *contacts*, *site*, *education*, *universities*, *schools*, *status*, *last_seen*, *followers_count*, *common_count*, *occupation*, *nickname*, *relatives*, *relation*, *personal*, *connections*, *exports*, *wall_comments*, activities, *interests*, *music*, *movies*, *tv*, *books*, *games*, *about*, *quotes*, *can_post*, *can_see_all_posts*, *can_see_audio*, *can_write_private_message*, *can_send_friend_request*, *is_favorite*, *is_hidden_from_feed*, *timezone*, *screen_name*, *maiden_name*, *crop_photo*, *is_friend*, *friend_status*, *career*, *military*, *blacklisted*, *blacklisted_by_me*.
+ **city** — идентификатор города.
+ **country** — идентификатор страны.
+ **hometown** — название города строкой. 
+ **university_country** — идентификатор страны, в которой пользователи закончили ВУЗ.
+ **university** — идентификатор ВУЗа. 
+ **university_year** — год окончания ВУЗа.
+ **university_faculty** — идентификатор факультета. 
+ **university_chair** — идентификатор кафедры. 
+ **sex** — пол. Возможные значения: *1* — женщина, *2* — мужчина, *0* — любой (по умолчанию).
+ **status** — семейное положение. Возможные значения: *1* — не женат (не замужем), *2* — встречается, *3* — помолвлен(-а), *4* — женат (замужем), *5* — всё сложно, *6* — в активном поиске, *7* — влюблен(-а), *8* — в гражданском браке.
+ **age_from** — возраст, от. 
+ **age_to** — возраст, до. 
+ **birth_day** — день рождения. 
+ **birth_month** — месяц рождения. 
+ **birth_year** — год рождения. Минимальное значение 1900, максимальное значение 2100.
+ **online** — учитывать ли статус «онлайн». Возможные значения: *1* — искать только пользователей онлайн, *0* — искать по всем пользователям.
+ **has_photo** — учитывать ли наличие фото. Возможные значения: *1* — искать только пользователей с фотографией, *0* — искать по всем пользователям.
+ **school_count** — ryидентификатор страны, в которой пользователи закончили школу. 
+ **school_city** — идентификатор города, в котором пользователи закончили школу. 
+ **school_class** — буква класса. 
+ **school** — идентификатор школы, которую закончили пользователи. 
+ **school_year** — год окончания школы. 
+ **religion** — религиозные взгляды. 
+ **company** — название компании, в которой работают пользователи. 
+ **position** — название должности. 
+ **group_id** — идентификатор группы, среди пользователей которой необходимо проводить поиск. 
+ **from_list** Разделы среди которых нужно осуществить поиск, перечисленные через запятую. Возможные значения: *friends* — искать среди друзей, *subscriptions* — искать среди друзей и подписок пользователя.

## Результат
После успешного выполнения возвращает объект, содержащий число результатов в поле TotalCount и массив [объектов, описывающих пользователей](https://vk.com/dev/objects/user).

## Исключения
+ **AccessTokenInvalidException** — не задан или используется неверный AccessToken.
+ **ArgumentException** — строка поискового запроса пуста или равна значению null.
+ В ходе выполнения могут произойти общие ошибки. Их описание находится на [отдельной странице](https://vk.com/dev/objects/user).

## Пример
```csharp
// Выбор первых двадцати Ивановых Маш.
int count; // хранит общее количество Ивановых Маш зарегистрированных во ВКонтаке
var users = vk.Users.Search(out count, new UserSearchParams { Query = Query }).ToList();
foreach (var user in users)
{
   .....
}

// Получение всей информации о первых 5 Ивановых Машах, начиная с 15 позиции.
int count; // хранит общее количество Ивановых Маш зарегистрированных во ВКонтаке
var users = vk.Users.Search(out count, new UserSearchParams { Query = Query, Fields = ProfileFields.All, Count = 5, Offset = 15}).ToList();
```

## Версия Вконтакте API v.5.103
Дата обновления: 12.01.2020 13:02
