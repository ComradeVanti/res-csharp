using System.Net.NetworkInformation;
using FsCheck.Xunit;

namespace ComradeVanti.CSharpTools;

public class GeneralTests
{

    [Property]
    public bool Results_Can_Not_Be_Ok_And_Fail(Res<int, string> res) =>
        res.IsOk() != res.IsFail();

    [Property]
    public bool Results_With_Equal_Value_Are_Equal(int i) =>

        // ReSharper disable once EqualExpressionComparison
        Res.Ok<int, string>(i).Equals(Res.Ok<int, string>(i));

    [Property]
    public bool Results_With_Equal_Error_Are_Equal(string error) =>

        // ReSharper disable once EqualExpressionComparison
        Res.Fail<int, string>(error).Equals(Res.Fail<int, string>(error));

    [Property]
    public bool Results_With_Unequal_Value_Are_Not_Equal(int i) =>
        !Res.Ok<int, string>(i).Equals(Res.Ok<int, string>(i + 1));

    [Property]
    public bool Results_With_Unequal_Error_Are_Not_Equal(string error) =>
        !Res.Fail<int, string>(error).Equals(Res.Fail<int, string>(error + "!"));

    [Property]
    public bool Ok_Is_Never_Equal_To_Fail(int i, string error) =>
        !Res.Ok<int, string>(i).Equals(Res.Fail<int, string>(error));

    [Property]
    public bool Res_That_Are_Equal_Are_Same(int i) =>
        // ReSharper disable once EqualExpressionComparison
        Res.Ok<int, string>(i) == Res.Ok<int, string>(i);
    
    [Property]
    public bool Res_That_Are_Unequal_Are_Not_Same(int i) =>
        // ReSharper disable once EqualExpressionComparison
        !(Res.Ok<int, string>(i) == Res.Ok<int, string>(i + 1));
    
    [Property]
    public bool Res_That_Are_Equal_Are_Not_Different(int i) =>
        // ReSharper disable once EqualExpressionComparison
        !(Res.Ok<int, string>(i) != Res.Ok<int, string>(i));
    
    [Property]
    public bool Res_That_Are_Unequal_Are_Different(int i) =>
        // ReSharper disable once EqualExpressionComparison
        Res.Ok<int, string>(i) != Res.Ok<int, string>(i + 1);

}