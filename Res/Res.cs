namespace ComradeVanti.CSharpTools
{

    /// <summary>
    ///     Contains methods for instantiating results
    /// </summary>
    public static class Res
    {

        /// <summary>
        ///     Creates an ok result
        /// </summary>
        /// <param name="value">The value to be stored in the result</param>
        /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
        /// <returns>The result</returns>
        public static Res<TOk, TFail> Ok<TOk, TFail>(TOk value) =>
            new Res<TOk, TFail>.Ok(value);

        /// <summary>
        ///     Creates a failed result
        /// </summary>
        /// <param name="error">The error to be stored in the result</param>
        /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
        /// <returns>The result</returns>
        public static Res<TOk, TFail> Fail<TOk, TFail>(TFail error) =>
            new Res<TOk, TFail>.Fail(error);

    }

}