---
layout: default
title: Title for vknet
---

# hello world
## Авторизация
TODO add link

## Пользователи
+ [Users.Get](/users/get/) - Возвращает расширенную информацию о пользователях.
+ [Users.GetFollowers](/users/getFollowers/) - Возвращает список идентификаторов пользователей, которые являются подписчиками пользователя.
+ [Users.GetGroups](/users/getGroups/) - Возвращает список id групп пользователя.
+ [Users.GetGroupsFull](/users/getGroupsFull/) - Возвращает базовую информацию о группах текущего пользователя или о группах из списка gids.
+ [Users.GetSubscription](/users/getSubscription/) - Возвращает список идентификаторов пользователей и групп, которые входят в список подписок пользователя.
+ [Users.GetUserBalance](/users/getUserBalance/) - Возвращает баланс текущего пользователя на счету приложения в сотых долях голоса. Отличается от метода secure.getBalance тем, что не требует безопасного соединения с сервером API.
+ [Users.GetUserSettings](/users/getUserSettings/) - Получает настройки текущего пользователя в данном приложении.
+ [Users.IsAppUser](/users/isAppUser/) - Возвращает информацию о том, установил ли текущий пользователь приложение или нет.
+ [Users.Report](/users/report/) - Позволяет пожаловаться на пользователя.
+ [Users.Search](/users/search/) - Возвращает список пользователей в соответствии с заданным критерием поиска.

## Друзья
+ [Friends.Add](/friends/add/) - Одобряет или создает заявку на добавление в друзья.
+ [Friends.AddList](/friends/addList/) - Возвращает информацию о том добавлен ли текущий пользователь в друзья у указанных пользователей. Также возвращает информацию о наличии исходящей или входящей заявки в друзья (подписки).
+ [Friends.AreFriends](/friends/areFriends/) - Возвращает информацию о том добавлен ли текущий пользователь в друзья у указанных пользователей. Также возвращает информацию о наличии исходящей или входящей заявки в друзья (подписки).
+ [Friends.Delete](/friends/delete/) - Удаляет пользователя из списка друзей или отклоняет заявку в друзья.
+ [Friends.DeleteAllRequests](/friends/deleteAllRequests/) - Отмечает все входящие заявки на добавление в друзья как просмотренные.
+ [Friends.DeleteList](/friends/deleteList/) - Удаляет существующий список друзей текущего пользователя.
+ [Friends.Edit](/friends/edit/) - Редактирует списки друзей для выбранного друга.
+ [Friends.EditList](/friends/editList/) - Редактирует существующий список друзей текущего пользователя.
+ [Friends.Get](/friends/get/) - Возвращает список идентификаторов друзей пользователя или расширенную информацию о друзьях пользователя (при использовании параметра fields).
+ [Friends.GetAppUsers](/friends/getAppUsers/) - Возвращает список идентификаторов друзей текущего пользователя, которые установили данное приложение.
+ [Friends.GetLists](/friends/getLists/) - Возвращает список меток друзей текущего пользователя.
+ [Friends.GetMutual](/friends/getMutual/) - Возвращает список идентификаторов общих друзей между парой пользователей.
+ [Friends.GetOnline](/friends/getOnline/) - Возвращает список идентификаторов, находящихся на сайте друзей, пользователя.
+ [Friends.GetRecent](/friends/getRecent/) - Возвращает список идентификаторов недавно добавленных друзей текущего пользователя.
+ [Friends.GetRequests](/friends/getRequests/) - Возвращает информацию о полученных или отправленных заявках на добавление в друзья для текущего пользователя.

## Группы
+ [Groups.Get] (/groups/get/) - возвращает список групп пользователя.
+ [Groups.GetById] (/groups/getById/) - возвращает информацию о группах по их идентификаторам.
+ [Groups.IsMember] (/groups/isMember/) - возвращает информацию о том, является ли пользователь участником группы.
+ [Groups.GetMembers] (/groups/getMembers/) - возвращает список участников группы.
+ [Groups.Search] (/groups/search/) - Осуществляет поиск групп по заданной подстроке.
+ [Groups.Join] (/groups/join/) - Данный метод позволяет вступить в группу, публичную страницу, а также подтверждать об участии во встрече.
+ [Groups.Leave] (/groups/leave/) - Данный метод позволяет выходить из группы, публичной страницы, или встречи.
+ [Groups.GetInvites] (/groups/getInvites/) - Данный метод возвращает список приглашений в сообщества и встречи.
+ [Groups.BanUser] (/groups/banUser/) - Добавляет пользователя в черный список группы.
+ [Groups.GetBanned] (/groups/getBanned/) - Возвращает список забаненных пользователей в сообществе.
+ [Groups.UnbanUser] (/groups/unbanUser/) - Убирает пользователя из черного списка сообщества.

## Аудиозаписи
+ [Audio.Get](/audio/get/) - возвращает список аудиозаписей пользователя или группы.
+ [Audio.GetFromGroup](/audio/getFromGroup/) - возвращает список аудиозаписей пользователя или группы.
+ [Audio.GetById](/audio/getById/) - возвращает информацию об аудиозаписях по их идентификаторам.
+ [Audio.GetCount](/audio/getCount/) - возвращает количество аудиозаписей пользователя или группы.
+ [Audio.GetLyrics](/audio/getLyrics/) - возвращает текст аудиозаписи.
+ [Audio.GetUploadServer](/audio/getUploadServer/) - возвращает адрес сервера для загрузки аудиозаписей.
+ [Audio.Search](/audio/search/) - осуществляет поиск по аудиозаписям.
+ [Audio.Add](/audio/add/) - копирует существующую аудиозапись на страницу пользователя или группы.
+ [Audio.Delete](/audio/delete/) - удаляет аудиозапись со страницы пользователя или группы.
+ [Audio.Edit](/audio/edit/) - редактирует аудиозапись пользователя или группы.
+ [Audio.Restore](/audio/restore/) - восстанавливает удаленную аудиозапись пользователя или группы.
+ [Audio.Reorder](/audio/reorder/) - изменяет порядок аудиозаписи в списке аудиозаписей пользователя.
+ [Audio.AddAlbum](/audio/addAlbum/) - Создает пустой альбом аудиозаписей.
+ [Audio.EditAlbum](/audio/editAlbum/) - Редактирует название альбома аудиозаписей.
+ [Audio.DeleteAlbum](/audio/deleteAlbum/) - Удаляет альбом аудиозаписей.
+ [Audio.GetPopular](/audio/getPopular/) - Возвращает список аудиозаписей из раздела "Популярное".
+ [Audio.GetAlbums](/audio/getAlbums/) - Возвращает список альбомов аудиозаписей пользователя или группы.
+ [Audio.MoveToAlbum](/audio/moveToAlbum/) - Перемещает аудиозаписи в альбом.
+ [Audio.GetRecommendations](/audio/getRecommendations/) - Возвращает список рекомендуемых аудиозаписей на основе списка воспроизведения заданного пользователя или на основе одной выбранной аудиозаписи.
+ [Audio.SetBroadcast](/audio/setBroadcast/) - Транслирует аудиозапись в статус пользователю или сообществу.

## Сообщения
+ [Messages.Get] (/messages/get/) - Возвращает список входящих либо исходящих личных сообщений текущего пользователя.
+ [Messages.GetHistory] (/messages/getHistory/) - Возвращает историю сообщений текущего пользователя с указанным пользователя или групповой беседы.
+ [Messages.GetById] (/messages/getById/) - Возвращает сообщения по их идентификаторам.
+ [Messages.GetDialogs] (/messages/getDialogs/) - Возвращает список диалогов текущего пользователя.
+ [Messages.SearchDialogs] (/messages/searchDialogs/) - Возвращает список найденных диалогов текущего пользователя по введенной строке поиска.
+ [Messages.Search] (/messages/search/) - Возвращает список найденных личных сообщений текущего пользователя по введенной строке поиска.
+ [Messages.Send] (/messages/send/) - Посылает личное сообщение.
+ [Messages.DeleteDialog] (/messages/deleteDialog/) - Удаляет все личные сообщения в диалоге.
+ [Messages.Delete] (/messages/delete/) - Удаляет сообщения пользователя.
+ [Messages.Restore] (/messages/restore/) - Восстанавливает удаленное сообщение.
+ [Messages.MarkAsNew] (/messages/markAsNew/) - Помечает сообщения как непрочитанные.
+ [Messages.MarkAsRead] (/messages/markAsRead/) - Помечает сообщения как прочитанные.
+ [Messages.SetActivity] (/messages/setActivity/) - Изменяет статус набора текста пользователем в диалоге.
+ [Messages.GetLastActivity] (/messages/getLastActivity/) - Возвращает текущий статус и дату последней активности указанного пользователя.
+ [Messages.GetChat] (/messages/getChat/) - Возвращает информацию о беседе.
+ [Messages.CraeteChat] (/messages/createChat/) - Возвращает информацию о беседе.
+ [Messages.EditChat] (/messages/editChat/) - Изменяет название беседы. 
+ [Messages.GetChatUsers] (/messages/getChatUsers/) - Позволяет получить список пользователей беседы по ее идентификатору.
+ [Messages.AddChatUser] (/messages/addChatUser/) - Добавляет в беседу нового пользователя.
+ [Messages.RemoveChatUser] (/messages/removeChatUser/) - Исключает из беседы пользователя, если текущий пользователь был создателем беседы либо пригласил исключаемого пользователя.
+ [Messages.GetLongPollServer] (/messages/getLongPollServer/) - Возвращает данные, необходимые для подключения к Long Poll серверу.

## Стена
+ [Wall.Get](/wall/get/) - Возвращает список записей со стены пользователя или сообщества.
+ [Wall.GetComments](/wall/getComments/) - Возвращает список комментариев к записи на стене пользователя.
+ [Wall.GetById](/wall/getById/) - Возвращает список записей со стен пользователей или сообществ по их идентификаторам.
+ [Wall.Delete](/wall/delete/) - TODO

## Статус
+ [Status.Get](/status/get/) - Получает статус пользователя.
+ [Status.Set](/status/set/) - Устанавливает статус текущего пользователя.

## Видео
+ [Video.Get](/video/get/) - Возвращает информацию о видеозаписях.
+ [Video.Edit](/video/edit/) - Редактирует данные видеозаписи на странице пользователя.
+ [Video.Add](/video/add/) - Добавляет видеозапись в список пользователя.
+ [Video.Save](/video/save/) - Возвращает адрес сервера (необходимый для загрузки) и данные видеозаписи.
+ [Video.Delete](/video/delete/) - Удаляет видеозапись со страницы пользователя.
+ [Video.Restore](/video/restore/) - Восстанавливает удаленную видеозапись.
+ [Video.Search](/video/search/) - Возвращает список видеозаписей в соответствии с заданным критерием поиска.
+ [Video.GetUserVideos](/video/getUserVideos/) - Возвращает список видеозаписей, на которых отмечен пользователь.
+ [Video.GetAlbums](/video/getAlbums/) - Возвращает список альбомов видеозаписей пользователя или сообщества.
+ [Video.AddAlbum](/video/addAlbum/) - Создает пустой альбом видеозаписей.
+ [Video.EditAlbum](/video/editAlbum/) - Редактирует название альбома видеозаписей.
+ [Video.DeleteAlbum](/video/deleteAlbum/) - Удаляет альбом видеозаписей.
+ [Video.MoveToAlbum](/video/moveToAlbum/) - Перемещает видеозаписи в альбом.
+ [Video.GetComments](/video/getComments/) - Возвращает список комментариев к видеозаписи.
+ [Video.CreateComment](/video/createComment/) - Cоздает новый комментарий к видеозаписи.
+ [Video.DeleteComment](/video/deleteComment/) - Удаляет комментарий к видеозаписи.
+ [Video.RestoreComment](/video/restoreComment/) - Восстанавливает удаленный комментарий к видеозаписи.
+ [Video.EditComment](/video/editComment/) -Изменяет текст комментария к видеозаписи.
+ [Video.GetTags](/video/getTags/) - TODO
+ [Video.PutTag](/video/putTag/) - TODO
+ [Video.RemoveTag](/video/removeTag/) - TODO
+ [Video.GetNewTags](/video/getNewTags/) - TODO
+ [Video.Report](/video/report/) - Позволяет пожаловаться на видеозапись.
+ [Video.ReportComment](/video/reportComment/) - Позволяет пожаловаться на комментарий к видеозаписи.

## Закладки
+ [Fave.GetUsers](/fave/getUsers/) - Позволяет пожаловаться на комментарий к видеозаписи.
+ [Fave.GetPhotos](/fave/getPhotos/) - Возвращает фотографии, на которых текущий пользователь поставил отметку "Мне нравится".
+ [Fave.GetPosts](/fave/getPosts/) - Возвращает записи, на которых текущий пользователь поставил отметку «Мне нравится».
+ [Fave.GetVideos](/fave/getVideos/) - Возвращает список видеозаписей, на которых текущий пользователь поставил отметку «Мне нравится».
+ [Fave.GetLinks](/fave/getLinks/) - Возвращает ссылки, добавленные в закладки текущим пользователем.

## Служебные
+ [Utils.CheckLink](/utils/checkLink/) - Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
+ [Utils.ResolveScreenName](/utils/resolveScrennName/) - Определяет тип объекта (пользователь, сообщество, приложение) и его идентификатор по короткому имени screenName.
+ [Utils.GetServerTime](/utils/getServerTime/) - Возвращает текущее время на сервере ВКонтакте.

## Данные ВК
+ [Database.GetCountries](/database/getCountries/) - вращает список стран.
+ [Database.GetRegions](/database/getRegions/) - Возвращает список регионов.
+ [Database.GetStreetsById](/database/getStreetsById/) - Возвращает информацию об улицах по их идентификаторам.
+ [Database.GetCountriesById](/database/getCountriesById/) - Возвращает информацию о странах по их идентификаторам.
+ [Database.GetCities](/database/getCities/) - Возвращает список городов.
+ [Database.GetCitiesById](/database/getCitiesById/) - Возвращает информацию о городах по их идентификаторам.
+ [Database.GetUniversities](/database/getUniversities/) - Возвращает список высших учебных заведений.
+ [Database.GetSchools](/database/getSchools/) - Возвращает список школ.
+ [Database.GetFaculties](/database/getFaculties/) - Возвращает список факультетов.
