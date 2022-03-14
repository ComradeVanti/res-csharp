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

        /// <summary>
        ///     Applies the given function to the results value if present and returns the
        ///     output
        /// </summary>
        /// <param name="res">The result</param>
        /// <param name="bindF">The binding function</param>
        /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
        /// <typeparam name="TMapped">The type of the mapped value</typeparam>
        /// <returns>The mapped result</returns>
        public static Res<TMapped, TFail> Bind<TOk, TFail, TMapped>(this Res<TOk, TFail> res, Func<TOk, Res<TMapped, TFail>> bindF) =>
            res.Match(bindF, Res.Fail<TMapped, TFail>);

        /// <summary>
        ///     Applies the given function to the results value if present and returns the
        ///     output in a new result
        /// </summary>
        /// <param name="res">The result</param>
        /// <param name="mapF">The mapping function</param>
        /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
        /// <typeparam name="TMapped">The type of the mapped value</typeparam>
        /// <returns>The mapped result</returns>
        public static Res<TMapped, TFail> Map<TOk, TFail, TMapped>(this Res<TOk, TFail> res, Func<TOk, TMapped> mapF) =>
            res.Match(it => Res.Ok<TMapped, TFail>(mapF(it)),
                      Res.Fail<TMapped, TFail>);

        /// <summary>
        ///     Applies the given function to the results error if present and returns the
        ///     output in a new result
        /// </summary>
        /// <param name="res">The result</param>
        /// <param name="mapF">The mapping function</param>
        /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
        /// <typeparam name="TMapped">The type of the mapped value</typeparam>
        /// <returns>The mapped result</returns>
        public static Res<TOk, TMapped> MapError<TOk, TFail, TMapped>(this Res<TOk, TFail> res, Func<TFail, TMapped> mapF) =>
            res.Match(Res.Ok<TOk, TMapped>,
                      it => Res.Fail<TOk, TMapped>(mapF(it)));

    }

}