using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Whatch;

[Dependency(ReplaceServices = true)]
public class WhatchBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Whatch";
}
