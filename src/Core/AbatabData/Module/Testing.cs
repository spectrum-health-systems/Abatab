// AbatabData 23.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221228.1025

namespace AbatabData.Module
{
    /// <summary>Defines the properties for the AbatabData.Module.Testing object, containing the information/data that Abatab needs to do its job.</summary>
    public class Testing
    {
        /// <summary>The default behavior of the Abatab Testing Module. <see href="https://spectrum-health-systems.github.io/Abatab/man/man-configuration-local-settings.html#modtestingmode"> [more info]</see></summary>
        /// <value>Default value is <c>enabled</c>.</value>
        public string Mode { get; set; }
    }
}
