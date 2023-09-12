using System;
using System.Collections.Generic;

namespace ComradeVanti.CSharpTools
{
    /// <summary>
    ///     A result of an operation which may either result in a value or an error
    /// </summary>
    /// <typeparam name="TValue">The type of the value if the result is ok</typeparam>
    /// <typeparam name="TError">The type of the error if the results is a failure</typeparam>
    public abstract record Res<TValue, TError>
    {
        public static implicit operator Res<TValue, TError>(TValue value) =>
            Res.Ok<TValue, TError>(value);

        public static implicit operator Res<TValue, TError>(TError error) =>
            Res.Fail<TValue, TError>(error);
    }

    public sealed record Ok<TValue, TError>(TValue Value) : Res<TValue, TError>
    {
        public override string ToString() =>
            $"Ok ({Value?.ToString()})";
    }

    public sealed record Fail<TValue, TError>(TError Error) : Res<TValue, TError>
    {
        public override string ToString() =>
            $"Fail ({Error?.ToString()})";
    }
}