using System;
using System.Collections.Generic;

namespace ComradeVanti.CSharpTools
{
    /// <summary>
    ///     A result of an operation which may either result in a value or an error
    /// </summary>
    /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
    /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
    public abstract record Res<TOk, TFail>
    {
        public static implicit operator Res<TOk, TFail>(TOk value) =>
            Res.Ok<TOk, TFail>(value);

        public static implicit operator Res<TOk, TFail>(TFail error) =>
            Res.Fail<TOk, TFail>(error);
    }

    public sealed record Ok<TOk, TFail>(TOk Value) : Res<TOk, TFail>
    {
        public override string ToString() =>
            $"Ok ({Value?.ToString()})";
    }

    public sealed record Fail<TOk, TFail>(TFail Error) : Res<TOk, TFail>
    {
        public override string ToString() =>
            $"Fail ({Error?.ToString()})";
    }
}