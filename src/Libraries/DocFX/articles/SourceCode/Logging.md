# Logging

Abatab has extensive built-in logging functionality.

## Debug logs

Debug logs are only created when [`DebugMode`](https://spectrum-health-systems.github.io/Abatab/articles/SourceCode/LocalSettings.html#DebugMode) is set to `on`.    
* DebugMode should only be used while developing Abatab
* There is a hardcoded 10ms delay when writing a debug logfile, so DebugMode will have an impact on performance.

### Built-in debug statements

Most methods start with a a built-in debug statements, which have a `[DEBUG]` message. These debug statements are part of the code, and should not be removed.

```bash
LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
```
### Custom debug statements

You can create your own debug statements by customizing the message. Temporary debug statments should be removed from production code.

```bash
LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, $"VariableName value is {value}");
```

### PrimevalDebug log

The PrimevalDebug log file is the first line of Abatab.asmx.cs, and writes a debug logfile with the most basic, hardcoded setting information.

```bash
LogEvent.PrimevalDebug(Settings.Default.DebugMode, Assembly.GetExecutingAssembly().GetName().Name, $@"{Settings.Default.AbatabRoot}{Settings.Default.AbatabEnvironment}\{Settings.Default.DebugLogRoot}");
```

### The Debuggler

Abatab can write debug files for debug logs, but this should *only* be used in development, as it will introduce *significant* performance issues.

As such, enabling the debuggler can only be done in the source code by changing the following line in `AbatabLogging.LogEvent.Debug()` from

```bash
const bool debugDebugger = false;
```
to

```bash
const bool debugDebugger = true;
```

## Trace logs

Trace logs are designed to let you follow what is happening during an Abatab session, and can be helpful when troubleshooting. As such, trace statemnts are abundant.

Trace logs are only created when [`LogMode`](https://spectrum-health-systems.github.io/Abatab/articles/SourceCode/LocalSettings.html#LogMode) contains `trace`.

* Trace logs should generally be used when troubleshooting development builds, although they can be enabled in production.
* There is a global [delay]((https://spectrum-health-systems.github.io/Abatab/articles/SourceCode/LocalSettings.html#LogWriteDelay)) when writing log files, so enabling trace logs may have an negative impact on performance.

## A note about trace logs in AbatabLogging.LogEvent.cs

Log statements in AbatabLogging.LogEvent.cs don't follow most of the standards below, since it's not easy to log the thing that's creating the thing that's logging a thing. Or something.

### Built-in trace statements

Trace statements can be found:
* At the beginning of methods, immediately following debug statements
* At the beginning of any conditional statements, loops, or other expressions
* When it would be helpful to know where Abatab is

These trace statements are part of the code, and should not be removed.

```bash
LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
```

### Custom trace statements

You can create your own trace statements by customizing the message. Temporary trace statments should be removed from production code.

```bash
LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, $"VariableName value is {value}");
```

## Session logs

## Access logs

## Lost logs