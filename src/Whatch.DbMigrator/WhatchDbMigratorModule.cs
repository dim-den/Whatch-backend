using Whatch.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Whatch.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(WhatchEntityFrameworkCoreModule),
    typeof(WhatchApplicationContractsModule)
    )]
public class WhatchDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
