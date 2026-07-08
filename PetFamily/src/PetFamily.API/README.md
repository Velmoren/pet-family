# Конфигурация EF Core

1. Строка / число / дата ➡️ Property() + IsRequired() + HasMaxLength().
2. Value Object из одного поля (Id, Phone) ➡️ Property() + HasConversion().
3. Value Object из многих полей (Address) ➡️ ComplexProperty().
4. Список объектов без своего ID (храним в одной ячейке) ➡️ OwnsMany() + ToJson().
5. Связь с другой таблицей (Один-ко-многим) ➡️ HasMany().WithOne().HasForeignKey().

# Миграции
## Создание миграции.
>Initial - название
> 
> -p .\PetFamily.Infrastructure\ - --project ${путь к проекту в котором создаем миграцию}
> 
> -s .\PetFamily.API\ - --startup-project ${путь к проекту который будет главным для запуска}
```
dotnet ef migrations add Initial -p .\PetFamily.Infrastructure\ -s .\PetFamily.API\
```
## Накатывание миграции.
>update - обновить
> 
>-p .\PetFamily.Infrastructure\ - --project ${путь к проекту в котором создаем миграцию}
>
>-s .\PetFamily.API\ - --startup-project ${путь к проекту который будет главным для запуска}
```
dotnet ef database update -p .\PetFamily.Infrastructure\ -s .\PetFamily.API\
```
## Создание скрипта миграций.
>script - создать скрипт
> 
>-p .\PetFamily.Infrastructure\ - --project ${путь к проекту в котором создаем миграцию}
>
>-s .\PetFamily.API\ - --startup-project ${путь к проекту который будет главным для запуска}
```
dotnet ef migrations script -p .\PetFamily.Infrastructure\ -s .\PetFamily.API\
```