using Whatch.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Whatch;

[DependsOn(
    typeof(WhatchEntityFrameworkCoreTestModule)
    )]
public class WhatchDomainTestModule : AbpModule
{

}
