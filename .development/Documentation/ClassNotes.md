# DEVELOPMENT NOTES - Class notes

> Last updated 1-27-23


### Abatab.asmx.cs

* Entry point
* For the most part, this source code should remain relatively static, since most of the heavy lifting is done outside of the Abatab.csproj project. In the event that this code is modified, it is recommended that you clean/rebuild the entire Abatab solution.

#### GetVersion()

* None

#### RunScript()

* Note about debugMode.
* abatabSession object holds everything we need, and is often passed around.
* Each project has a Roundhouse.cs class.
* The returned finalOptObj may/may not be modified.

### AbatabSettings.cs

* Loads local configuration settings.
* For the most part, this source code should remain relatively static. Whenever a setting is added/removed from Web.config, it needs to be added/removed here as well. In the event that this code is modified, it is recommended that you clean/rebuild the entire Abatab solution.

#### LoadFromConfig()

* These settings are in Web.config, and can be modifed on the fly since they are read at runtime.
* Will require rebuilding the solution if modified.

### Roundhouse.cs

* Determines which module gets the request
* For the most part, this source code should remain relatively static. Whenever a new Abatab modules is added/removed, it needs to be added/removed here as well.In the event that this code is modified, it is recommended that you clean/rebuild the entire Abatab solution.
* When a ScriptLink event is executed in Avatar, an OptionObject (the information/data from Avatar that Abatab needs to do it's job) and script parameter (also referred to as the "Abatab request") are sent to Abatab. This class parses the request, and determines where the OptionObject should go for further work.

#### ParseRequest()

* Will require rebuilding the solution if modified.


















## AbatabData.csproj

* Just definitions of data objects.