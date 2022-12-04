using Volo.Abp.Modularity;

namespace Whatch;

[DependsOn(
    typeof(WhatchApplicationModule),
    typeof(WhatchDomainTestModule)
    )]
public class WhatchApplicationTestModule : AbpModule
{

}
