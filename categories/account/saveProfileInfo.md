---
layout: default
title: Метод Account.SaveProfileInfo
permalink: account/saveProfileInfo/
comments: true
---
# Метод Account.SaveProfileInfo
Редактирует информацию текущего профиля.

Страница документации ВКонтакте [account.saveProfileInfo](https://vk.com/dev/account.saveProfileInfo).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).
Требуются [права доступа](https://vk.com/dev/permissions) messages.

## Синтаксис
``` csharp
public bool SaveProfileInfo(AccountSaveProfileInfoParams @params)
```

## Параметры
Класс **`AccountSaveProfileInfoParams`** содержит следующие свойства:

+ **FirstName** - Имя пользователя.
+ **LastName** - Фамилия пользователя.
+ **MaidenName** - Девичья фамилия пользователя (только для женского пола).
+ **ScreenName** - Короткое имя страницы. строка
+ **CancelRequestId** - Идентификатор заявки на смену имени, которую необходимо отменить. 
Если передан этот параметр, все остальные параметры игнорируются.
+ **Sex** - Пол пользователя. Возможные значения: 
1 — женский; 
2 — мужской. 
+ **Relation** - Семейное положение пользователя. Возможные значения: 
1 — не женат/не замужем; 
2 — есть друг/есть подруга; 
3 — помолвлен/помолвлена; 
4 — женат/замужем; 
5 — всё сложно; 
6 — в активном поиске; 
7 — влюблён/влюблена; 
0 — не указано. 
+ **RelationPartner** - Объект пользователя, с которым связано семейное положение.
+ **Bdate** - Дата рождения пользователя в формате DD.MM.YYYY, например "15.11.1984".
+ **BdateVisibility** - Видимость даты рождения. Возможные значения: 
1 — показывать дату рождения; 
2 — показывать только месяц и день; 
0 — не показывать дату рождения. 
+ **HomeTown** - Родной город пользователя.
+ **CountryId** - Идентификатор страны пользователя.
+ **CityId** - Идентификатор города пользователя.
+ **Status** - Статус пользователя, который также может быть изменен методом [status.set](https://vknet.github.io/vk/status/set/).
+ **Phone** - Телефон пользователя.

## Результат
Метод возвращает **true** — если информация была сохранена, **false** — если ни одно из полей не было сохранено. 
## Пример
``` csharp
ChangeNameRequest change;
ChangeNameRequest change;
            var saveProfileInfo = _api.Account.SaveProfileInfo(out change, new AccountSaveProfileInfoParams
            {
                Sex = Sex.Female
            });
            Console.WriteLine(saveProfileInfo.ToString());
            Console.ReadKey();
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 19:02
