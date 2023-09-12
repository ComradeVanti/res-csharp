using FsCheck;

namespace ComradeVanti.CSharpTools;

public static class ResGen
{

    private static Gen<Res<TValue, TError>> GenOk<TValue, TError>() =>
        Arb.Generate<TValue>().Select(Res.Ok<TValue, TError>);

    private static Gen<Res<TValue, TError>> GenFail<TValue, TError>() =>
        Arb.Generate<TError>().Select(Res.Fail<TValue, TError>);

    private static Gen<Res<TValue, TError>> GenRes<TValue, TError>() =>
        Gen.OneOf(GenOk<TValue, TError>(), GenFail<TValue, TError>());

    public static Arbitrary<Res<int, string>> TestRes() =>
        Arb.From(GenRes<int, string>());

}