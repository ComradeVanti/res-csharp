using FsCheck.Xunit;

namespace ComradeVanti.CSharpTools;

public class MappingTests
{

    [Property]
    public bool Match_Executes_Correct_Branch(Res<int, string> res)
    {
        var executedCorrect = false;

        res.Match(
            _ => { executedCorrect = res.IsOk(); },
            _ => { executedCorrect = res.IsFail(); });

        return executedCorrect;
    }

    [Property]
    public bool Match_For_Result_Executes_Correct_Branch(Res<int, string> res) =>
        res.Match(_ => res.IsOk(),
                  _ => res.IsFail());

    [Property]
    public bool Bind_Failure_With_Ok_Function_Is_Original_Failure(string error) =>
        Res.Fail<int, string>(error)
           .Bind(it => Res.Ok<int, string>(it * 2))
           .Match(_ => false,
                  e => e == error);

    [Property]
    public bool Bind_Failure_With_Fail_Function_Is_Original_Failure(string error) =>
        Res.Fail<int, string>(error)
           .Bind(_ => Res.Fail<int, string>(error + error))
           .Match(_ => false,
                  e => e == error);

    [Property]
    public bool Bind_Ok_With_Fail_Function_Is_Fail(int value) =>
        Res.Ok<int, string>(value)
           .Bind(_ => Res.Fail<int, string>("Oh no"))
           .Match(_ => false,
                  e => e == "Oh no");

    [Property]
    public bool Bind_Ok_With_Ok_Function_Is_Ok(int value) =>
        Res.Ok<int, string>(value)
           .Bind(it => Res.Ok<int, string>(it * 2))
           .Match(it => it == value * 2,
                  _ => false);

    [Property]
    public bool Map_Failure_Is_Original_Failure(string error) =>
        Res.Fail<int, string>(error)
           .Map(it => it * 2)
           .Match(_ => false,
                  e => e == error);

    [Property]
    public bool Map_Ok_Is_Mapped_Ok(int value) =>
        Res.Ok<int, string>(value)
           .Map(it => it * 2)
           .Match(it => it == value * 2,
                  _ => false);

    [Property]
    public bool MapError_Failure_Is_Mapped_Failure(string error) =>
        Res.Fail<int, string>(error)
           .MapError(it => it + it)
           .Match(_ => false,
                  it => it == error + error);

    [Property]
    public bool MapError_Ok_Is_Original_Ok(int value) =>
        Res.Ok<int, string>(value)
           .MapError(it => it + it)
           .Match(it => it == value,
                  _ => false);

}