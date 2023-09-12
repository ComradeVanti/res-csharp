using System;

namespace ComradeVanti.CSharpTools
{
    public static class MappingExt
    {
        /// <summary>
        ///     Executes one of two actions depending on if the result is ok or a failure
        /// </summary>
        /// <param name="res">The result</param>
        /// <param name="okAction">The action to execute if the result it ok</param>
        /// <param name="failAction">The action to execute if the result is a failure</param>
        /// <typeparam name="TValue">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TError">The type of the error if the results is a failure</typeparam>
        public static void Match<TValue, TError>(this Res<TValue, TError> res, Action<TValue> okAction, Action<TError> failAction)
        {
            switch (res)
            {
                case Ok<TValue, TError> ok:
                    okAction(ok.Value);
                    break;
                case Fail<TValue, TError> fail:
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
        /// <typeparam name="TValue">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TError">The type of the error if the results is a failure</typeparam>
        /// <typeparam name="TOut">The type of the function output</typeparam>
        /// <returns>The output of the executed function</returns>
        public static TOut Match<TValue, TError, TOut>(this Res<TValue, TError> res, Func<TValue, TOut> okF, Func<TError, TOut> failF)
        {
            return res switch
            {
                Ok<TValue, TError> ok => okF(ok.Value),
                Fail<TValue, TError> fail => failF(fail.Error),
                _ => throw new InvalidOperationException("Result invalid!")
            };
        }

        /// <summary>
        ///     Applies the given function to the results value if present and returns the
        ///     output
        /// </summary>
        /// <param name="res">The result</param>
        /// <param name="bindF">The binding function</param>
        /// <typeparam name="TValue">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TError">The type of the error if the results is a failure</typeparam>
        /// <typeparam name="TMapped">The type of the mapped value</typeparam>
        /// <returns>The mapped result</returns>
        public static Res<TMapped, TError> Bind<TValue, TError, TMapped>(this Res<TValue, TError> res, Func<TValue, Res<TMapped, TError>> bindF) =>
            res.Match(bindF, Res.Fail<TMapped, TError>);

        /// <summary>
        ///     Applies the given function to the results value if present and returns the
        ///     output in a new result
        /// </summary>
        /// <param name="res">The result</param>
        /// <param name="mapF">The mapping function</param>
        /// <typeparam name="TValue">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TError">The type of the error if the results is a failure</typeparam>
        /// <typeparam name="TMapped">The type of the mapped value</typeparam>
        /// <returns>The mapped result</returns>
        public static Res<TMapped, TError> Map<TValue, TError, TMapped>(this Res<TValue, TError> res, Func<TValue, TMapped> mapF) =>
            res.Match(it => Res.Ok<TMapped, TError>(mapF(it)),
                Res.Fail<TMapped, TError>);

        /// <summary>
        ///     Applies the given function to the results error if present and returns the
        ///     output in a new result
        /// </summary>
        /// <param name="res">The result</param>
        /// <param name="mapF">The mapping function</param>
        /// <typeparam name="TValue">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TError">The type of the error if the results is a failure</typeparam>
        /// <typeparam name="TMapped">The type of the mapped value</typeparam>
        /// <returns>The mapped result</returns>
        public static Res<TValue, TMapped> MapError<TValue, TError, TMapped>(this Res<TValue, TError> res, Func<TError, TMapped> mapF) =>
            res.Match(Res.Ok<TValue, TMapped>,
                it => Res.Fail<TValue, TMapped>(mapF(it)));
    }
}