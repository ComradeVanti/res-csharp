using System;

namespace ComradeVanti.CSharpTools
{

    public static class Ext
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

        /// <summary>
        ///     Executes one of two actions depending on if the result is ok or a failure
        /// </summary>
        /// <param name="res">The result</param>
        /// <param name="okAction">The action to execute if the result it ok</param>
        /// <param name="failAction">The action to execute if the result is a failure</param>
        /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
        public static void Match<TOk, TFail>(this Res<TOk, TFail> res, Action<TOk> okAction, Action<TFail> failAction)
        {
            switch (res)
            {
                case Res<TOk, TFail>.Ok ok:
                    okAction(ok.Value);
                    break;
                case Res<TOk, TFail>.Fail fail:
                    failAction(fail.Error);
                    break;
            }
        }

        /// <summary>
        ///     Executes one of two functions depending on if the result is ok or a failure
        ///     and returns the result
        /// </summary>
        /// <param name="res">The result</param>
        /// <param name="okF">The function to execute if the result it ok</param>
        /// <param name="failF">The function to execute if the result is a failure</param>
        /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
        /// <typeparam name="TOut">The type of the function output</typeparam>
        /// <returns>The output of the executed function</returns>
        public static TOut Match<TOk, TFail, TOut>(this Res<TOk, TFail> res, Func<TOk, TOut> okF, Func<TFail, TOut> failF)
        {
            switch (res)
            {
                case Res<TOk, TFail>.Ok ok:
                    return okF(ok.Value);
                case Res<TOk, TFail>.Fail fail:
                    return failF(fail.Error);
                default:
                    // This should never happen
                    throw new InvalidOperationException("Result invalid!");
            }
        }

    }

}