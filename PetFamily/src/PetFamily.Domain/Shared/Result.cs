using System;

namespace PetFamily.Domain.Shared;

public class Result
{
    // Защищаем свойства от изменений извне (только для чтения)
    public string? Error { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    protected Result(bool isSuccess, string? error)
    {
        // Проверяем входящий параметр isSuccess (с маленькой буквы)
        if (isSuccess && error is not null)
        {
            throw new InvalidOperationException("Success result cannot have an error message.");
        }

        // Проверяем входящий параметр isSuccess
        if (isSuccess == false && error is null)
        {
            throw new InvalidOperationException("Failure result must have an error message.");
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, null);
    public static Result Failure(string error) => new(false, error);
    
    // Неявное преобразование строки в ошибку (очень удобно в хендлерах)
    public static implicit operator Result(string error) => new(false, error);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;
 
    // Конструктор для успеха
    private Result(TValue value) : base(true, null)
    {
        _value = value;
    }

    // Конструктор для ошибки
    private Result(string error) : base(false, error)
    {
        _value = default;
    }

    // Проверка на IsSuccess защищает от чтения дефолтного/сломанного значения
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result cannot be accessed.");
    
    public static Result<TValue> Success(TValue value) => new(value);
    
    // Используем ключевое слово 'new', так как перекрываем статичный метод базового класса
    public new static Result<TValue> Failure(string error) => new(error);

    // Умные операторы приведения типов (делают код чище в return)
    public static implicit operator Result<TValue>(TValue value) => new(value);
    public static implicit operator Result<TValue>(string error) => new(error);
}
