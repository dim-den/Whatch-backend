using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Whatch.Data;

/* This is used if database provider does't define
 * IWhatchDbSchemaMigrator implementation.
 */
public class NullWhatchDbSchemaMigrator : IWhatchDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
