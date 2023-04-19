# Logging

## Debuggler Mode

Debuggler Mode information here.

## Trace logs

* Trace logs at the beginning of every method

```csharp
LogEvent.Trace("trace", abSession, AssemblyName);
```

* Internal trace logs in if...then, switch statements, etc.

```csharp
LogEvent.Trace("traceinternal", abSession, AssemblyName);
```