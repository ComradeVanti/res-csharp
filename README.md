# Res

[![Nuget](https://img.shields.io/nuget/v/ComradeVanti.CSharpTools.Res)](https://www.nuget.org/packages/ComradeVanti.CSharpTools.Res)  
A C# library that mimics F#'s results. Since the functionality and in most cases
even the method names are directly taken from F#, go check
out [the documentation there](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-resultmodule.html)
for details.

[Changelog](https://github.com/ComradeVanti/res-csharp/blob/main/CHANGELOG.md)

**⚠️ Development is paused ⚠️**  
No new features will be added or bugs fixed unless requested through an issue.  
If you wish to fork this repository and continue the work, you are very welcome
to do so.

## Features

Methods for creating results are located on the `Res` class. Values can also be
implicitly cast to `Res` instances. Methods like `Map`
or `Bind` are available as extension methods on `Res` instances for easy
chaining.

`Res` are immutable reference-types. They are compared using equality even when
using `==`.

### Result instantiation

- Ok
- Fail
- FromOp

Success and Fail results may also be implicitly cast from their containing
values like this
`Res<int, string> res = 0`

### Result extension methods

- IsOk
- IsFail
- Match (for functions and actions)
- Bind
- Map
- MapError

### Async mapping

There are also async versions of

- Map
- Bind
- MapError

They are found by simply adding "Async" to the end of the method-name

There are also extension methods for `Task<Res<_,_>>` such as

- MapAsyncRes
- MapAsyncResError
- BindAsyncRes
- BindAsyncResAsync
