# Abatab development notes

## TESTING
* All logging modes
    * All
    * Trace
    * Session
    * Trace-Session
* Logging detail modes
    * Min
    * Normal
    * Max
* Logging delay
    * 10ms
    *100ms
* All Abatab modes
    * Enabled
    * Disabled
    * Passthrough
* All module modes
    * Enabled
    * Disabled
    * Passthrough


## Abatab.csproj

* Main entry point for Abatab.

### Abatab.asmx.cs

* Most of the heavy lifting

#### GetVersion()

* None

#### RunScript()

* Note about debugMode.
* abatabSession object holds everything we need, and is often passed around.
* Each project has a Roundhouse.cs class.
* The returned finalOptObj may/may not be modified.

### AbatabSettings.cs

* Loads local configuration settings.

#### LoadFromConfig()

* These settings are in Web.config, and can be modifed on the fly since they are read at runtime.
* Will require rebuilding the solution if modified.

### Roundhouse.cs

* Determines which module gets the request

#### ParseRequest()

* Will require rebuilding the solution if modified.

## AbatabData.csproj

* Just data objects.

### Session Data

* All of the data we need for a session.

