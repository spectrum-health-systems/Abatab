<div align="center">

<img src="../images/Logos/AbatabLogo.png" alt="Abatab Changelog" width="512">

<br>

# ROADMAP

</div>

# 23.1.0

## General

* [ ] Create a new logo for the changelog
* [ ] Create a new logo for the roadmap

## Documentation

* [ ] Complete documentation

## Abatab

* [ ] `ModQuickMedOrderDosePercentBoundary` should be `25`, not `.25`  
Easier to read and modify, less prone to mistakes.


* [ ] Cleanup project references
* [ ] Verify Settings.settings order matches objects (including WebConfig.cs)
* [ ] Cleanup public/private/internal
* [ ] Add the Abatab version to related log files
* [ ] Verify that the AbatabOption doesn't get in the way of anything
* [ ] Experiment with <10ms log file delay
* [ ] Better method names so user knows what/where things point from other projects. ex. AbatabOptionObject.FinalObj.Finalize(abatabSession) should be something like "FinalOptObj.Finalize", so we can declare the project in the usings section




















### Abatab

* **[-]** `ModQuickMedOrderDosePercentBoundary` should be `25`, not `.25`
* **[-]** Cleanup project references
* **[-]** Verify Settings.settings order matches objects (including WebConfig.cs)
* **[-]** Cleanup public/private/internal
* **[-]** Add the Abatab version to related log files
* **[-]** Verify that the AbatabOption doesn't get in the way of anything
* **[-]** Experiment with <10ms log file delay
* **[-]** Better method names so user knows what/where things point from other projects. ex. AbatabOptionObject.FinalObj.Finalize(abatabSession) should be something like "FinalOptObj.Finalize", so we can declare the project in the usings section

#### Abatab.Abatab.asmx.cs

* No changes

#### Abatab.Roundhouse.cs

#### Abatab.WebConfig.cs

### Core functionality

* **[X]** Test to make sure that replacing DLL files works as expected. (23.0.0.0-testbuild+221115.0903)
* **[-]** Confirm that we don't need other .DLLs (e.g., Roslyn stuff)

#### AbatabData

* No changes

#### AbatabLogging

* **[-]** Test all log types to make sure they are written to the correct folder
* **[-]** Test debugMode to make sure that "on" -> "enabled" is working correctly
* **[-]** Warning logs
* **[-]** Log all QMO data in session log (e.g., LastOrderScheduledText)
* **[-]** Fix access log filename/contents
* **[-]** Warning logs
* **[-]** Verify "none" works
* **[-]** Veriry all combinations of log events work
* **[-]** Logging detail level (e.g., "TRACE_01", "TRACE_02", etc.)
* **[-]** Error logs
* **[-]** Lost logs

#### AbatabOptionObject

No changes

#### AbatabSession

No changes

#### AbatabSystem

No changes

### Abatab Modules

#### ModCommon

No changes

#### ModProgressNote

* **[-]** Test ProgressNote.??
* **[-]** Verify valid user settings

#### ModPrototype

No changes

#### ModQuickMedOrder

* **[-]** Test Dose.VerifyUnderMaxPercentIncrease
* **[-]** Test Dose.VerifyUnderMaxMilligramIncrease
* **[-]** Test Dose.VerifyUnderMaxPercentIncrease
* **[-]** Verify authorized user settings

#### ModTesting

No changes

### Documentation

**[-]** Cleanup DocFX folders
**[-]** Complete all XML documentation

[Logo]: /.github/resources/img/logo/AbatabLogo-current.png
