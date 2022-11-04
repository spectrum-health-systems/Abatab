# Logging

Abatab has extensive logging functionality built in.

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

```sh
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

* [TRACE]

## Session logs

## Access logs

## Lost logs



```