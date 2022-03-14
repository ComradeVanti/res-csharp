namespace ComradeVanti.CSharpTools
{

    public static class QueryExt
    {

        /// <summary>
        ///     Checks if a result is ok
        /// </summary>
        /// <param name="res">The result</param>
        /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
        /// <returns>Whether the result is ok</returns>
        public static bool IsOk<TOk, TFail>(this Res<TOk, TFail> res) =>
            res is Res<TOk, TFail>.Ok;

        /// <summary>
        ///     Checks if a result is a failure
        /// </summary>
        /// <param name="res">The result</param>
        /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
        /// <returns>Whether the result is a failure</returns>
        public static bool IsFail<TOk, TFail>(this Res<TOk, TFail> res) =>
            res is Res<TOk, TFail>.Fail;

    }

}