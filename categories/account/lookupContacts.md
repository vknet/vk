---
layout: default
title: Метод Account.LookupContacts
permalink: account/lookupContacts/
comments: true
---
# Метод Account.LookupContacts
Позволяет искать пользователей ВКонтакте, используя телефонные номера, email-адреса, и идентификаторы пользователей в других сервисах. Найденные пользователи могут быть также в дальнейшем получены методом friends.getSuggestions.

Страница документации ВКонтакте [account.lookupContacts](https://vk.com/dev/account.lookupContacts).

## Синтаксис
``` csharp
public LookupContactsResult LookupContacts(
	List<string> contacts,
	Services service,
	string mycontact,
	bool? returnAll,
	UsersFields fields
)
```

## Параметры
+ **contacts** - Список контактов, разделенных через запятую. список слов, разделенных через запятую
+ **service** - Строковой идентификатор сервиса, по контактам которого производится поиск. Может принимать следующие значения: 
email 
phone 
twitter 
facebook 
odnoklassniki 
instagram 
google 
строка, обязательный параметр
+ **mycontact** - Контакт текущего пользователя в заданном сервисе. строка
+ **returnAll** - 1 – возвращать также контакты, найденные ранее с использованием этого сервиса, 0 – возвращать только контакты, найденные с использованием поля contacts. флаг, может принимать значения 1 или 0
+ **fields** - Список дополнительных полей, которые необходимо вернуть. 
Доступные значения: nickname, domain, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список слов, разделенных через запятую

## Результат
В качестве результата метод возвращает два списка: 

+ **found** – список объектов пользователей, расширенных полями contact – контакт, по которому был найден пользователь (не приходит если пользователь был найден при предыдущем использовании метода), request_sent – запрос на добавление в друзья уже был выслан, либо пользователь уже является другом, common_count если этот контакт также был импортирован друзьями или контактами текущего пользователя. Метод также возвращает найденные ранее контакты. 
+ **other** – список контактов, которые не были найдены. Объект содержит поля contact и common_count если этот контакт также был импортирован друзьями или контактами текущего пользователя.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.45
Дата обновления: 10.02.2016 13:55:10
