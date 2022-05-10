using System;
using System.Threading.Tasks;

namespace ComradeVanti.CSharpTools
{

    public static class TaskExt
    {

        internal static async Task<TMapped> Map<TValue, TMapped>(this Task<TValue> task, Func<TValue, TMapped> f)
        {
            var v = await task;
            return f(v);
        }

        internal static async Task<TMapped> Bind<TValue, TMapped>(this Task<TValue> task, Func<TValue, Task<TMapped>> f)
        {
            var v = await task;
            return await f(v);
        }


        /// <summary>
        ///     Converts this task to a task which returns a result
        /// </summary>
        /// <param name="task">The task</param>
        /// <param name="makeError">A function for converting exceptions into errors</param>
        /// <typeparam name="TValue">The type of the tasks success-value</typeparam>
        /// <typeparam name="TError">The type of the error</typeparam>
        /// <returns>The new task</returns>
        internal static async Task<Res<TValue, TError>> ToAsyncRes<TValue, TError>(
            this Task<TValue> task,
            Func<Exception, TError> makeError)
        {
            try
            {
                var value = await task;
                return value;
            }
            catch (Exception e)
            {
                var err = makeError(e);
                return err;
            }
        }

        /// <summary>
        ///     Apply a mapping function to the result of this task
        /// </summary>
        /// <param name="task">The task</param>
        /// <param name="f">The mapping function</param>
        /// <typeparam name="TValue">The type of the results success</typeparam>
        /// <typeparam name="TError">The type of the results error</typeparam>
        /// <typeparam name="TMapped">The type of the mapped results success</typeparam>
        /// <returns>A task with the mapped result</returns>
        internal static Task<Res<TMapped, TError>> MapAsyncRes<TValue, TError, TMapped>(
            this Task<Res<TValue, TError>> task,
            Func<TValue, TMapped> f) =>
            task.Map(res => res.Map(f));

        /// <summary>
        ///     Apply a error-mapping function to the result of this task
        /// </summary>
        /// <param name="task">The task</param>
        /// <param name="f">The mapping function</param>
        /// <typeparam name="TValue">The type of the results success</typeparam>
        /// <typeparam name="TError">The type of the results error</typeparam>
        /// <typeparam name="TMapped">The type of the mapped results error</typeparam>
        /// <returns>A task with the mapped result</returns>
        internal static Task<Res<TValue, TMapped>> MapAsyncResError<TValue, TError, TMapped>(
            this Task<Res<TValue, TError>> task,
            Func<TError, TMapped> f) =>
            task.Map(res => res.MapError(f));

        /// <summary>
        ///     Apply a binding function to the result of this task
        /// </summary>
        /// <param name="task">The task</param>
        /// <param name="f">The binding function</param>
        /// <typeparam name="TValue">The type of the results success</typeparam>
        /// <typeparam name="TError">The type of the results error</typeparam>
        /// <typeparam name="TMapped">The type of the mapped results success</typeparam>
        /// <returns>A task with the mapped result</returns>
        internal static Task<Res<TMapped, TError>> BindAsyncRes<TValue, TError, TMapped>(
            this Task<Res<TValue, TError>> task,
            Func<TValue, Res<TMapped, TError>> f) =>
            task.Map(res => res.Bind(f));

        /// <summary>
        ///     Apply an async binding function to the result of this task
        /// </summary>
        /// <param name="task">The task</param>
        /// <param name="f">The binding function</param>
        /// <typeparam name="TValue">The type of the results success</typeparam>
        /// <typeparam name="TError">The type of the results error</typeparam>
        /// <typeparam name="TMapped">The type of the mapped results success</typeparam>
        /// <returns>A task with the mapped result</returns>
        internal static Task<Res<TMapped, TError>> BindAsyncResAsync<TValue, TError, TMapped>(
            this Task<Res<TValue, TError>> task,
            Func<TValue, Task<Res<TMapped, TError>>> f) =>
            task.Bind(res => res.BindAsync(f));

    }

}