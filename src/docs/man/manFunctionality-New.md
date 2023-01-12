<div align="center">

  <img src="../images/Logo/AbatabManualLogo.png" alt="Abatab Manual" width="512">
  <br>
  <br>
  <h1>
    Version 23.0
  </h1>

</div>
You may want to create a new module

# CNew Abatab Modules

## Creating a new Abatab Module

1. Create New Project
2. Choose Class Library .NET Framework
3. Name the module, starting with "Mod" (e.g., "ModProgressNote")
4. Check "Place solution and project in the same directory
5. Verify the Framework is ".NET Framework 4.8"

## Adding the new Module to Abatab

Once the project has been created, exit Visual Studio

1. Move the new folder to src/Modules/
2. Load the Abatab solution
3. Right-click the Abatab/Modules/ folder, and choose "Add existing project"
4. Find the .csproj file for the new module

## Create Roundhouse.cs

Rename "Class1.cs" to "Roundhouse.cs"

## Adding logic to Abatab.Roundhouse.cs

```csharp
case "%newmodule-name%":
    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
    ModNewModule.Roundhouse.ParseRequest(abatabSession);
    break;
```

<!-- Reference Links -->

[AbatabUrl]: https://github.com/spectrum-health-systems/Abatab
[AvatarUrl]: https://www.ntst.com/Offerings/myAvatar

[man-GettingStarted-Home]: ./man-GettingStarted-Home.md
[man-Hosting-Home]: ./man-Hosting-Home.md
[man-Importing-Home]: ./man-Importing-Home.md
[man-Configuration-Home]: ./man-Configuration-Home.md
[man-Using-Home]: ./man-Using-Home.md
[man-ScriptLink-Home]: ./man-ScriptLink-Home.md
[man-AdditionalInformation-Home]: ./man-AdditionalInformation-Home.md
