using System;
using System.Collections.Generic;

namespace ComradeVanti.CSharpTools
{
    /// <summary>
    ///     A result of an operation which may either result in a value or an error
    /// </summary>
    /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
    /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
    public abstract class Res<TOk, TFail>
    {
        public override bool Equals(object? obj)
        {
            return this switch
            {
                Ok ok1 when obj is Ok ok2 => Equals(ok1.Value, ok2.Value),
                Fail fail1 when obj is Fail fail2 => Equals(fail1.Error, fail2.Error),
                _ => false
            };
        }

        public override int GetHashCode()
        {
            return this switch
            {
                Ok ok => EqualityComparer<TOk>.Default.GetHashCode(ok.Value),
                Fail fail => EqualityComparer<TFail>.Default.GetHashCode(fail.Error),
                _ => throw new Exception("Invalid type")
            };
        }


        public static implicit operator Res<TOk, TFail>(TOk value) =>
            Res.Ok<TOk, TFail>(value);

        public static implicit operator Res<TOk, TFail>(TFail error) =>
            Res.Fail<TOk, TFail>(error);

        public static bool operator ==(Res<TOk, TFail> res1, Res<TOk, TFail> res2) =>
            Equals(res1, res2);

        public static bool operator !=(Res<TOk, TFail> res1, Res<TOk, TFail> res2) =>
            !Equals(res1, res2);

        internal sealed class Ok : Res<TOk, TFail>
        {
            public TOk Value { get; }


            public Ok(TOk value) =>
                Value = value;

            public override string ToString() =>
                $"Ok ({Value?.ToString()})";
        }

        internal sealed class Fail : Res<TOk, TFail>
        {
            public TFail Error { get; }


            public Fail(TFail error) =>
                Error = error;


            public override string ToString() =>
                $"Fail ({Error?.ToString()})";
        }
    }
}