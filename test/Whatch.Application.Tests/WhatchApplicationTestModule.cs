using Volo.Abp.Modularity;

namespace Whatch;

[DependsOn(
    typeof(WhatchApplicationModule),
    typeof(WhatchApplicationTestModule)
    )]
public class WhatchApplicationTestModule : AbpModule
{

}
