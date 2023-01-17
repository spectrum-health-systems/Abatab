<div align="center">

  <img src="../images/Logos/AbatabLogo.png" alt="Abatab Changelog" width="512">
  <br>

  # v23.1.0

</div>

# Documentation

* [ ] Complete README.md
* [ ] Complete CHANGELOG.md
  * [ ] Create a new logo for the changelog
* [ ] Implement RELEASE-NOTES.md
  * [ ] Create a new logo for the release notes
* [ ] Complete ROADMAP.md
  * [ ] Create a new logo for the roadmap
* [ ] Cleanup DocFX folders
* [ ] Complete all XML documentation

# General

* [ ] Cleanup project references  
Verify that projects only reference required projects.
* [ ] Cleanup public/private/internal keywords  
Verify that classes/methods have the proper scope.
* [ ] Verify Settings.settings order matches objects  
There are various locations in the source code where the settings/configuration values are listed. We should make sure that each of those locations match.
* [ ] Verify that the AbatabOption is benign  
Verify that even though there is space for an AbatabOption in the Script Paramater, it doens't affect anything if it's missing.
* [ ] Better method names  
Indicate what/where things point from other projects. ex. AbatabOptionObject.FinalObj.Finalize(abatabSession) should be something like "FinalOptObj.Finalize", so we can declare the project in the usings section.
* [ ] Test to make sure that replacing DLL files works as expected.
* [ ] Confirm that we don't need other .DLLs (e.g., Roslyn stuff)

# Namespaces

## Abatab

No current changes.

## AbatabData

## AbatabData.Core

## AbatabData.Module

## AbatabLogging

* [ ] Add the Abatab version to related log files
* [ ] Experiment with <10ms log file delay

* [ ] Test all log types to make sure they are written to the correct folder
* [ ] Test debugMode to make sure that "on" -> "enabled" is working correctly
* [ ] Warning logs
* [ ] Log all QMO data in session log (e.g., LastOrderScheduledText)
* [ ] Fix access log filename/contents
* [ ] Warning logs
* [ ] Verify "none" works
* [ ] Veriry all combinations of log events work
* [ ] Logging detail level (e.g., "TRACE_01", "TRACE_02", etc.)
* [ ] Error logs
* [ ] Lost logs

## AbatabOptionObject

## AbatabSession

## AbatabSystem

## ModCommon

## ModProgressNote

* [ ] Test ProgressNote.
* [ ] Verify valid user settings

## ModPrototype

## ModQuickMedOrder

* [ ] Test Dose.VerifyUnderMaxPercentIncrease
* [ ] Test Dose.VerifyUnderMaxMilligramIncrease
* [ ] Test Dose.VerifyUnderMaxPercentIncrease
* [ ] Verify authorized user settings


### Dose.cs

* [ ] `ModQuickMedOrderDosePercentBoundary` should be `25`, not `.25`  
Easier to read and modify, less prone to mistakes. Will need to be changed in Web.config, as well as source code.

## ModTesting
