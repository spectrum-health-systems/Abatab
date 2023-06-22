<!--
  This documentation is incomplete.
-->

<div align="center">

  ![AbatabDocumentationProjectLogo](../../../../../.github/images/logo/docproj/AbatabDocumentationProjectLogo.png)

  <h1>
    The Debuggler
  </h1>

</div>

The Debuggler is a *very* basic debugging utility.

Debuggler logic is in Abatab.Core.Utility.LogFile.cs, so you will need the following using statements:
  * `using Abatab.Core.Utility;`
  * `using System.Reflection;`

Debuggler files are written to **"C:\AbatabData\Debuggler\"**, which has to exist prior to using Debuggler.

## Temporary debugging

This one-line statement can be anywhere, and should be removed after debugging is complete:

```csharp
LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name);

-or-

LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name, "Content goes here");
```
## Permanent debugging

In some cases, you may want to have the ability to create Debuggler logs without having to add or uncomment code. You can do this with the following syntax:

```csharp
if (DebugglerMode == "enabled")
{
    LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name);
}

-or-

if (DebugglerMode == "enabled")
{
    LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name, "Content goes here");
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