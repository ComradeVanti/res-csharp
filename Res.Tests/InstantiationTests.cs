using System;
using FsCheck.Xunit;

namespace ComradeVanti.CSharpTools;

public class InstantiationTests
{

    [Property]
    public bool Res_Created_From_Successful_Op_Is_Ok(int i) =>
        Res.FromOp(() => i, _ => "")
           .Match(it => it == i,
                  _ => false);

    [Property]
    public bool Res_Created_From_Failed_Op_Is_Fail(string e) =>
        Res.FromOp<int, string>(() => throw new Exception(), _ => e)
           .Match(_ => false,
                  it => it == e);

}