using System;

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
        /// <typeparam name="TValue">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TError">The type of the error if the results is a failure</typeparam>
        /// <returns>The result</returns>
        public static Res<TValue, TError> Ok<TValue, TError>(TValue value) =>
            new Ok<TValue, TError>(value);

        /// <summary>
        ///     Creates a failed result
        /// </summary>
        /// <param name="error">The error to be stored in the result</param>
        /// <typeparam name="TValue">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TError">The type of the error if the results is a failure</typeparam>
        /// <returns>The result</returns>
        public static Res<TValue, TError> Fail<TValue, TError>(TError error) =>
            new Fail<TValue, TError>(error);

        /// <summary>
        ///     Creates a results from executing a function. If the function returns
        ///     without issue the result is ok, if it throws an exception the result is a
        ///     fail
        /// </summary>
        /// <param name="op">The operation</param>
        /// <param name="exnMapper">A function for mapping the exception</param>
        /// <typeparam name="TValue">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TError">The type of the error if the results is a failure</typeparam>
        /// <returns>The result</returns>
        public static Res<TValue, TError> FromOp<TValue, TError>(Func<TValue> op, Func<Exception, TError> exnMapper)
        {
            try
            {
                return Ok<TValue, TError>(op());
            }
            catch (Exception e)
            {
                return Fail<TValue, TError>(exnMapper(e));
            }
        }

        /// <summary>
        ///     Creates a results from executing a function. If the function returns
        ///     without issue the result is ok, if it throws an exception the result is a
        ///     fail
        /// </summary>
        /// <param name="op">The operation</param>
        /// <typeparam name="TValue">The type of the value if the result is ok</typeparam>
        /// <returns>The result</returns>
        public static Res<TValue, Exception> FromOp<TValue>(Func<TValue> op)
        {
            try
            {
                return Ok<TValue, Exception>(op());
            }
            catch (Exception e)
            {
                return Fail<TValue, Exception>(e);
            }
        }
    }
}