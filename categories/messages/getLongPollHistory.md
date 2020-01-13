---
layout: default
title: Метод Messages.GetLongPollHistory
permalink: messages/getLongPollHistory/
comments: true
---
# Метод Messages.GetLongPollHistory
Возвращает обновления в личных сообщениях пользователя.

Страница документации ВКонтакте [messages.getLongPollHistory](https://vk.com/dev/messages.getLongPollHistory).

## Синтаксис
``` csharp
public LongPollHistoryResponse GetLongPollHistory(MessagesGetLongPollHistoryParams @params)
```

## Параметры
Класс **`MessagesGetLongPollHistoryParams`** содержит следующие свойства:

+ **Ts** — Последнее значение параметра ts, полученное от Long Poll сервера или с помощью метода messages.getLongPollServer положительное число
+ **Pts** — Последнее значение параметра new_pts, полученное от Long Poll сервера, используется для получения действий, которые хранятся всегда. положительное число
+ **PreviewLength** — Количество символов, по которому нужно обрезать сообщение. Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются). положительное число
+ **Onlines** — При передаче в этот параметра значения 1 будет возвращена история только от тех пользователей, которые сейчас online. флаг, может принимать значения 1 или 0
+ **Fields** — Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание. 
Доступные значения: sex, bdate, city, country, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, photo_id, online, online_mobile, domain, has_mobile, contacts, connections, site, education, universities, schools, can_post, can_see_all_posts, can_see_audio, can_write_private_message, status, last_seen, common_count, relation, relatives, counters, screen_name, maiden_name, timezone, occupation,activities, interests, music, movies, tv, books, games, about, quotes, personal, friend_status, military, career список слов, разделенных через запятую, по умолчанию photo,photo_medium_rec,sex,online,screen_name
+ **EventsLimit** — Если количество событий в истории превысит это значение, будет возвращена ошибка. положительное число, по умолчанию 1000, минимальное значение 1000
+ **MsgsLimit** — Количество сообщений, которое нужно вернуть. положительное число, по умолчанию 200, минимальное значение 200
+ **MaxMsgId** — Максимальный идентификатор сообщения среди уже имеющихся в локальной копии. Необходимо учитывать как сообщения, полученные через методы API (например messages.getDialogs, messages.getHistory), так и данные, полученные из Long Poll сервера (события с кодом 4). положительное число

## Результат
Возвращает объект, который содержит поля history и messages. 
Поле history представляет из себя массив, аналогичный полю updates, получаемому от Long Poll сервера, за некоторыми исключениями: для событий с кодом 4 (добавление нового сообщения) отсутствуют все поля, кроме первых трёх, а также отсутствуют события с кодами 8, 9 (друг появился/пропал из сети) и 61, 62 (набор текста в диалоге/беседе). 
Поле messages представляет из себя массив личных сообщений – объектов message, которые встречались среди событий с кодом 4 (добавление нового сообщения) из поля history. Каждый объект message содержит набор полей, описание которых доступно здесь. Первый элемент массива представляет собой общее количество сообщений. 

Ограничения В случае, если ts слишком старый (больше суток), а max_msg_id не передан, метод может вернуть ошибку 10 (Internal server error). 
Если количество новых сообщений в выборке слишком велико (&gt; msgs_limit) то вернется количество сообщений, указанное в msgs_limit (по умолчанию 200), а также ответ будет содержать поле more: 1.

## Пример
``` csharp
var getLongPollHistory = _api.Messages.GetLongPollHistory(new MessagesGetLongPollHistoryParams{
	
});
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
