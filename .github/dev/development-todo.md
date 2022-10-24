# v1.0

## v0.94

* [ ] Dose code
* [ ] Test:
  * [ ] Valid user setting
* [ ] Logging
  * [ ] Standard logging (session, modules, etc.)
  * [ ] Detailed log type
  * [ ] logs/lost (and test)
  * [ ] logs/warning
* [ ] Cleanup
  * [ ] Project references
  * [ ] settings order
  * [ ] WebConfig.Load() order to match rest of code
  * [ ] XML comments
  * [ ] public/private/internal
* [ ] Logging types: all-none-trace-session
* [ ] //if (debugMode == "on" || debugMode == "undefined") // TODO Remove.
* [ ] Test logging types via Web.config
* [ ] Verify DebugDebugger
* [ ] Version someplace
* [ ] Test parameter options
* [ ] Verify all session data is being logged
* [ ] Change "logging" to "log"
* [ ] Debug write delay in config
* [ ] Verify all dirs in a loop at the beginning
* [ ] Refactor debugging log stuff
* [ ] Session.TimeStamp needed?

## v0.93

* [X] Dose code initial framework
* [X] Valid user setting
* [X] Cleanup
  * [X] XML comments
  * [X] public/private/internal
  * [X] Put "[TRACE]" on trace logs
  * [X] Reduce "[DEBUG]" on debug logs
* [X] Make sure all logging methods have plenty of trace/debug logs
* [X] Make sure all debug/trace statements are where they should be

## v0.92

* [X] Build WorkOptObj
* [X] Cleanup trace/debug logs
* [X] Move trace logs to trace/
* [X] Cleanup code/comments

# v1.1.0.0

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



/// <param name="sentOptionObject">The original OptionObject sent from Avatar.</param>
/// <param name="scriptParameter">The original Script Parameter request from Avatar.</param>