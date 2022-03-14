using System;

namespace ComradeVanti.CSharpTools
{

    /// <summary>
    ///     A result of an operation which may either result in a value or an error
    /// </summary>
    /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
    /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
    public abstract class Res<TOk, TFail>
    {

        public override bool Equals(object obj)
        {
            switch (this)
            {
                case Ok ok1 when obj is Ok ok2:
                    return Equals(ok1.Value, ok2.Value);
                case Fail fail1 when obj is Fail fail2:
                    return Equals(fail1.Error, fail2.Error);
                default:
                    return false;
            }
        }

        public override int GetHashCode()
        {
            switch (this)
            {
                case Ok ok:
                    return ok.Value.GetHashCode();
                case Fail fail:
                    return fail.Error.GetHashCode();
                default:
                    throw new Exception("Invalid type"); // Here for the compiler. Should never happen
            }
        }


        internal sealed class Ok : Res<TOk, TFail>
        {

            public TOk Value { get; }


            public Ok(TOk value) =>
                Value = value;

            public override string ToString() =>
                $"Ok ({Value.ToString()})";

        }

        internal sealed class Fail : Res<TOk, TFail>
        {

            public TFail Error { get; }


            public Fail(TFail error) =>
                Error = error;


            public override string ToString() =>
                $"Fail ({Error.ToString()})";

        }

    }

}