using IdGen;

namespace Kaps.Domain.Helpers;

public class IdGeneratorHelper
{
    private static readonly IdGen.IdGenerator instance = new IdGen.IdGenerator(0, IdGeneratorOptions.Default);

    public static long Generate() => IdGeneratorHelper.instance.CreateId();
}