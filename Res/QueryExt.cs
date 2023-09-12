namespace ComradeVanti.CSharpTools
{
    public static class QueryExt
    {
        /// <summary>
        ///     Checks if a result is ok
        /// </summary>
        /// <param name="res">The result</param>
        /// <typeparam name="TValue">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TError">The type of the error if the results is a failure</typeparam>
        /// <returns>Whether the result is ok</returns>
        public static bool IsOk<TValue, TError>(this Res<TValue, TError> res) =>
            res is Ok<TValue, TError>;

        /// <summary>
        ///     Checks if a result is a failure
        /// </summary>
        /// <param name="res">The result</param>
        /// <typeparam name="TValue">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TError">The type of the error if the results is a failure</typeparam>
        /// <returns>Whether the result is a failure</returns>
        public static bool IsFail<TValue, TError>(this Res<TValue, TError> res) =>
            res is Fail<TValue, TError>;
    }
}