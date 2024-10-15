using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Ametrin.Guard;

public static class Guard
{
    [StackTraceHidden]
    public static T ThrowIfNull<T>(T? value, [CallerArgumentExpression(nameof(value))] string valueExpression = "") where T : class
        => value is null ? throw new ArgumentNullException(valueExpression) : value;

    public static T ThrowIfNullOrEmpty<T>(T? collection, [CallerArgumentExpression(nameof(collection))] string valueExpression = "") where T : System.Collections.IEnumerable 
        => collection is not null && collection.GetEnumerator().MoveNext() ? collection : throw new ArgumentNullException(valueExpression);


    [StackTraceHidden]
    public static string ThrowIfNullOrEmpty(string? value, [CallerArgumentExpression(nameof(value))] string valueExpression = "")
        => string.IsNullOrEmpty(value) ? throw new ArgumentNullException(valueExpression) : value;

    [StackTraceHidden]
    public static string ThrowIfNullOrWhiteSpace(string? value, [CallerArgumentExpression(nameof(value))] string valueExpression = "")
        => string.IsNullOrWhiteSpace(value) ? throw new ArgumentNullException(valueExpression) : value;
}