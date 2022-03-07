using FsCheck.Xunit;

namespace ComradeVanti.CSharpTools;

public class InstantiationTests
{

    [Property]
    public bool Results_Created_With_Ok_Are_Always_Ok(int i) =>
        Res.Ok<int, string>(i).IsOk();
    
    [Property]
    public bool Results_Created_With_Fail_Are_Always_Fail(string e) =>
        Res.Fail<int, string>(e).IsFail();

}