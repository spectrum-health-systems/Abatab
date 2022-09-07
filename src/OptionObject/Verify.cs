using NTST.ScriptLinkService.Objects;

namespace Abatab.OptionObject
{
    public class Verify
    {
        public static bool NotModified(OptionObject2015 sentOptObj, OptionObject2015 alternateOptObj)
        {
            return (alternateOptObj == sentOptObj);
        }
    }
}