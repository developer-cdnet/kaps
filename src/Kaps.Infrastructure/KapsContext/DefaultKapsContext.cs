namespace Kaps.Infrastructure.KapsContext;

public class DefaultKapsContext : IKapsContext
{
    private static readonly AsyncLocal<KapsContextMessage> kapsContextMessageStore = new();
    
    public KapsContextMessage Get()
    {
        return kapsContextMessageStore.Value;
    }

    public void Set(KapsContextMessage kapsContext)
    {
        kapsContextMessageStore.Value = kapsContext;
    }
}