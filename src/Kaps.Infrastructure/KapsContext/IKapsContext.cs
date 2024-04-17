namespace Kaps.Infrastructure.KapsContext;

public interface IKapsContext
{
    KapsContextMessage Get();

    void Set(KapsContextMessage kapsContext);
}