# res

[![Nuget](https://img.shields.io/nuget/v/ComradeVanti.CSharpTools.Res)](https://www.nuget.org/packages/ComradeVanti.CSharpTools.Res)  
A C# library that mimics F#'s results. Since the functionality and in most cases
even the method names are directly taken from F#, go check
out [the documentation there](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-resultmodule.html)
for details.

[Changelog](https://github.com/ComradeVanti/res-csharp/blob/main/CHANGELOG.md)

## Features

Methods for creating results are located on the `Res` class. Methods like `Map`
or `Bind` are available as extension methods on `Res` instances for easy
chaining.

`Res` are immutable reference-types. They are compared using equality even when
using `==`.

### Result instantiation

- Ok
- Fail
- FromOp

### Result extension methods

- IsOk
- IsFail
- Match (for functions and actions)
- Bind
- Map
- MapError