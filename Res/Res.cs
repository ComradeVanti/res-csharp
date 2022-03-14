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

        /// <summary>
        ///     Creates a results from executing a function. If the function returns
        ///     without issue the result is ok, if it throws an exception the result is a
        ///     fail
        /// </summary>
        /// <param name="op">The operation</param>
        /// <param name="exnMapper">A function for mapping the exception</param>
        /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
        /// <typeparam name="TFail">The type of the error if the results is a failure</typeparam>
        /// <returns>The result</returns>
        public static Res<TOk, TFail> FromOp<TOk, TFail>(Func<TOk> op, Func<Exception, TFail> exnMapper)
        {
            try
            {
                return Ok<TOk, TFail>(op());
            }
            catch (Exception e)
            {
                return Fail<TOk, TFail>(exnMapper(e));
            }
        }

        /// <summary>
        ///     Creates a results from executing a function. If the function returns
        ///     without issue the result is ok, if it throws an exception the result is a
        ///     fail
        /// </summary>
        /// <param name="op">The operation</param>
        /// <typeparam name="TOk">The type of the value if the result is ok</typeparam>
        /// <returns>The result</returns>
        public static Res<TOk, Exception> FromOp<TOk>(Func<TOk> op)
        {
            try
            {
                return Ok<TOk, Exception>(op());
            }
            catch (Exception e)
            {
                return Fail<TOk, Exception>(e);
            }
        }

    }

}