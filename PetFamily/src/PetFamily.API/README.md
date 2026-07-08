Создание миграции. 
Initial - название
-p .\PetFamily.Infrastructure\ - --project ${путь к проекту в котором создаем миграцию}
-s .\PetFamily.API\ - --startup-project ${путь к проекту который будет главным для запуска}
dotnet ef migrations add Initial -p .\PetFamily.Infrastructure\ -s .\PetFamily.API\

Накатывание миграции на БД.
update - обновить
-p .\PetFamily.Infrastructure\ - --project ${путь к проекту в котором создаем миграцию}
-s .\PetFamily.API\ - --startup-project ${путь к проекту который будет главным для запуска}
dotnet ef database update -p .\PetFamily.Infrastructure\ -s .\PetFamily.API\

Создание скрипта миграций.
script - создать скрипт
-p .\PetFamily.Infrastructure\ - --project ${путь к проекту в котором создаем миграцию}
-s .\PetFamily.API\ - --startup-project ${путь к проекту который будет главным для запуска}
dotnet ef migrations script -p .\PetFamily.Infrastructure\ -s .\PetFamily.API\