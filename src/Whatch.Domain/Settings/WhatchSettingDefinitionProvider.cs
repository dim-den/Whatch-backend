using Volo.Abp.Settings;

namespace Whatch.Settings;

public class WhatchSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(WhatchSettings.MySetting1));
    }
}
