# Abatab Roadmap Queue

## Core functionality

### **Combine "Core.AbatabLogging.BuidlPath.cs" and Core.AbatabLogging.BuildPaths.cs**

Combine "Core.AbatabLogging.BuidlPath.cs" and Core.AbatabLogging.BuildPaths.cs

### **Rename "Core.AbatabLogging.BuidlPaths.BuildDir()" methods to "BuildPath()"**

"Path" makes more sense than "Dir"

### **Update all BuildPaths.cs methods to return List**

When [Warning logs were implemented](https://github.com/spectrum-health-systems/Abatab/issues/90), changes were made to Core.AbatabLogging.BuildPaths.cs specific to the Warning logs.

We should modify the remaining methods in BuildPaths.cs to return `List<string>`

### **Move FieldId data to config file**

Easier to change.

### **Log file delay**

As functionality is added, more staff use Abatab, and more logfiles are written, we should probably look at the write delay and determine:

* What is the best global delay?
* Are there certain logs that should not have a delay?
* Are there certain logs that should always have a specific delay?

### **Add Abatab version to log files**

As functionality is added, more staff use Abatab, and more logfiles are written, we should probably look at the write delay and determine:

* What is the best global delay?
* Are there certain logs that should not have a delay?
* Are there certain logs that should always have a specific delay?

### **Log efficiency**

Make sure we aren't going through the logging motions, and not creating log files (e.g., debug logs).

This will probably involve logging detail levels.

### **Access log details**

The access log should have a better, more descriptive filename and contents.

Logging detail levels

### **Logging detail levels**

Logging detail levels

### **Error log functionality**

When Abatab encounters an error, that error should be written to a separate error file.

The warning log should be written:

- [ ] To an external `Errors/` folder that is not accessible to the public

This functionality will require:

* TBD

### **Lost logs**

Catch any logs that aren't one of the official types.

### **Source code cleanup/refactor**

Cleanup

### **Verify Settings.settings order is consistant**

There are various locations in the source code where the settings/configuration values are listed. We should make sure that each of those locations match.

This includes Web.config and Settings.settings.

### **Cleanup DocFX folders**

Verify that DocFX has what it needs, and doesn't have unnecessary data.

***

## Module functionality

### **ModCommon: Maybe remove?**

Not sure if we need this, since most common functionality should go in Core.

### **ModQuickMedOrder: Change ModQuickMedOrderDosePercentBoundary to "25"**

Easier to read and modify, less prone to mistakes. Will need to be changed in Web.config, as well as source code.

### **ModQuickMedOrder: Log all ModQuickMedOrder details**

Log all QMO data in session log (e.g., LastOrderScheduledText)  

Additional datapoints for troubleshooting

### **ModQuickMedOrder: Dose warnings**

* Public name needs to be formatted better
* Public log data should be different
* Private name should include a timestamp
* Move session warning logs to root of the session (like the .session log is)

### **ModQuickMedOrder: Dose information to log**

We should be writing a bunch of this stuff to logs, even when successful.

***

## Documentation

### **Complete Documentation**

All documentation through v23.3 should be complete, including:

- [ ] XML documentation
- [ ] The Abatab Manual
- [ ] Abatab APIs

***

## Regression

### **[VERIFY] QuickMedOrder-Dose-VerifyAmount**

Test the following:

- [ ] Dose.VerifyUnderMaxPercentIncrease
- [ ] Dose.VerifyUnderMaxMilligramIncrease
- [ ] Dose.VerifyUnderMaxPercentIncrease

Also make sure that the testing documentation is up to date.

Eventually we should make this a built-in test.

### **[VERIFY] AbatabOption**

Verify that even though there is space for an AbatabOption in the Script Parameter, it doesn't affect anything if it's missing.

### **[VERIFY] All combinations of log file types work**

For example: error-trace-warning, trace-warning-other, none.

### **[VERIFY] Authorized Users**

Verify that the list of authorized users works for functionality.

### **[VERIFY] Replacing DLLs when updating Abatab**

The Abatab framework is modular. Each core component and module are separate C# projects. This allows changes to be made to a specific component of Abatab, without affecting the other components.

This is mainly done via replacing project DLLs when updating Abatab. This has been tested, but I would like to do a few more in-depth tests to verify everything is working as expected.

These tests should be done using the testing branch.

- [ ] Test to make sure that replacing DLL files works as expected.

- [ ] Confirm that we need/don't need other .DLLs (e.g., Roslyn stuff)

### **[VERIFY] All log types are written to the correct folder**

TBD

### **[VERIFY] debugMode**

Test the following debugMode functionality:

- [ ] Verify "on" / "enabled" is working correctly

### **[VERIFY] Fallback name**

Verify that the avatar fallback username works

***

## Misc functionality

### **Web Server directories** ([GitHub issue](none))

There should be three directories on the web server:

1. AbatabWebService - the web service

* Abatab_LIVE
* Abatab_UAT
* Abatab_SBOX

2. AbatabData - data such as Lieutenant stuff, Abatab logs, etc.

3. AbatabPublic - data available to the public.

### **Issue when an environment is refreshed**

When an environment is refreshed, the WSDLs come down from LIVE, and need to be recreated in the refreshed environment.

Is there a better way to do this?

### **New images**

We have:

* Changelog
* Logo
* Manual Logo
* Release Notes
* Roadmap

We may need:

* Blank
* Flowchart
* Development notes

### **Lowercasing**

We are currently lowercasing lots of stuff (e.g., stuff in the Web.config)...should we?

### **Class/method scopes**

Make sure all scopes are correct