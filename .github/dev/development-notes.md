# Abatab development notes

## Logging

* How to enable/disable log event types
* Public methods have debug logs at the beginning
* Public methods have trace logs
* Private methods have trace logs

### Debug logs

* Located:
    - At the top of public methods.
    - Immediately following the statement you want to trace (not separated by a blank line)
* Debug logs with "[DEBUG]" are part of the source code, and should not be removed.
* Debug logs without "[DEBUG]" temporary.
* Debug logs have a 100ms delay, and will have a noticeable affect on performance.
* DebuggingDebug is only for debugging/development/troubleshooting log functionality(?)
* DebuggingDebug logs have a 1000ms delay, and will severly impact performance.
* Debug logs should not be enabled in production
* Cases where paramaters are hardcoded

### Trace logs

* Located:
    - At the top of private methods
    - At the top of case statements
* Trace statement generally do not have any unique messages, and look like this:
```
LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
```

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
* When a ScriptLink event is executed in Avatar, an OptionObject (the information/data from Avatar that Abatab needs to do it's job) and script parameter (also referred to as the "Abatab request") are sent to Abatab. This class parses the request, and determines where the OptionObject should go for further work.

#### ParseRequest()

* Will require rebuilding the solution if modified.


















## AbatabData.csproj

* Just definitions of data objects.

### Session Data

* All of the data we need for a session.

