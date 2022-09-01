# BoxVideoDownloader
Скачивание видео youtube и m3u8 

![icon for github](https://user-images.githubusercontent.com/51737588/187915147-e94a0484-ae41-47a0-aa07-05c14a425493.png)

Написана на языке C#

📚Библеотеки : <a href = "https://ffmpeg.org/">ffmpeg</a> , <a href = "https://github.com/yt-dlp/yt-dlp">yt-dlp</a>

Программа BoxVideoDownloader предназначена для для скачивания роликов , плейлистов на ютубе . А также скачивание роликов в формате m3u8 плюс дополнительные плюшки внутри программы .

Цель: понять как работают программы по скачиванию роликов. Также создать свою прогу с открым кодом.

В самой программе я использую две библеотеки🧐 . 

![ffmpeg](https://user-images.githubusercontent.com/51737588/187916922-acfc88b2-3601-4f31-9f0e-eb3ac16df59d.png)

Первая "ffmpeg" она позволяет манипулировать самим файлом например конвертировать, вырезать ,скачивать m3u8 и т.д

![yt](https://user-images.githubusercontent.com/51737588/187918712-b15e9b65-6aa7-49f7-be3a-392f39e12482.png)

Вторая "yt-dlp" (это форк <a href = "https://youtube-dl.org/">youtube-dl</a> ) позволяет скачивать с огромного количества ресурсов такие например как : youtube , coub , tik tok и т.д. . Плюс у нее большой функционал.


<b><h3>Как установить?</h3></b>

Вообще чтобы все работало корректно нужно сделать следующее:

1) Обновить .net framework (скачай автономный установщик) ссылка: https://inlnk.ru/0Qz8Yd   (я сократил  ссылку)

2) Обновить Windows Management Framework (возможно потребуется перезагрузка)  ссылка: https://www.microsoft.com/en-us/download/details.aspx?id=54616

не забудь центр обновления windows должен быть включен . Включить его можно вот так : win + r , комманда service.msc , ищешь центр обнов , и ставишь тип запуска "автоматическая".

3) Обновить Power Shell (там чуть ниже в репозитории есть выбор версии ОС выбирай нужную)  ссылка: https://github.com/PowerShell/PowerShell

4) Когда обновил все что нужно переходи в обновленный power shell

![choco](https://user-images.githubusercontent.com/51737588/187921587-dcdf0aab-143d-43fa-94bc-f213ba6279ee.png)

5) Тут потребуется "Chocolatey".Это менеджер пакетов который работает через cmd и power shell. С помощью него поставим нужные библеотеки. Так вот вводишь по порядку эти команды в Power Shell :

- Set-ExecutionPolicy Bypass -Scope Process (эта команда нужна для получения прав установки)

- Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))

Эта команда установит "Chocolatey" . Желательно перезапустить power shell.

- choco install ffmpeg

- choco install yt-dlp

6) Последний пункт скачиваешь установщик программы который я приложил в этом репозитории. Переходишь в папку Debug и запускаешь установщик который называется BoxVideoDownloader.

<b>Enjoy!</b>


Скриншоты программы🦉

![скрин1](https://user-images.githubusercontent.com/51737588/187923487-325cb3e4-425b-4853-9d9c-5cd21ff39b86.jpg)


![скрин2](https://user-images.githubusercontent.com/51737588/187923530-52c6c0b4-af94-4dd1-88a4-57a840af669a.jpg)


![скрин 3](https://user-images.githubusercontent.com/51737588/187923560-52d2d9ef-6ba0-46c8-ba7f-2b8a0b8e0898.jpg)


Полезные ссылки🔗:

1) Обновление power shell https://winitpro.ru/index.php/2020/05/14/obnovlenie-powershell-v-windows/

2) Видео как обновить power shell https://www.youtube.com/watch?v=HoeLk-RjMLY

3) Сайт с командами по yt-dlp https://www.mankier.com/1/yt-dlp



