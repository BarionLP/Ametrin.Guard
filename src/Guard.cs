﻿using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Ametrin.Guard;

public static class Guard
{
    [StackTraceHidden]
    public static T ThrowIfNull<T>(T? value, [CallerArgumentExpression(nameof(value))] string expression = "") where T : class
        => value is null ? throw new ArgumentNullException(expression) : value;

    [StackTraceHidden]
    public static T Is<T>(object? value, [CallerArgumentExpression(nameof(value))] string expression = "")
        => value is null ? throw new ArgumentNullException(expression) : value is T t ? t : throw new InvalidCastException($"Unable to cast object of type '{value.GetType().FullName}' to type '{typeof(T).FullName}'");

    [StackTraceHidden]
    public static T ThrowIfNullOrEmpty<T>(T? collection, [CallerArgumentExpression(nameof(collection))] string expression = "") where T : System.Collections.IEnumerable
        => collection is not null && collection.GetEnumerator().MoveNext() ? collection : throw new ArgumentNullException(expression);


    [StackTraceHidden]
    public static string ThrowIfNullOrEmpty(string? value, [CallerArgumentExpression(nameof(value))] string expression = "")
        => string.IsNullOrEmpty(value) ? throw new ArgumentNullException(expression) : value;

    [StackTraceHidden]
    public static string ThrowIfNullOrWhiteSpace(string? value, [CallerArgumentExpression(nameof(value))] string expression = "")
        => string.IsNullOrWhiteSpace(value) ? throw new ArgumentNullException(expression) : value;

    [StackTraceHidden]
    public static T InRange<T>(T value, T minInclusive, T maxInclusive, [CallerArgumentExpression(nameof(value))] string expression = "")
        where T : notnull, IComparisonOperators<T, T, bool>
        => value < minInclusive || value > maxInclusive ? throw new ArgumentOutOfRangeException(expression) : value;
}