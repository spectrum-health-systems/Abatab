# Abatab development notes

## Logging

* How to enable/disable log event types

### Debug logs

* Debug logs with "[DEBUG]" are part of the source code. All other debug statements are temporary
* Some debug statements should always be ther.
* DebbuingDebug is only for debugging/development
* Should not be enabled in production
* Cases where paramaters are hardcoded

### Trace logs

* Intended to show the flow of code, usually used during development
* Should not be enabled in production
* Trace logs are generally found at the beg/end of methods, and not in sub-methods
* Cases where paramaters are hardcoded

### Detailed information

* TBD

### Session information

* Contains all information about the current session.
* By default, is created at the end of each session.

## Roundhouse

* What these are.


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

#### ParseRequest()

* Will require rebuilding the solution if modified.


















## AbatabData.csproj

* Just definitions of data objects.

### Session Data

* All of the data we need for a session.

