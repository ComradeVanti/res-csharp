using FsCheck;

namespace ComradeVanti.CSharpTools;

public static class ResGen
{

    private static Gen<Res<TOk, TFail>> GenOk<TOk, TFail>() =>
        Arb.Generate<TOk>().Select(Res.Ok<TOk, TFail>);

    private static Gen<Res<TOk, TFail>> GenFail<TOk, TFail>() =>
        Arb.Generate<TFail>().Select(Res.Fail<TOk, TFail>);

    private static Gen<Res<TOk, TFail>> GenRes<TOk, TFail>() =>
        Gen.OneOf(GenOk<TOk, TFail>(), GenFail<TOk, TFail>());

    public static Arbitrary<Res<int, string>> TestRes() =>
        Arb.From(GenRes<int, string>());

}