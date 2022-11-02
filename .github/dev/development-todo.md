# v1.0

## 0.95

* [ ] Dose code
* [ ] Test:
  * [X] Valid user setting
* [ ] Logging
  * [ ] Standard logging (session, modules, etc.)
  * [ ] Error logs
  * [ ] Detailed log type
  * [ ] logs/lost (and test)
  * [ ] logs/warning
* [ ] Cleanup
  * [ ] Project references
  * [ ] settings order match logging order
  * [ ] WebConfig.Load() order to match rest of code
  * [ ] XML comments
  * [ ] public/private/interna
* [ ] Logging types: all-none-trace-session
* [ ] Test logging types via Web.config
* [ ] Version someplace
* [ ] Test parameter options
* [ ] Verify all session data is being logged
* [ ] Debug write delay in config
* [ ] Verify all dirs in a loop at the beginning
* [ ] Refactor debugging log stuff

Put environment in var

Valid users for testing, prototype, etc.


LastScheduledDoseText:
mgs diff
QMO info after modification in .session  
why is sentoptobj being modded?


## 0.94

* [X] Cleanup
  * [X] XML comments
  * [X] public/private/internal
* [X] //if (debugMode == "on" || debugMode == "undefined") // TODO Remove.
* [X] Verify DebugDebugger
* [X] Change "logging" to "log"

## 0.93

* [X] Dose code initial framework
* [X] Valid user setting
* [X] Cleanup
  * [X] XML comments
  * [X] public/private/internal
  * [X] Put "[TRACE]" on trace logs
  * [X] Reduce "[DEBUG]" on debug logs
* [X] Make sure all logging methods have plenty of trace/debug logs
* [X] Make sure all debug/trace statements are where they should be

## 0.92

* [X] Build WorkOptObj
* [X] Cleanup trace/debug logs
* [X] Move trace logs to trace/
* [X] Cleanup code/comments

# 1.1.0.0

* [ ] Debug descriptions are static in settings file.
* [ ] Debug stuff moved to LogEvent.Debug()
* [ ] Try...catch
* [ ] Standardize all parametar orders
* [ ] Standardize all XML paramater comments
* [ ] Follow all traces
* [ ] Cached session data?
* [ ] Move classes in Abatab\ to Core\?
* [ ] Du integration
* [ ] Flightpath
* [ ] static log messages in settings file



* [ ] Better method names so user knows what/where things point from other projects.
ex. AbatabOptionObject.FinalObj.Finalize(abatabSession) should be something like "FinalOptObj.Finalize", so we can declare the project in the usings section