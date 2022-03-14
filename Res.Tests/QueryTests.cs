using FsCheck.Xunit;

namespace ComradeVanti.CSharpTools;

public class QueryTests
{

    [Property]
    public bool Results_Can_Not_Be_Ok_And_Fail(Res<int, string> res) =>
        res.IsOk() != res.IsFail();
    
    [Property]
    public bool Results_Created_With_Ok_Are_Always_Ok(int i) =>
        Res.Ok<int, string>(i).IsOk();
    
    [Property]
    public bool Results_Created_With_Fail_Are_Always_Fail(string e) =>
        Res.Fail<int, string>(e).IsFail();

}