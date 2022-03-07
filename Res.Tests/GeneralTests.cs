using FsCheck.Xunit;

namespace ComradeVanti.CSharpTools;

public class GeneralTests
{

    [Property]
    public bool Results_Can_Not_Be_Ok_And_Fail(Res<int, string> res) =>
        res.IsOk() != res.IsFail();

}