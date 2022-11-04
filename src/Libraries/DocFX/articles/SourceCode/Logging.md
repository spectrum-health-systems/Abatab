# Logging

Abatab has extensive built-in logging functionality.

The following log-related settings are available in the local settings file:

* [`DebugMode`](https://spectrum-health-systems.github.io/Abatab/articles/SourceCode/LocalSettings.html) enables/disables the creation of debug logs

* `LogMode` enables/disables the creation of log file types


## Debug logs

Debug logs are only created when `DebugMode` is set to `on`.    
* DebugMode should only be used while developing Abatab
* There is a 10ms pause when writing a debug logfile, so it will have an impact on performance.

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

Trace logs are designed to let you follow what is happening during an Abatab session, and can be helpful when troubleshooting.

Trace logs are only created when `LogMode` contains `trace`.


* DebugMode should only be used while developing Abatab
* There is a 10ms pause when writing a debug logfile, so it will have an impact on performance.

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

## Session logs

## Access logs

## Lost logs



```