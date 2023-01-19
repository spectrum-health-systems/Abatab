<div align="center">

  <img src="../images/Logos/AbatabLogo.png" alt="Abatab Changelog" width="512">
  <br>

  <h1>
    v23.2.0 (release 2/1/23)
  </h1>

</div>

# Overview

Focus on:

* Documentation

# Documentation

* [ ] XML documentation

# General

* [ ] Cleanup project references  
Verify that projects only reference required projects.

* [ ] Cleanup public/private/internal keywords  
Verify that classes/methods have the proper scope.

* [ ] Verify that the AbatabOption is benign  
Verify that even though there is space for an AbatabOption in the Script Paramater, it doens't affect anything if it's missing.

* [ ] Better method names  
Indicate what/where things point from other projects. ex. AbatabOptionObject.FinalObj.Finalize(abatabSession) should be something like "FinalOptObj.Finalize", so we can declare the project in the usings section.

* [ ] Test to make sure that replacing DLL files works as expected.

* [ ] Confirm that we need/don't need other .DLLs (e.g., Roslyn stuff)

# Namespaces

## Abatab

No current changes.

## AbatabData

No current changes.

## AbatabData.Core

No current changes.

## AbatabData.Module

No current changes.

## AbatabLogging

* [ ] Experiment with <10ms log file delay  
Make things faster.

* [ ] Test all log types to make sure they are written to the correct folder  
General verification stuff.

* [ ] Test debugMode to make sure that "on" -> "enabled" is working correctly  
We need to make sure this is working properly.

* [ ] Log all QMO data in session log (e.g., LastOrderScheduledText)  
Additional datapoints for troubleshooting

* [ ] Fix access log filename/contents  
Hmmm...

* [ ] Verify "none" works  
None where?

* [ ] Veriry all combinations of log events work  
For example: error-trace-warning, trace-warning-other

* [ ] Logging detail level (e.g., "TRACE_01", "TRACE_02", etc.)  
Different levels of each type of log

* [ ] Error logs  
Log any errors seperately

* [ ] Lost logs  
Any log that doesn't fit existing types.

## AbatabOptionObject

No current changes.

## AbatabSession

No current changes.

## AbatabSystem

No current changes.

## ModCommon

No current changes.

## ModProgressNote

No current changes.

## ModPrototype

No current changes.

## ModQuickMedOrder

### Dose.cs

* [ ] `ModQuickMedOrderDosePercentBoundary` should be `25`, not `.25`  
Easier to read and modify, less prone to mistakes. Will need to be changed in Web.config, as well as source code.

## ModTesting

No current changes.
