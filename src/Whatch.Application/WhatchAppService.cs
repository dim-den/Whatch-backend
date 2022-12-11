using Whatch.Localization;
using Volo.Abp.Application.Services;

namespace Whatch;

/* Inherit your application services from this class.
 */
public abstract class WhatchAppService : ApplicationService
{
    protected WhatchAppService()
    {
        LocalizationResource = typeof(WhatchResource);
    }
}
