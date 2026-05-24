# LLibrary - веб-приложение для управления школьной библиотекой
**.NET 8 | Blazor Server | Entity Framework Core | SQL Server | Docker | FluentValidation**

Курсовой проект по дисциплине «Кроссплатформенная среда исполнения программного обеспечения»

---

## О проекте
**LLibrary** — это веб-приложение для автоматизации учёта книжного фонда, регистрации читателей и контроля выдачи/возврата книг в школьной библиотеке. Разработано с использованием современного стека технологий .NET 8, ASP.NET Core, Blazor Server и MS SQL Server. Приложение позволяет библиотекарям управлять фондом, а учащимся и преподавателям — просматривать каталог и отслеживать доступность книг.

---

## Основные возможности

### Для библиотекарей:
- Управление книжным фондом: добавление, редактирование, удаление книг с привязкой к авторам
- Регистрация и учёт читателей (учеников и преподавателей)
- Оформление выдачи книг и фиксация возвратов
- Просмотр журнала операций с фильтрацией по статусу
- Валидация данных через FluentValidation

### Для читателей:
- Просмотр каталога книг с поиском по названию и автору
- Просмотр информации о наличии книг в фонде

### Система:
- Автоматическая проверка занятости книги при выдаче
- Запрет удаления книг/читателей с активными записями в журнале
- Уникальность ISBN, каскадное удаление связанных записей
- Контейнеризация через Docker с healthchecks и volumes

---

## Технологии

| Технология | Назначение |
|------------|------------|
| .NET 8 | Кроссплатформенная среда исполнения (LTS) |
| ASP.NET Core | Веб-фреймворк, маршрутизация, DI |
| Blazor Server | Интерактивный веб-интерфейс на C# |
| Entity Framework Core 8 | ORM, Code First, миграции, Fluent API |
| MS SQL Server 2022 | Реляционная база данных |
| FluentValidation | Валидация форм на клиенте и сервере |
| Docker / Docker Compose | Контейнеризация и оркестрация |
| Git | Система контроля версий |

---

## Структура проекта

```
LLibrary/
├── Components/                 # Blazor-компоненты
│   ├── Layout/
│   │   ├── MainLayout.razor   # Основной макет
│   │   └── NavMenu.razor      # Боковое меню навигации
│   ├── Pages/
│   │   ├── Home.razor         # Главная страница со статистикой
│   │   ├── BookList.razor     # Управление книжным фондом
│   │   ├── ReaderList.razor   # Управление читателями
│   │   ├── BookIssuance.razor # Журнал выдачи/возврата
│   │   ├── AddBook.razor      # Форма добавления книги
│   │   └── Error.razor        # Страница ошибок
│   ├── App.razor              # Корневой компонент
│   ├── Routes.razor           # Настройка роутинга
│   └── _Imports.razor         # Глобальные using
│
├── Data/                       # Доступ к данным
│   └── LibraryContext.cs      # DbContext + Fluent API + Seed Data
│
├── Migrations/                 # Файлы миграций EF Core
│   ├── 20260524082419_InitialCreate.cs
│   ├── 20260524095310_AddMoreAuthors.cs
│   └── LibraryContextModelSnapshot.cs
│
├── Models/                     # Модели сущностей
│   ├── Author.cs              # Автор книги
│   ├── Book.cs                # Книга библиотечного фонда
│   ├── Reader.cs              # Читатель (ученик/преподаватель)
│   ├── StorageLocation.cs     # Место хранения (помещение, стеллаж)
│   └── BookMovement.cs        # Запись о выдаче/перемещении
│
├── Validators/                 # Правила FluentValidation
│   ├── BookValidator.cs       # Валидация книги
│   └── ReaderValidator.cs     # Валидация читателя
│
├── Services/                   # Бизнес-логика (опционально)
│   ├── ILibraryService.cs
│   └── LibraryService.cs
│
├── Properties/
│   └── launchSettings.json    # Настройки запуска из IDE
│
├── wwwroot/                    # Статические файлы
│   ├── css/
│   │   └── app.css            # Глобальные стили
│   └── bootstrap/             # Bootstrap 5
│
├── appsettings.json           # Конфигурация (БД, настройки)
├── Program.cs                 # Точка входа, DI, миграции
├── Dockerfile                 # Multi-stage Docker-образ
├── docker-compose.yml         # Оркестрация: app + sqlserver
├── .env                       # Переменные окружения (не в Git)
├── .gitignore                 # Исключения для Git
└── README.md                  # Данная документация
```

---

## Быстрый старт

### Предварительные требования
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (рекомендуется) 
- [MS SQL Server LocalDB](https://learn.microsoft.com/ru-ru/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver17) (при локальном запуске) 
- [Git](https://git-scm.com/)

---

### Запуск через Docker (рекомендуемый способ)
Этот способ не требует установки .NET SDK и SQL Server на хост-машине.

#### Шаг 1: Клонирование репозитория
```bash
git clone https://github.com/Vadimenes/Finals_LLibrary.git
cd LLibrary
```
#### Шаг 2: Запуск контейнеров
```bash
docker-compose up --build
```

#### Шаг 3: Открыть приложение
🌐 Перейди в браузере: **`http://localhost:8009`**

---

## Схема базы данных

```
┌─────────────────────────────────────────────────────────────────────────────────────────────┐
│                              БАЗА ДАННЫХ LibraryDB                                          │
└─────────────────────────────────────────────────────────────────────────────────────────────┘

┌─────────────────────┐         ┌─────────────────────┐         ┌─────────────────────┐
│      AUTHORS        │         │        BOOKS        │         │      READERS        │
├────┬────────────────┤         ├────┬────────────────┤         ├────┬────────────────┤
│ PK │ AuthorId       │         │ PK │ BookId         │         │ PK │ ReaderId       │
├────┼────────────────┤         ├────┼────────────────┤         ├────┼────────────────┤
│    │ FirstName      │◄──1:N───│ FK │ AuthorId       │         │    │ FirstName      │
│    │ LastName       │         │    │ Title          │         │    │ LastName       │
│    │ BirthDate      │         │    │ ISBN (UNIQUE)  │         │    │ ClassNumber    │
└────┴────┬───────────┘         └────┴─────┬──────────┘         └────┴─────┬──────────┘
          │                                │                               │
          │                                │ BookId                        │ ReaderId
          │                                │ (FK)                          │ (FK)
          │                                │                               │
          │                                │ ┌─────────────────────────────┘
          │                                │ │
          │                                │ │ ┌────────────────────────────────────────────┐
          │                                │ │ │            STORAGE_LOCATIONS               │
          │                                │ │ ├────┬───────────────────────────────────────┤
          │                                │ │ │ PK │ LocationId                            │
          │                                │ │ ├────┼───────────────────────────────────────┤
          │                                │ │ │    │ Room                                  │
          │                                │ │ │    │ Shelf                                 │
          │                                │ │ └────┴───────────┬───────────────────────────┘
          │                                │ │                  │
          │                                │ │                  │ FromLocationId / ToLocationId
          │                                │ │                  │ (FK, nullable)
          │                                │ │                  │
          │                                │ │                  ▼
          │                                │ │ ┌────────────────────────────────────────────┐
          │                                │ │ │            BOOK_MOVEMENTS                  │
          │                                │ │ ├────┬───────────────────────────────────────┤
          │                                │ │ │ PK │ MovementId                            │
          │                                │ │ ├────┼───────────────────────────────────────┤
          │                                │ │ │ FK │ BookId ───────────────────────────────┤
          │                                │ │ │ FK │ ReaderId ─────────────────────────────┤
          │                                │ │ │ FK │ FromLocationId (nullable)             │
          │                                │ │ │ FK │ ToLocationId (nullable)               │
          │                                │ │ │    │ ActionDate                            │
          │                                │ │ │    │ IsReturned (bool)                     │
          │                                │ │ └────┴───────────────────────────────────────┘
          │                                │ │
          ▼                                │ │
┌─────────────────────┐                    │ │
│   BOOK_MOVEMENTS    │◄───────────────────┘ │
│ (журнал выдачи)     │                      │
├────┬────────────────┤                      │
│    │ Cascade delete │◄─────────────────────┘
│    │ при удалении   │
│    │ книги          │
└────┴────────────────┘

УНИКАЛЬНЫЙ ИНДЕКС: Books.ISBN
ПОВЕДЕНИЕ ПРИ УДАЛЕНИИ:
  • Book → BookMovement: CASCADE
  • Reader → BookMovement: SET NULL
  • Author → Book: CASCADE
```

🔗 **Репозиторий:** https://github.com/Vadimenes/Finals_LLibrary.git

🐳 **Docker Hub:** https://hub.docker.com/r/vadimenes/school-library
