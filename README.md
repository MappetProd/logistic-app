# Веб-приложение оформления заказов (грузов)
## Stack
- Backend: ASP.NET Core
- Frontend: ASP.NET MVC, Razor pages
- ORM: Entity Framework Core
- Database: MySQL
- Containerization: Docker / Docker Compose

## Setup
Чтобы развернуть данное веб-приложение следует установить:
- Visual Studio 2022
- Docker Desktop

## Features
- В проекте используется библиотека NewId для более эффективной работы с записями в БД (NewId является сортируемым guid, который генерируется на основе unix timestamp, id процесса). См. подробно: https://habr.com/ru/articles/665024/.

## Quick Start
### 1. Установите исходный кода проекта
   
Самая актуальная и стабильная версия лежит в ветке main.

<img src=https://github.com/user-attachments/assets/9b05a8ef-6db3-4f03-aebf-576793d3a0f2 width="350" height="400">

### 2. Распакуйте архив с исходным кодом
### 3. Откройте файл решения "LogisticApp.sln"
### 4. В открытом проекте выберите "docker-compose" в качестве элемента запуска (Startup Item)

![{9DBF6F83-819C-4E6A-A69D-C2225EEBB882}](https://github.com/user-attachments/assets/fda3135a-a3df-4316-a955-7881438eb444)

Альтернативный вариант: откройте PowerShell и введите следующую команду:
```
docker-compose -f docker-compose.yml up
```
В таком случае шаг №5 выполнять не нужно.

### 5. Начните сборку проекта, нажав на кнопку справа от элемента запуска. 

### 6. Ожидайте запуск веб-приложения. 
Ожидаемое поведение: в Docker Desktop разворачиваются 2 контейнера, а именно база данных и веб-приложение, после чего в браузере открывается главная страница веб-приложения.
### 7. yippee!

<img src=https://github.com/user-attachments/assets/b1c3c59e-0379-4319-9907-3654759f3ee3 width="500" height="300">

## О базе данных
При первом запуске веб-приложения в БД автоматически добавятся следующие данные:
- Города: Москва, Санкт-Петербург, Екатеринбург, Краснодар
- Улицы: проспект Невский (Санкт-Петербург), проспект Литейный (Санкт-Петербург), улица Ленина (Екатеринбург), улица Красная (Екатеринбург), улица Тверская (Москва)
- Для каждой улицы добавлено по одному дому и, соответственно, почтовому индексу.

Этого минимального набора данных достаточно для проверки функционала автодополнения пользовательского ввода в форме создания заказа.

## Демонстрация функционала
### Вывод всех созданных заказов
<img src="https://github.com/user-attachments/assets/de0b4bfa-5322-405e-88a6-072d5fd2eebf" width="500" height="280">

### Создание заказа
<img src="https://github.com/user-attachments/assets/f9fb8343-1786-405b-8751-ead043f1be88" width="350" height="400">

<em>Автодополнение ввода названия города</em>

<img src="https://github.com/user-attachments/assets/2016383a-acc3-44ac-aa40-20b7f1d1f231" width="350" height="400">

<em>Автодополнения ввода адреса (на основе города)</em>

<img src="https://github.com/user-attachments/assets/8b079add-d5a0-4937-9c9a-f15ee626a984" width="350" height="400">

<em>Полностью заполненная форма заказа</em>

<img src="https://github.com/user-attachments/assets/55c95166-0849-4ec4-9f50-498815b32909" width="500" height="280">

<em>Новый заказ добавился на страницу</em>

### Просмотр информации о заказе в отдельной форме
<img src="https://github.com/user-attachments/assets/98fa8516-e2c1-4cb5-ae86-c4a4a10e9250" width="450" height="400">

<em>Новый заказ добавился на страницу</em>
