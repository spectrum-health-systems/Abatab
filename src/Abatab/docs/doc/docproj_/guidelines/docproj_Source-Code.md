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

In general, method calls should not be separated by blank lines.

```csharp
MethodOne();
MethodTwo();
MethodThree();
```

<br>
<br>

# Logging

## Debuggler statement

Debuggler statements should be used sparingly, and only at the top of a `method()` where debugging is needed and a Trace Log is not possible. Debuggler statements should also be separated from the rest of the method by a blank line.

```csharp
public static void MethodOne(AbSession abSession)
{
    Debuggler.DebugLog(Settings.Default.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

    var numberOne = 1;
    var numberTwo = 2;
    var total = numberOne + numberTwo;
}
```

## Trace Logs

Trace logs should be used:

- in all methods
- in all if...then...else blocks
- in all switch case blocks
- to debug specific code

### Methods

Trace log statements should be at the top of each `method()`, separated from the rest of the method by a blank line.

```csharp
public static void DoThing(AbSession abSession)
{
    LogEvent.Trace("trace", abSession, AssemblyName);

    var numberOne = 1;
    var numberTwo = 2;
    var total = numberOne + numberTwo;
}
```

### If...then...else blocks

Trace log statements should be at the top of each `if...else if...else` block, separated from the rest of the method by a blank line.

```csharp
public static void DoThing(AbSession abSession)
{
    LogEvent.Trace("trace", abSession, AssemblyName);

    var numberOne = 1;

    if (numberOne == 1 )
    {
        LogEvent.Trace("trace", abSession, AssemblyName);

        total = 1
    }
    else if (numberOne == 2)
    {
        LogEvent.Trace("trace", abSession, AssemblyName);

        total = 2
    }
    else
    {
        LogEvent.Trace("trace", abSession, AssemblyName);

        total = 30
    }
}
```

## Switch case blocks

Trace log statements should be at the top of each `switch case` block, separated from the rest of the method by a blank line.

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

## Inline code

Inline Trace Log statements should be used sparingly, when you need to debug a specific line/block of code.

When a Trace Log statement is added to code that you need to debug, the statement should follow the line of code directly, and should not be followed by a blank line.

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

# If...else if...else statments

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

# Return statements

## Methods

Return statements at the end of a `method()` should be separated from that block by a blank line.

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

## Switch statements

Return statements at the end of a `case` block should be separated from that block by a blank line.

```csharp
public static void DoThing(string thing)
{
    switch (thing)
    {
        case "true":
            DoAnotherThing();

            return true;

        case "false":
            DoAnotherThing();

            return false;

        default:
            DoAnotherThing();

            return false;
    }
}
```

## In-line return statements

Return statements in a `if...else if...else` and `case` statment blocks of code shouldn't have any blank lines.

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

# Catalog information

Catalog information is pre-defined text for logging/data export.

Catalog information methods should use the expression body style, and string interpolation.

The strings that these methods return use Markdown syntax, which creates a carriage return when a line ends with two blank characters:

```csharp
$"**Mode:** {abSession.ModProgressNote.Mode}  {Environment.NewLine}"
                                            ^^
```

Removing the blank characters will break the Markdown output.

Example:

```csharp
public static string CatalogInformation() =>
    $"## Title{Environment.NewLine}" +
    $"**First thing:** {firstThing}  {Environment.NewLine}" +
    $"**Second thing:** {secondThing}  {Environment.NewLine}" +
    $"**Third thing:** {thirdThing.ValidOrderTypes}  {Environment.NewLine}";
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
