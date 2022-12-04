using System.Threading.Tasks;

namespace Whatch.Data;

public interface IWhatchDbSchemaMigrator
{
    Task MigrateAsync();
}
