<div align="center">

![Logo][Logo]

# PROJECT REFERENCES

<h3>
  <b>Abatab v23.1</b>
</h3>

<h5>
  Last updated Feburary 6, 2023
</h5>

</div>

# Abatab

```mermaid
graph LR

  %% Abatab
  Abatab(((Abatab))) --> AbatabData
  Abatab(((Abatab))) --> AbatabLogging
  Abatab(((Abatab))) --> AbatabOptionObject
  Abatab(((Abatab))) --> AbatabSession
  Abatab(((Abatab))) --> ModCommon
  Abatab(((Abatab))) --> ModProgressNote
  Abatab(((Abatab))) --> ModPrototype
  Abatab(((Abatab))) --> ModQuickMedOrder
  Abatab(((Abatab))) --> ModTesting
  Abatab(((Abatab))) --> NTST.ScriptLinkService.Objects

  %% AbatabData
  AbatabData --> NTST.ScriptLinkService.Objects

  %% AbatabLogging
  AbatabLogging --> AbatabData
  AbatabLogging --> AbatabSystem
  AbatabLogging --> NTST.ScriptLinkService.Objects

  %% AbatabOptionObject
  AbatabOptionObject --> AbatabData
  AbatabOptionObject --> AbatabLogging
  AbatabOptionObject --> NTST.ScriptLinkService.Objects

  %% AbatabSession
  AbatabSession --> AbatabData
  AbatabSession --> AbatabLogging
  AbatabSession --> AbatabOptionObject
  AbatabSession --> AbatabSystem
  AbatabSession --> NTST.ScriptLinkService.Objects

  %% ModCommon
  ModCommon --> AbatabData
  ModCommon --> AbatabLogging
  ModCommon --> AbatabOptionObject

  %% ModProgressNote

  %% ModPrototype
  ModCommon --> AbatabData
  ModCommon --> AbatabLogging

  %% ModQuickMedOrder
  ModQuickMedOrder --> AbatabData
  ModQuickMedOrder --> AbatabLogging
  ModQuickMedOrder --> ModCommon
  ModQuickMedOrder --> AbatabOptionObject
  ModQuickMedOrder --> NTST.ScriptLinkService.Objects

  %% ModTesting
  ModTesting --> AbatabData
  ModTesting --> AbatabLogging
  ModTesting --> AbatabOptionObject

```

***

# NTST.ScriptLinkService.Objects

```mermaid
graph LR

  %% NTST.ScriptLinkService.Objects
  NTST.ScriptLinkService.Objects(((NTST.<br>ScriptLinkService.<br>Objects)))

```

***

# DocFX

```mermaid
graph LR

  %% DocFX
  DocFX(((DocFX)))

```

[Logo]: ../../resources/images/logos/AbatabLogo.png