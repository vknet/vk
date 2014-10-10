---
layout: default
title: VKNET ВКонтакте API для .NET (C#)
comments: false
---
# Установка через Nuget
![VkNet Nuget](https://raw.githubusercontent.com/vknet/vk/gh-pages/images/vk_nuget.jpg)

# Описание методов API
Ниже приводятся все реализованные методы для работы с данными ВКонтакте.
## Авторизация
[Authorize](/vk/authorize/) - авторизация на сервере вконтакте и получение AccessToken.

## Пользователи
+ [Users.Get](/vk/users/get/) - Возвращает расширенную информацию о пользователях.
+ [Users.GetFollowers](/vk/users/getFollowers/) - Возвращает список идентификаторов пользователей, которые являются подписчиками пользователя.
+ [Users.GetGroups](/vk/users/getGroups/) - Возвращает список id групп пользователя.
+ [Users.GetGroupsFull](/vk/users/getGroupsFull/) - Возвращает базовую информацию о группах текущего пользователя или о группах из списка gids.
+ [Users.GetSubscription](/vk/users/getSubscription/) - Возвращает список идентификаторов пользователей и групп, которые входят в список подписок пользователя.
+ [Users.GetUserBalance](/vk/users/getUserBalance/) - Возвращает баланс текущего пользователя на счету приложения в сотых долях голоса. Отличается от метода secure.getBalance тем, что не требует безопасного соединения с сервером API.
+ [Users.GetUserSettings](/vk/users/getUserSettings/) - Получает настройки текущего пользователя в данном приложении.
+ [Users.IsAppUser](/vk/users/isAppUser/) - Возвращает информацию о том, установил ли текущий пользователь приложение или нет.
+ [Users.Report](/vk/users/report/) - Позволяет пожаловаться на пользователя.
+ [Users.Search](/vk/users/search/) - Возвращает список пользователей в соответствии с заданным критерием поиска.

## Друзья
+ [Friends.Add](/vk/friends/add/) - Одобряет или создает заявку на добавление в друзья.
+ [Friends.AddList](/vk/friends/addList/) - Возвращает информацию о том добавлен ли текущий пользователь в друзья у указанных пользователей. Также возвращает информацию о наличии исходящей или входящей заявки в друзья (подписки).
+ [Friends.AreFriends](/vk/friends/areFriends/) - Возвращает информацию о том добавлен ли текущий пользователь в друзья у указанных пользователей. Также возвращает информацию о наличии исходящей или входящей заявки в друзья (подписки).
+ [Friends.Delete](/vk/friends/delete/) - Удаляет пользователя из списка друзей или отклоняет заявку в друзья.
+ [Friends.DeleteAllRequests](/vk/friends/deleteAllRequests/) - Отмечает все входящие заявки на добавление в друзья как просмотренные.
+ [Friends.DeleteList](/vk/friends/deleteList/) - Удаляет существующий список друзей текущего пользователя.
+ [Friends.Edit](/vk/friends/edit/) - Редактирует списки друзей для выбранного друга.
+ [Friends.EditList](/vk/friends/editList/) - Редактирует существующий список друзей текущего пользователя.
+ [Friends.Get](/vk/friends/get/) - Возвращает список идентификаторов друзей пользователя или расширенную информацию о друзьях пользователя (при использовании параметра fields).
+ [Friends.GetAppUsers](/vk/friends/getAppUsers/) - Возвращает список идентификаторов друзей текущего пользователя, которые установили данное приложение.
+ [Friends.GetLists](/vk/friends/getLists/) - Возвращает список меток друзей текущего пользователя.
+ [Friends.GetMutual](/vk/friends/getMutual/) - Возвращает список идентификаторов общих друзей между парой пользователей.
+ [Friends.GetOnline](/vk/friends/getOnline/) - Возвращает список идентификаторов, находящихся на сайте друзей, пользователя.
+ [Friends.GetRecent](/vk/friends/getRecent/) - Возвращает список идентификаторов недавно добавленных друзей текущего пользователя.
+ [Friends.GetRequests](/vk/friends/getRequests/) - Возвращает информацию о полученных или отправленных заявках на добавление в друзья для текущего пользователя.

## Группы
+ [Groups.Get] (/vk/groups/get/) - возвращает список групп пользователя.
+ [Groups.GetById] (/vk/groups/getById/) - возвращает информацию о группах по их идентификаторам.
+ [Groups.IsMember] (/vk/groups/isMember/) - возвращает информацию о том, является ли пользователь участником группы.
+ [Groups.GetMembers] (/vk/groups/getMembers/) - возвращает список участников группы.
+ [Groups.Search] (/vk/groups/search/) - Осуществляет поиск групп по заданной подстроке.
+ [Groups.Join] (/vk/groups/join/) - Данный метод позволяет вступить в группу, публичную страницу, а также подтверждать об участии во встрече.
+ [Groups.Leave] (/vk/groups/leave/) - Данный метод позволяет выходить из группы, публичной страницы, или встречи.
+ [Groups.GetInvites] (/vk/groups/getInvites/) - Данный метод возвращает список приглашений в сообщества и встречи.
+ [Groups.BanUser] (/vk/groups/banUser/) - Добавляет пользователя в черный список группы.
+ [Groups.GetBanned] (/vk/groups/getBanned/) - Возвращает список забаненных пользователей в сообществе.
+ [Groups.UnbanUser] (/vk/groups/unbanUser/) - Убирает пользователя из черного списка сообщества.

## Аудиозаписи
+ [Audio.Get](/vk/audio/get/) - возвращает список аудиозаписей пользователя или группы.
+ [Audio.GetFromGroup](/vk/audio/getFromGroup/) - возвращает список аудиозаписей пользователя или группы.
+ [Audio.GetById](/vk/audio/getById/) - возвращает информацию об аудиозаписях по их идентификаторам.
+ [Audio.GetCount](/vk/audio/getCount/) - возвращает количество аудиозаписей пользователя или группы.
+ [Audio.GetLyrics](/vk/audio/getLyrics/) - возвращает текст аудиозаписи.
+ [Audio.GetUploadServer](/vk/audio/getUploadServer/) - возвращает адрес сервера для загрузки аудиозаписей.
+ [Audio.Search](/vk/audio/search/) - осуществляет поиск по аудиозаписям.
+ [Audio.Add](/vk/audio/add/) - копирует существующую аудиозапись на страницу пользователя или группы.
+ [Audio.Delete](/vk/audio/delete/) - удаляет аудиозапись со страницы пользователя или группы.
+ [Audio.Edit](/vk/audio/edit/) - редактирует аудиозапись пользователя или группы.
+ [Audio.Restore](/vk/audio/restore/) - восстанавливает удаленную аудиозапись пользователя или группы.
+ [Audio.Reorder](/vk/audio/reorder/) - изменяет порядок аудиозаписи в списке аудиозаписей пользователя.
+ [Audio.AddAlbum](/vk/audio/addAlbum/) - Создает пустой альбом аудиозаписей.
+ [Audio.EditAlbum](/vk/audio/editAlbum/) - Редактирует название альбома аудиозаписей.
+ [Audio.DeleteAlbum](/vk/audio/deleteAlbum/) - Удаляет альбом аудиозаписей.
+ [Audio.GetPopular](/vk/audio/getPopular/) - Возвращает список аудиозаписей из раздела "Популярное".
+ [Audio.GetAlbums](/vk/audio/getAlbums/) - Возвращает список альбомов аудиозаписей пользователя или группы.
+ [Audio.MoveToAlbum](/vk/audio/moveToAlbum/) - Перемещает аудиозаписи в альбом.
+ [Audio.GetRecommendations](/vk/audio/getRecommendations/) - Возвращает список рекомендуемых аудиозаписей на основе списка воспроизведения заданного пользователя или на основе одной выбранной аудиозаписи.
+ [Audio.SetBroadcast](/vk/audio/setBroadcast/) - Транслирует аудиозапись в статус пользователю или сообществу.
+ [Audio.Save](/vk/audio/save/) - Сохраняет аудиозаписи после успешной загрузки.

## Сообщения
+ [Messages.Get] (/vk/messages/get/) - Возвращает список входящих либо исходящих личных сообщений текущего пользователя.
+ [Messages.GetHistory] (/vk/messages/getHistory/) - Возвращает историю сообщений текущего пользователя с указанным пользователя или групповой беседы.
+ [Messages.GetById] (/vk/messages/getById/) - Возвращает сообщения по их идентификаторам.
+ [Messages.GetDialogs] (/vk/messages/getDialogs/) - Возвращает список диалогов текущего пользователя.
+ [Messages.SearchDialogs] (/vk/messages/searchDialogs/) - Возвращает список найденных диалогов текущего пользователя по введенной строке поиска.
+ [Messages.Search] (/vk/messages/search/) - Возвращает список найденных личных сообщений текущего пользователя по введенной строке поиска.
+ [Messages.Send] (/vk/messages/send/) - Посылает личное сообщение.
+ [Messages.DeleteDialog] (/vk/messages/deleteDialog/) - Удаляет все личные сообщения в диалоге.
+ [Messages.Delete] (/vk/messages/delete/) - Удаляет сообщения пользователя.
+ [Messages.Restore] (/vk/messages/restore/) - Восстанавливает удаленное сообщение.
+ [Messages.MarkAsNew] (/vk/messages/markAsNew/) - Помечает сообщения как непрочитанные.
+ [Messages.MarkAsRead] (/vk/messages/markAsRead/) - Помечает сообщения как прочитанные.
+ [Messages.SetActivity] (/vk/messages/setActivity/) - Изменяет статус набора текста пользователем в диалоге.
+ [Messages.GetLastActivity] (/vk/messages/getLastActivity/) - Возвращает текущий статус и дату последней активности указанного пользователя.
+ [Messages.GetChat] (/vk/messages/getChat/) - Возвращает информацию о беседе.
+ [Messages.CraeteChat] (/vk/messages/createChat/) - Возвращает информацию о беседе.
+ [Messages.EditChat] (/vk/messages/editChat/) - Изменяет название беседы. 
+ [Messages.GetChatUsers] (/vk/messages/getChatUsers/) - Позволяет получить список пользователей беседы по ее идентификатору.
+ [Messages.AddChatUser] (/vk/messages/addChatUser/) - Добавляет в беседу нового пользователя.
+ [Messages.RemoveChatUser] (/vk/messages/removeChatUser/) - Исключает из беседы пользователя, если текущий пользователь был создателем беседы либо пригласил исключаемого пользователя.
+ [Messages.GetLongPollServer] (/vk/messages/getLongPollServer/) - Возвращает данные, необходимые для подключения к Long Poll серверу.

## Стена
+ [Wall.Get](/vk/wall/get/) - Возвращает список записей со стены пользователя или сообщества.
+ [Wall.GetComments](/vk/wall/getComments/) - Возвращает список комментариев к записи на стене пользователя.
+ [Wall.GetById](/vk/wall/getById/) - Возвращает список записей со стен пользователей или сообществ по их идентификаторам.
+ [Wall.Delete](/vk/wall/delete/) - TODO

## Статус
+ [Status.Get](/vk/status/get/) - Получает статус пользователя.
+ [Status.Set](/vk/status/set/) - Устанавливает статус текущего пользователя.

## Видео
+ [Video.Get](/vk/video/get/) - Возвращает информацию о видеозаписях.
+ [Video.Edit](/vk/video/edit/) - Редактирует данные видеозаписи на странице пользователя.
+ [Video.Add](/vk/video/add/) - Добавляет видеозапись в список пользователя.
+ [Video.Save](/vk/video/save/) - Возвращает адрес сервера (необходимый для загрузки) и данные видеозаписи.
+ [Video.Delete](/vk/video/delete/) - Удаляет видеозапись со страницы пользователя.
+ [Video.Restore](/vk/video/restore/) - Восстанавливает удаленную видеозапись.
+ [Video.Search](/vk/video/search/) - Возвращает список видеозаписей в соответствии с заданным критерием поиска.
+ [Video.GetUserVideos](/vk/video/getUserVideos/) - Возвращает список видеозаписей, на которых отмечен пользователь.
+ [Video.GetAlbums](/vk/video/getAlbums/) - Возвращает список альбомов видеозаписей пользователя или сообщества.
+ [Video.AddAlbum](/vk/video/addAlbum/) - Создает пустой альбом видеозаписей.
+ [Video.EditAlbum](/vk/video/editAlbum/) - Редактирует название альбома видеозаписей.
+ [Video.DeleteAlbum](/vk/video/deleteAlbum/) - Удаляет альбом видеозаписей.
+ [Video.MoveToAlbum](/vk/video/moveToAlbum/) - Перемещает видеозаписи в альбом.
+ [Video.GetComments](/vk/video/getComments/) - Возвращает список комментариев к видеозаписи.
+ [Video.CreateComment](/vk/video/createComment/) - Cоздает новый комментарий к видеозаписи.
+ [Video.DeleteComment](/vk/video/deleteComment/) - Удаляет комментарий к видеозаписи.
+ [Video.RestoreComment](/vk/video/restoreComment/) - Восстанавливает удаленный комментарий к видеозаписи.
+ [Video.EditComment](/vk/video/editComment/) -Изменяет текст комментария к видеозаписи.
+ [Video.GetTags](/vk/video/getTags/) - TODO
+ [Video.PutTag](/vk/video/putTag/) - TODO
+ [Video.RemoveTag](/vk/video/removeTag/) - TODO
+ [Video.GetNewTags](/vk/video/getNewTags/) - TODO
+ [Video.Report](/vk/video/report/) - Позволяет пожаловаться на видеозапись.
+ [Video.ReportComment](/vk/video/reportComment/) - Позволяет пожаловаться на комментарий к видеозаписи.

## Закладки
+ [Fave.GetUsers](/vk/fave/getUsers/) - Позволяет пожаловаться на комментарий к видеозаписи.
+ [Fave.GetPhotos](/vk/fave/getPhotos/) - Возвращает фотографии, на которых текущий пользователь поставил отметку "Мне нравится".
+ [Fave.GetPosts](/vk/fave/getPosts/) - Возвращает записи, на которых текущий пользователь поставил отметку «Мне нравится».
+ [Fave.GetVideos](/vk/fave/getVideos/) - Возвращает список видеозаписей, на которых текущий пользователь поставил отметку «Мне нравится».
+ [Fave.GetLinks](/vk/fave/getLinks/) - Возвращает ссылки, добавленные в закладки текущим пользователем.

## Служебные
+ [Utils.CheckLink](/vk/utils/checkLink/) - Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
+ [Utils.ResolveScreenName](/vk/utils/resolveScreenName/) - Определяет тип объекта (пользователь, сообщество, приложение) и его идентификатор по короткому имени screenName.
+ [Utils.GetServerTime](/vk/utils/getServerTime/) - Возвращает текущее время на сервере ВКонтакте.

## Данные ВК
+ [Database.GetCountries](/vk/database/getCountries/) - вращает список стран.
+ [Database.GetRegions](/vk/database/getRegions/) - Возвращает список регионов.
+ [Database.GetStreetsById](/vk/database/getStreetsById/) - Возвращает информацию об улицах по их идентификаторам.
+ [Database.GetCountriesById](/vk/database/getCountriesById/) - Возвращает информацию о странах по их идентификаторам.
+ [Database.GetCities](/vk/database/getCities/) - Возвращает список городов.
+ [Database.GetCitiesById](/vk/database/getCitiesById/) - Возвращает информацию о городах по их идентификаторам.
+ [Database.GetUniversities](/vk/database/getUniversities/) - Возвращает список высших учебных заведений.
+ [Database.GetSchools](/vk/database/getSchools/) - Возвращает список школ.
+ [Database.GetFaculties](/vk/database/getFaculties/) - Возвращает список факультетов.
