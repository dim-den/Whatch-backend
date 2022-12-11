using Whatch.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Whatch.Permissions;

public class WhatchPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(WhatchPermissions.GroupName);

        myGroup.AddPermission(WhatchPermissions.CrudOperations, L("Permission:CRUD"));
        myGroup.AddPermission(WhatchPermissions.LeaveReview, L("Permission:LeaveReview"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<WhatchResource>(name);
    }
}
