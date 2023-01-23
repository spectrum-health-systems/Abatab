<div align="center">

![Logo][Logo]

# DEVELOPMENT NOTES

<h3>
  Last updated December 12, 2022
</h3>

</div>

# Upcoming deployments

## v23.1 deployment

1. Backup all branches
2. Remove all branches except main
3. Refresh main with v23.1
4. Create v23.1 branch from main branch
5. Create v23.2 branch from v23.1 branch
6. Update v23.1 branch with a message about not being current, and pointing to development branch
7. Create README.md on development branch pointing to v23.2

Going forward, development take place on v23.2 branch.

## v23.2 deployment

1. Merge v23.2 branch with main branch
2. Create v23.3 branch with v23.2 branch
3. Update v23.2 branch with a message about not being current, and pointing to development branch
4. Update README.md on development branch pointing to v23.3

## v23.3 deployment

> v23.3 is deployed at the same time as the Abatab Spring23 Community Release

1. Merge v23.3 branch with main branch
2. Create v23.4 branch with v23.3 branch
3. Update v23.3 branch with a message about not being current, and pointing to development branch
4. Update README.md on development branch pointing to v23.4

## Abatab Spring23 Community Release

> The Abatab Spring23 Community Release is deployed at the same time as v23.3

1. Create a Abtab Community Release branch from the v23.3 branch
2. Update main branch README to let users know about the Community Release

***

# Adding new local settings

1. Add the setting to Properties/Settings.settings
2. Open Web.config and copy/paste the setting where it belongs
3. Add the setting to .Core.AbatabData.Session.cs



Development versions of Abatab use [Symanic Versioning](https://semver.org/) with the format of X.Y.Z where:

* **`X`** is a the major version, and is based on the release year
* **`Y`** is a the minor version, and is based on the release month
* **`Z`** is a the patch version

For example, an Abatab release in May of 2023 would have a version of `23.5`



# The Abatab Community Release

The stable version of Abatab that is intended for production environments is called the "**Community Release**".

The Abatab Community Release is available on a quarterly basis on the following schedule:

* Spring: April 1st
* Summer: July 1st
* Autumn: October 1st
* Winter: January 1st

For example, the Abatab Community Release during the Autumn of 2023 is named `Abatab Community Release Summer23`

## Development versions of Abatab

Abatab is being actively developed outside of the Community release (see the development branch [here](https://github.com/spectrum-health-systems/Abatab/tree/development)), but it is not recommended to use development versions of Abatab in production environments.










## Logging

* How to enable/disable log event types
* Public methods have debug logs at the beginning
* Public methods have trace logs
* Private methods have trace logs
* Logging is done a little differently in AbatabLogging.BuildContent()


### Debug logs

* Located:
    - At the top of public methods.
    - Immediately following the statement you want to trace (not separated by a blank line)
* Debug logs with "[DEBUG]" are part of the source code, and should not be removed.
* Debug logs without "[DEBUG]" temporary.
* Debug logs have a 100ms delay, and will have a noticeable affect on performance.
* DebuggingDebug is only for debugging/development/troubleshooting log functionality(?)
* DebuggingDebug logs have a 1000ms delay, and will severly impact performance.
* Debug logs should not be enabled in production
* Cases where paramaters are hardcoded

### Trace logs

* Located:
    - First statement in a private method, second statement in a public method (behind debug statement)
    - Last statement in public/private methods (or last statement before return)
    - At the top of case statements
    - At the top of if...else statements
    - After assignments that aren't generated via a method
* Trace statements generally do not follow methods that have a trace event at the top, unless there is no trace event at the top (see: maintenance)
* Trace statement generally do not have any unique messages, and look like this:
```
LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
```
* Trailing trace logs have a logMsg that desribes why they are there/what they are doing.

* Intended to show the flow of code, usually used during development
* Should not be enabled in production
* Trace logs are generally found at the beg/end of methods, and not in sub-methods
* Cases where paramaters are hardcoded

### Detailed information

* TBD

### Session information

* Contains all information about the current session.
* By default, is created at the end of each session.

## Roundhouse

* What these are.


## TESTING
* All logging modes
    * All
    * Trace
    * Session
    * Trace-Session
* Logging detail modes
    * Min
    * Normal
    * Max
* Logging delay
    * 10ms
    *100ms
* All Abatab modes
    * Enabled
    * Disabled
    * Passthrough
* All module modes
    * Enabled
    * Disabled
    * Passthrough


## Abatab.csproj

* Main entry point for Abatab.

### Abatab.asmx.cs

* Entry point
* For the most part, this source code should remain relatively static, since most of the heavy lifting is done outside of the Abatab.csproj project. In the event that this code is modified, it is recommended that you clean/rebuild the entire Abatab solution.

#### GetVersion()

* None

#### RunScript()

* Note about debugMode.
* abatabSession object holds everything we need, and is often passed around.
* Each project has a Roundhouse.cs class.
* The returned finalOptObj may/may not be modified.

### AbatabSettings.cs

* Loads local configuration settings.
* For the most part, this source code should remain relatively static. Whenever a setting is added/removed from Web.config, it needs to be added/removed here as well. In the event that this code is modified, it is recommended that you clean/rebuild the entire Abatab solution.

#### LoadFromConfig()

* These settings are in Web.config, and can be modifed on the fly since they are read at runtime.
* Will require rebuilding the solution if modified.

### Roundhouse.cs

* Determines which module gets the request
* For the most part, this source code should remain relatively static. Whenever a new Abatab modules is added/removed, it needs to be added/removed here as well.In the event that this code is modified, it is recommended that you clean/rebuild the entire Abatab solution.
* When a ScriptLink event is executed in Avatar, an OptionObject (the information/data from Avatar that Abatab needs to do it's job) and script parameter (also referred to as the "Abatab request") are sent to Abatab. This class parses the request, and determines where the OptionObject should go for further work.

#### ParseRequest()

* Will require rebuilding the solution if modified.


















## AbatabData.csproj

* Just definitions of data objects.

### Session Data

* All of the data we need for a session.





## ModuleDose

* Note about settings
    - space before "mgs"












    

v1.0 (December 2022)

# Abatab v1.0 (Autumn 2022)

* Modules
    * Quick Medication Order Dose
        * Verify percentage
        * Verfiy milligrams
    * User verification
        * Jeff's thing
    * Billing
        * Kristy’s thing
* Logging
    * Debug logs
    * Trace logs
    * Session logs
* External configuration files


# Abatab Next
* Modules
    * Inpatient Admission Date
        * Verify
    * Open incident form (see below)
* Logging
    * TBD
* External configuration files
    * TBD
* Functionality
    * Email















Open Incident form
Incident Classification meets one of a number of criteria
Incident Severity = Critical
Potential email when this happens






















Abatap
Abatap is custom web service framework for Netsmart’s myAvatar EHR, which includes:
•	The Abatap web service
•	Abatap web service modules
•	The Abatap Commander

Abatap is designed with the following in mind:
•	Functionality can be tested and deployed without affecting existing functionality. This is possible since the core of Abatap is fairly static, and functionality is contained in separate projects.
•	Configuration is stored in external, plain text files.
•	Everything is logged, and there are different levels of logging
•	Ability to enable/disable the entire framework, or individual components
•	Automatic deployments
•	Running backups
•	Information about all environments
•	Log archiving
•	System health monitoring
















Abatap v1.0 (Autumn 2022)
•	Functionality
o	New
	Dose check
	User verification
	Kristy’s thing
o	Updated
	TBD
•	Features
o	New
	Logging
	External configuration files
o	Updated
	TBD

Abatap v1.2 (Winter 2022)
•	Functionality
o	New
	Inpatient Admission Date
	Open Incident form classification/severity
o	Updated
	TBD
•	Features
o	New
	Emailing
o	Updated
	Logging
















Open Incident form
Incident Classification meets one of a number of criteria
Incident Severity = Critical
Potential email when this happens















[Logo]: /.github/resources/img/logo/AbatabLogo-current.png
