using Whatch.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Whatch.Permissions;

public class WhatchPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(WhatchPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(WhatchPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<WhatchResource>(name);
    }
}
