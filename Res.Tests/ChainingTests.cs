using FsCheck.Xunit;

namespace ComradeVanti.CSharpTools;

public class ChainingTests
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

}