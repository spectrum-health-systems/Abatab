# Logging

## Debuggler Mode

Debuggler Logs exist where Trace Logs cannot.

## Trace logs

* Trace logs at the beginning of every method

```csharp
LogEvent.Trace("trace", abSession, AssemblyName);
```

* Internal trace logs in if...then, switch statements, etc.

```csharp
LogEvent.Trace("traceinternal", abSession, AssemblyName);
```