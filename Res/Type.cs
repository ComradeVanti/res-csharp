namespace ComradeVanti.CSharpTools
{

    /// <summary>
    ///     A result of an operation which may either result in a value or an error
    /// </summary>
    /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
    /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
    public abstract class Res<TOk, TFail>
    {

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