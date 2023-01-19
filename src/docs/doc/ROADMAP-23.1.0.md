<div align="center">

  <img src="../images/Logos/AbatabLogo.png" alt="Abatab Changelog" width="512">
  <br>

  <h1>
    v23.1.0 (release 1/31/23)
  </h1>

</div>

# Overview

Focus on:

* Documentation
* Warning logs
* Progress Note check

# Documentation

* [ ] Complete README.md

* [ ] Complete CHANGELOG.md
  * [ ] Create a new logo for the changelog

* [ ] Implement RELEASE-NOTES.md
  * [ ] Create a new logo for the release notes

* [ ] Complete ROADMAP.md
  * [ ] Create a new logo for the roadmap

* [ ] Cleanup DocFX folders  
Make sure that there aren't any folders that aren't needed.

# General

* [ ] Verify Settings.settings order matches objects  
There are various locations in the source code where the settings/configuration values are listed. We should make sure that each of those locations match.

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

* [ ] Warning logs  
If a warning is triggered, write a log

* [ ] Export warning logs to separate folder  
Initially this will be just exporting the current warning files, but in v23.2 this should be a custom warning log with specific information. Also, other non-warning logs should be able to do this.

* [ ] Add the Abatab version to related log files  
Just another datapoint for troubleshooting

* [ ] Test debugMode to make sure that "on" -> "enabled" is working correctly  
We need to make sure this is working properly.

## AbatabOptionObject

No current changes.

## AbatabSession

No current changes.

## AbatabSystem

No current changes.

## ModCommon

No current changes.

## ModProgressNote

* [ ] Test ProgressNote.

* [ ] Verify valid user settings

## ModPrototype

No current changes.

## ModQuickMedOrder

No current changes.

### Dose.cs

* [ ] Test Dose.VerifyUnderMaxPercentIncrease

* [ ] Test Dose.VerifyUnderMaxMilligramIncrease

* [ ] Test Dose.VerifyUnderMaxPercentIncrease

* [ ] Verify authorized user settings

## ModTesting

No current changes.
