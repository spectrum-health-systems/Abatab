<!--
  This documentation is incomplete.
-->

<div align="center">

  ![AbatabDocumentationProjectLogo](../resources/images/logos/AbatabDocumentationProjectLogo.png)

  <h1>
    Source Code
  </h1>

</div>

<br>

# Method calls

## Standard code

In general, method calls should not be separated by blank lines.

```csharp
MethodOne();
MethodTwo();
MethodThree();
```

# Debuggler statement

A Debuggler statement should be at the top of each method, and be separated from the rest of the method by a blank line.

```csharp
public static void MethodOne(AbSession abSession)
{
    Debuggler.DebugLog(Settings.Default.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

    var numberOne = 1;
    var numberTwo = 2;
    var total = numberOne + numberTwo;
}
```

# Variable declarations

Variables should be declared in their own block at the top of a method.

```csharp
public static int MethodOne()
{
    var numberOne = 1;
    var numberTwo = 2;  

    var total = numberOne + numberTwo;

    return total;
}
```

# If...else

If...else blocks should be in their own block.

```csharp
public static void MethodOne(bool doWork)
{
    var numberOne = 1;
    var numberTwo = 2;  
    var total = 0;

    if (doWork)
    {
        total = numberOne + numberTwo;
    }
    else
    {
        total = numberOne - numberTwo;
    }

    return total;
}
```

# Break statements

```csharp
public static void DoThing(bool doWork)
{
    switch (thing)
    {
        case true:
            MethodOne();
            break;

        case false:
            MethodTwo();
            break;

        default:
            MethodThree();
            break;
    }
}
```

















# Log statements

## Method trace logs

Trace log statements should be at the top of each method, and be separated from the rest of the method by a blank line.

```csharp
public static void DoThing(AbSession abSession)
{
    LogEvent.Trace("trace", abSession, AssemblyName);

    var numberOne = 1;
    var numberTwo = 2;
    var total = numberOne + numberTwo;
}
```

## Block trace logs

```csharp
public static void DoThing(AbSession abSession)
{
    LogEvent.Trace("trace",abSession,AssemblyName);

    switch (thing)
    {
        case "valueOne":
            LogEvent.Trace("traceinternal",abSession,AssemblyName);

            Module.Testing.Roundhouse.ParseCommand(abSession);

            break;

        case "valueOne":
            LogEvent.Trace("traceinternal",abSession,AssemblyName);

            Module.ProgressNote.Roundhouse.ParseCommand(abSession);

            break;

        default:

            LogEvent.Trace("traceinternal",abSession,AssemblyName);

            break;
    }
}
```

## In-line trace logs

Inline trace logs should directly follow what they are tracing.

```csharp
public static void ParseCommand(AbSession abSession)
{
    LogEvent.Trace("trace", abSession, AssemblyName);

    var numberOne = 1;
    LogEvent.Trace("trace", abSession, AssemblyName);
    var numberTwo = 2;
    LogEvent.Trace("trace", abSession, AssemblyName);
    var total = numberOne + numberTwo;
    LogEvent.Trace("trace", abSession, AssemblyName);
}
```

# Return statements

## Method return statements

Return statements at the end of a method should be separated from that block by a blank line.

```csharp
public static string DoThing(AbSession abSession)
{
    LogEvent.Trace("trace", abSession, AssemblyName);

    var numberOne = 1;
    var numberTwo = 2;
    var total = numberOne + numberTwo;

    return total;
}
```

```csharp
public static void DoThing(string thing)
{
    switch (thing)
    {
        case "true":
            LogEvent.Trace("trace", abSession, AssemblyName);

            return true;

        case "false":
            LogEvent.Trace("traceinternal",abSession,AssemblyName);

            return false;

        default:
            LogEvent.Trace("traceinternal",abSession,AssemblyName);

            return false;
    }
}
```

## In-line return statements

Return statements in a block of code shouldn't have any blank lines.

```csharp
public static void DoThing(string thing)
{
    switch (thing)
    {
        case "true":
            return true;

        case "false":
            return false;

        default:
            return false;
    }
}
```











<br>

***

<div align="center">

  This document is part of the [Abatab Documentation Project](../Abatab%20Documentation%20Project.md).

  <h5>
    Last updated: May 30, 2023
  </h5>

</div>
