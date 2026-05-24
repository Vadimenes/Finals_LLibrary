# Школьная Библиотека — Курсовой проект

Веб-приложение для учёта книг, читателей и выдачи литературы в школе.

## Технологии
- .NET 8.0
- ASP.NET Core Blazor Server
- Entity Framework Core (Code First)
- SQL Server
- Docker / Docker Compose
- FluentValidation

## Запуск локально (Visual Studio)
1. Откройте решение `LibraryPZ3.sln`.
2. Убедитесь, что установлен SQL Server LocalDB.
3. Выполните миграции в Package Manager Console:
   ```powershell
   Update-Database
