<!--
  README.md for development branches of Abatab.

  Flowcharts:
    - Class names are BackgroundTextBorder
    - Color names/HEX codes from https://coolors.co
-->

<div align="center">

  <br>

  ![BranchWarning](https://img.shields.io/badge/THIS%20IS-A%20DEVELOPMENT%20VERSION%20BRANCH-FF160C?style=for-the-badge) ![BranchWarning](https://img.shields.io/badge/OF-%20SOFTWARE%20THAT%20HAS%20NOT%20BEEN%20TESTED-FF160C?style=for-the-badge) 

  ***SO...***

  <h2>

  **DO NOT USE THIS SOURCE CODE IN PRODUCTION ENVIRONMENTS!**

  </h2>

  If you want to use Abatab in a production environment, please see the [Abatab Community Release](https://github.com/spectrum-health-systems/Abatab-Community-Release).

  ***

  <br>
  
  ![AbatabLogo](./.github/images/logo/app/AbatabLogo.png)

  <br>

  ![RepoStatus](https://img.shields.io/badge/status-Active-brightgreen?style=flat)&nbsp;&nbsp;![AbatabLicense](https://img.shields.io/github/license/spectrum-health-systems/abatab)&nbsp;&nbsp;![AbatabCurrentRelease](https://img.shields.io/github/v/release/spectrum-health-systems/Abatab?style=flat)

</div>

<br>

>This repository is a **development version** of Abatab, which **is not intended for use in production environments**.  
>
>Abatab development, and its repositories are a little different than most source code repositories. This document  
> will detail what those differences are, and why they exist.  
>
>If you want to use Abatab in a production environment, please see the [Abatab Community Release](https://github.com/spectrum-health-systems/Abatab-Community-Release).  
>
>If you are looking for the most recent stable release of Abatab, please see the Abatab [main branch](https://github.com/spectrum-health-systems/Abatab).

<br>

***

<br>

# Abatab development

Abatab development takes place in X stages:

[Stage I: Monthly development branch](#stage-i-monthly-development-branch)

# **Stage I**: Monthly development branch

This stage is where the majority of Abatab development takes place.

During monthly development and testing:

* New functionality is added, and existing functionality is updated/modified
* Bugs are squished
* Code is refactored
* New documentation is added, and existing documentation is updated/modified
* Continual testing is done in a non-production environment

<br>

<div align="center">

```mermaid
%%{init: {'theme':'dark'}}%%
gantt
  title Abatab monthly development branch timeline
  dateFormat X
  axisFormat %d
  Pre-development : 0, 5d
  Development : 20d
  Testing : 5d
```

</div>

## Pre-development

<div align="left">

```mermaid
flowchart LR
  ArchivePreviousMonthlyDevelopmentBranch["Archive previous monthly\n development branch"] --> CreateNewMonthlyDevelopmentBranch[Create new monthly\ndevelopment branch]
  CreateNewMonthlyDevelopmentBranch --> Refactor[Refactor] --> CleanUp[Clean-up]
  
  %%classDef Green1A4301BlackBlack fill:#1A4301, color:#000000, stroke:#000000,stroke-width:2px
  classDef Green245501WhiteBlack fill:#245501, color:#FFFFFF, stroke:#000000,stroke-width:2px
  classDef Green73A942WhiteBlack fill:#73A942, color:#FFFFFF, stroke:#000000,stroke-width:2px
  classDef GreenAAD576BlackBlack fill:#AAD576, color:#000000, stroke:#000000,stroke-width:2px
  classDef WhiteBlackBlack fill:#FFFFFF, color:#000000, stroke:#000000,stroke-width:2px
  
  class ArchivePreviousMonthlyDevelopmentBranch Green245501WhiteBlack
  class CreateNewMonthlyDevelopmentBranch Green73A942WhiteBlack
  class Refactor,CleanUp GreenAAD576BlackBlack
  class FirstDayOfTheMonth WhiteBlackBlack
```

</div>

### Archive the previous monthly development branch

If the previous monthly development branch was not released, the branch name should remain `MM.DD-development`

If the previous monthly development branch was released, the branch name should be reanemd to `MM.DD-release`

### Create a new monthly development branch

Create a new repository branch named `MM.DD-development` from the previous monthly development branch

### Refactor

Refactor code.

### Clean-up

Clean-up code and comments

<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>






<div align="center">

```mermaid
---
title: Monthly development and testing workflow
---
flowchart LR
  MonthlyBranch[MM.DD-development branch] --> TestingBranch[testing branch] -.-> NonProductionTesting[\Non-production\ntesting/]

  classDef Green73A942BlackBlack fill:#73A942, color:#000000, stroke:#000000,stroke-width:2px
  classDef MaizeBlackBlack fill:#F9C74F, color:#000000, stroke:#000000,stroke-width:2px
  classDef WhiteBlackBlack fill:#FFFFFF, color:#000000, stroke:#000000,stroke-width:2px
  
  class MonthlyBranch Green73A942BlackBlack
  class TestingBranch MaizeBlackBlack
  class NonProductionTesting WhiteBlackBlack
```

</div>

<br>





## Timeline breakdown



On the first day of a new month, a new monthly development branch is created from the previous monthly development branch.





Abatab development takes place in the following repositories:

* `MM.DD-development`  
These are the monthly development



<br>














The current development version branch of Abatab is `v23.6`.

## Things to keep in mind about development version branches

Abatab development version branches:

* May be broken!
* May have missing functionality!
* Will have lots of ugly, gross code!
* Will have extensive comments!
* Might be dangerous to use!

<br>



<br>

## Development Version Branch

The majority of development is done in the **development version branch**, including additions and updates to documentation.

The development version branch name is the version being developed (e.g., `23.5d`). Please note the `d` postfix, which indicates that this branch is for development.

The version branch is not deployed to the web service host.



## Development branch

Once the version branch is stable, it is merged with the **Development Branch**.

This is the branch that is deployed to the web service host, and used for testing.

## Main branch

When testing functionality in the development branch is complete, it is merged with the **Main Branch**.

This is the official current development release of Abatab.

### Release types

When a version of Abatab is completed and released, the branch is renamed to `YY.MMx`, where `x` is:

* `d` for development branches that may not be fully functional
* `f` for final branches that have been tested and are fully functional
* stable
* rc
* cr
* hf


<br>

# Contributing

If you are interested in Abatab development, you will need:

* A location to host the Abatab which meets the following requirements:
* .NET Framework 4.8+ installed
* Access to yourmyAvatar™ environments via HTTPS
* [ScriptLink Standard](https://github.com/rcskids/ScriptLinkStandard)

<br>

<div align="center">

***

Abatab is developed by:<br>
[A Pretty Cool Program](https://github.com/APrettyCoolProgram)

</div>
