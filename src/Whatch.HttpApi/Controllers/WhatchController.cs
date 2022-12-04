using Whatch.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Whatch.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class WhatchController : AbpControllerBase
{
    protected WhatchController()
    {
        LocalizationResource = typeof(WhatchResource);
    }
}
