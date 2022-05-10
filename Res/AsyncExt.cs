using System;
using System.Threading.Tasks;

namespace ComradeVanti.CSharpTools
{

    public static class AsyncExt
    {

        /// <summary>
        ///     Applies an asynchronous mapping function to the result
        /// </summary>
        /// <param name="res">The result</param>
        /// <param name="f">The mapping function</param>
        /// <typeparam name="TValue">The success type</typeparam>
        /// <typeparam name="TError">The error type</typeparam>
        /// <typeparam name="TMapped">The mapped success type</typeparam>
        /// <returns>A task with the mapped result</returns>
        public static Task<Res<TMapped, TError>> MapAsync<TValue, TError, TMapped>(
            this Res<TValue, TError> res,
            Func<TValue, Task<TMapped>> f) =>
            res.Match(it => f(it).Map(Res.Ok<TMapped, TError>),
                      err => Task.FromResult(Res.Fail<TMapped, TError>(err)));

        /// <summary>
        ///     Applies an asynchronous error-mapping function to the result
        /// </summary>
        /// <param name="res">The result</param>
        /// <param name="f">The mapping function</param>
        /// <typeparam name="TValue">The success type</typeparam>
        /// <typeparam name="TError">The error type</typeparam>
        /// <typeparam name="TMapped">The mapped success type</typeparam>
        /// <returns>A task with the mapped result</returns>
        public static Task<Res<TValue, TMapped>> MapErrorAsync<TValue, TError, TMapped>(
            this Res<TValue, TError> res,
            Func<TError, Task<TMapped>> f) =>
            res.Match(it => Task.FromResult(Res.Ok<TValue, TMapped>(it)),
                      err => f(err).Map(Res.Fail<TValue, TMapped>));

        /// <summary>
        ///     Applies an asynchronous binding function to the result
        /// </summary>
        /// <param name="res">The result</param>
        /// <param name="f">The binding function</param>
        /// <typeparam name="TValue">The success type</typeparam>
        /// <typeparam name="TError">The error type</typeparam>
        /// <typeparam name="TMapped">The mapped success type</typeparam>
        /// <returns>A task with the mapped result</returns>
        public static Task<Res<TMapped, TError>> BindAsync<TValue, TError, TMapped>(
            this Res<TValue, TError> res,
            Func<TValue, Task<Res<TMapped, TError>>> f) =>
            res.Match(f, err => Task.FromResult(Res.Fail<TMapped, TError>(err)));

    }

}