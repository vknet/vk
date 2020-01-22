---
layout: default
title: Метод Friends.Search
permalink: friends/search/
comments: true
---
# Метод Friends.Search
Позволяет искать по списку друзей пользователей.

Для расширенного поиска по списку друзей можно использовать метод **users.search** с параметром **from_list = friends**.

Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token). Требуются [права доступа](https://vk.com/dev/permissions): **friends**.

Страница документации ВКонтакте [friends.search](https://vk.com/dev/friends.search).

## Синтаксис
``` csharp
public ReadOnlyCollection<User> Search(FriendsSearchParams @params)
```

## Параметры
Класс **`FriendsSearchParams`** содержит следующие свойства:

+ **user_id** — идентификатор пользователя, по списку друзей которого необходимо произвести поиск.
+ **q** — строка запроса.
+ **fields** — список дополнительных полей, которые необходимо вернуть. 
Доступные значения: *nickname*, *screen_name*, *sex*, *bdate*, *city*, *country*, *timezone*, *photo_50*, *photo_100*, *photo_200_orig*, *has_mobile*, *contacts*, *education*, *online*, *relation*, *last_seen*, *status*, *can_write_private_message*, *can_see_all_posts*, can_post, *universities*, *domain*.
+ **name_case** — падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – *nom*, родительный – *gen*, дательный – *dat*, винительный – *acc*, творительный – *ins*, предложный – *abl*. По умолчанию *nom*.
+ **offset** — смещение, необходимое для выборки определенного подмножества друзей.
+ **count** — количество друзей, которое нужно вернуть.

## Результат
После успешного выполнения метод  возвращает список объектов [пользователей](https://vk.com/dev/objects/user).

## Исключения
+ В ходе выполнения могут произойти общие ошибки. Их описание находится на [отдельной странице](https://vk.com/dev/errors).

## Пример
``` csharp
var search = _api.Friends.Search(new FriendsSearchParams{
	userId = 0
});
```

## Версия Вконтакте API v.5.103
Дата обновления: 17.01.2020 15:56.
