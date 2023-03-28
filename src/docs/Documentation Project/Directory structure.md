# Directory structure

```#text
+---Abatab
|   +---.github                 
|   +---docs                    DocFX data output (for GitHub pages)
|   +---src                     Abatab source code
```

The `.github\` directory contains repository resources that don't necessarily need to be visible to the end user.

```#text
+---.github
|   +---dev                     Development data
|   |   +---doc                 Development documenation and notes
|   |   +---palettes            Application color palettes
|   +---res                     Repository resources
|       +---image               Repository images
|       |   +---docfx           DocFX images
|       |   +---logo            Abatab logos
|       |   |   +---app         Application logos
|       |   |   \---man         Manual logos
|       |   +---screenshot      Screenshots
```


```#text
Abatab
+---.github                                                    Abatab repository data, documents, and other resources that don't necessarily need to be visible to the end user.
|   +---dev
|   |   +---doc
|   |   |   |   +---Abatab directory structure
|   |   |   |   +---Adding new settings
|   |   |   |   +---Adding ScriptLink events to forms
|   |   |   |   +---Script Error messages
|   |   |   |   \---_old_
|   |   |   |       \---BinaryFiles
|   |   |   \---palettes
|   |   \---res
|   |       \---image
|   |           +---docfx
|   |           |   \---originals
|   |           +---logo
|   |           |   +---app
|   |           |   \---man
|   |           \---screenshot
|   +---docs
|   |   +---api
|   |   +---doc
|   |   |   \---ReleaseNotes
|   |   +---fonts
|   |   +---images
|   |   |   +---HostUsingIis
|   |   |   +---Importing
|   |   |   +---Logo
|   |   |   +---Logos
|   |   |   \---other
|   |   +---man
|   |   \---styles
|   \---src
|       +---bin
|       |   \---roslyn
|       +---docs
|       |   \---Documentation Project
|       +---Documentation
|       +---obj
|       |   \---Debug
|       |       \---TempPE
|       +---packages
|       |   +---Microsoft.CodeDom.Providers.DotNetCompilerPlatform.2.0.1
|       |   |   +---build
|       |   |   |   +---net45
|       |   |   |   \---net46
|       |   |   +---content
|       |   |   |   +---net45
|       |   |   |   \---net46
|       |   |   +---lib
|       |   |   |   \---net45
|       |   |   \---tools
|       |   |       +---net45
|       |   |       +---Roslyn45
|       |   |       \---RoslynLatest
|       |   +---MSTest.TestAdapter.1.2.0
|       |   |   \---build
|       |   |       +---net45
|       |   |       +---netcoreapp1.0
|       |   |       +---uap10.0
|       |   |       \---_common
|       |   |           +---cs
|       |   |           +---de
|       |   |           +---es
|       |   |           +---fr
|       |   |           +---it
|       |   |           +---ja
|       |   |           +---ko
|       |   |           +---pl
|       |   |           +---pt
|       |   |           +---ru
|       |   |           +---tr
|       |   |           +---zh-Hans
|       |   |           \---zh-Hant
|       |   +---MSTest.TestFramework.1.2.0
|       |   |   \---lib
|       |   |       +---net45
|       |   |       |   +---cs
|       |   |       |   +---de
|       |   |       |   +---es
|       |   |       |   +---fr
|       |   |       |   +---it
|       |   |       |   +---ja
|       |   |       |   +---ko
|       |   |       |   +---pl
|       |   |       |   +---pt
|       |   |       |   +---ru
|       |   |       |   +---tr
|       |   |       |   +---zh-Hans
|       |   |       |   \---zh-Hant
|       |   |       +---netstandard1.0
|       |   |       |   +---cs
|       |   |       |   +---de
|       |   |       |   +---es
|       |   |       |   +---fr
|       |   |       |   +---it
|       |   |       |   +---ja
|       |   |       |   +---ko
|       |   |       |   +---pl
|       |   |       |   +---pt
|       |   |       |   +---ru
|       |   |       |   +---tr
|       |   |       |   +---zh-Hans
|       |   |       |   \---zh-Hant
|       |   |       \---uap10.0
|       |   |           +---cs
|       |   |           +---de
|       |   |           +---es
|       |   |           +---fr
|       |   |           +---it
|       |   |           +---ja
|       |   |           +---ko
|       |   |           +---pl
|       |   |           +---pt
|       |   |           +---ru
|       |   |           +---tr
|       |   |           +---zh-Hans
|       |   |           \---zh-Hant
|       |   \---Newtonsoft.Json.12.0.1
|       |       \---lib
|       |           +---net20
|       |           +---net35
|       |           +---net40
|       |           +---net45
|       |           +---netstandard1.0
|       |           +---netstandard1.3
|       |           +---netstandard2.0
|       |           +---portable-net40+sl5+win8+wp8+wpa81
|       |           \---portable-net45+win8+wp8+wpa81
|       \---Properties
+---Abatab - Copy
|   +---.development
|   |   +---Docs
|   |   |   +---Abatab directory structure
|   |   |   +---Adding new settings
|   |   |   +---Adding ScriptLink events to forms
|   |   |   +---Script Error messages
|   |   |   \---_old_
|   |   |       \---BinaryFiles
|   |   +---Images
|   |   |   +---application-logos
|   |   |   +---docfx
|   |   |   |   \---originals
|   |   |   \---manual-logos
|   |   \---Palettes
|   +---.github
|   +---docs
|   |   +---api
|   |   +---doc
|   |   |   \---ReleaseNotes
|   |   +---fonts
|   |   +---images
|   |   |   +---HostUsingIis
|   |   |   +---Importing
|   |   |   +---Logo
|   |   |   +---Logos
|   |   |   \---other
|   |   +---man
|   |   \---styles
|   +---resources
|   |   \---images
|   |       +---docfx
|   |       +---logos
|   |       \---readme
|   \---src
|       +---bin
|       |   \---roslyn
|       +---docs
|       |   +---Documentation Project
|       |   |   \---The Script Parameter
|       |   +---Manual
|       |   \---Resources
|       |       +---DocProj
|       |       \---Man
|       +---Documentation
|       +---obj
|       |   +---Debug
|       |   |   \---TempPE
|       |   \---Release
|       +---packages
|       |   +---Microsoft.CodeDom.Providers.DotNetCompilerPlatform.2.0.1
|       |   |   +---build
|       |   |   |   +---net45
|       |   |   |   \---net46
|       |   |   +---content
|       |   |   |   +---net45
|       |   |   |   \---net46
|       |   |   +---lib
|       |   |   |   \---net45
|       |   |   \---tools
|       |   |       +---net45
|       |   |       +---Roslyn45
|       |   |       \---RoslynLatest
|       |   +---MSTest.TestAdapter.1.2.0
|       |   |   \---build
|       |   |       +---net45
|       |   |       +---netcoreapp1.0
|       |   |       +---uap10.0
|       |   |       \---_common
|       |   |           +---cs
|       |   |           +---de
|       |   |           +---es
|       |   |           +---fr
|       |   |           +---it
|       |   |           +---ja
|       |   |           +---ko
|       |   |           +---pl
|       |   |           +---pt
|       |   |           +---ru
|       |   |           +---tr
|       |   |           +---zh-Hans
|       |   |           \---zh-Hant
|       |   +---MSTest.TestFramework.1.2.0
|       |   |   \---lib
|       |   |       +---net45
|       |   |       |   +---cs
|       |   |       |   +---de
|       |   |       |   +---es
|       |   |       |   +---fr
|       |   |       |   +---it
|       |   |       |   +---ja
|       |   |       |   +---ko
|       |   |       |   +---pl
|       |   |       |   +---pt
|       |   |       |   +---ru
|       |   |       |   +---tr
|       |   |       |   +---zh-Hans
|       |   |       |   \---zh-Hant
|       |   |       +---netstandard1.0
|       |   |       |   +---cs
|       |   |       |   +---de
|       |   |       |   +---es
|       |   |       |   +---fr
|       |   |       |   +---it
|       |   |       |   +---ja
|       |   |       |   +---ko
|       |   |       |   +---pl
|       |   |       |   +---pt
|       |   |       |   +---ru
|       |   |       |   +---tr
|       |   |       |   +---zh-Hans
|       |   |       |   \---zh-Hant
|       |   |       \---uap10.0
|       |   |           +---cs
|       |   |           +---de
|       |   |           +---es
|       |   |           +---fr
|       |   |           +---it
|       |   |           +---ja
|       |   |           +---ko
|       |   |           +---pl
|       |   |           +---pt
|       |   |           +---ru
|       |   |           +---tr
|       |   |           +---zh-Hans
|       |   |           \---zh-Hant
|       |   \---Newtonsoft.Json.12.0.1
|       |       \---lib
|       |           +---net20
|       |           +---net35
|       |           +---net40
|       |           +---net45
|       |           +---netstandard1.0
|       |           +---netstandard1.3
|       |           +---netstandard2.0
|       |           +---portable-net40+sl5+win8+wp8+wpa81
|       |           \---portable-net45+win8+wp8+wpa81
|       \---Properties
+---Core
|   +---Abatab.Core.Catalog
|   |   +---bin
|   |   |   \---Debug
|   |   +---Component
|   |   +---Definition
|   |   +---Documentation
|   |   +---obj
|   |   |   \---Debug
|   |   |       \---TempPE
|   |   \---Properties
|   +---Abatab.Core.DataExport
|   |   +---bin
|   |   |   \---Debug
|   |   +---Documentation
|   |   +---obj
|   |   |   \---Debug
|   |   |       \---TempPE
|   |   \---Properties
|   +---Abatab.Core.Framework
|   |   +---bin
|   |   |   \---Debug
|   |   +---Documentation
|   |   +---obj
|   |   |   \---Debug
|   |   |       \---TempPE
|   |   \---Properties
|   +---Abatab.Core.Logger
|   |   +---bin
|   |   |   \---Debug
|   |   +---Documentation
|   |   +---obj
|   |   |   \---Debug
|   |   |       \---TempPE
|   |   \---Properties
|   +---Abatab.Core.OptionObject
|   |   +---bin
|   |   |   \---Debug
|   |   +---Documentation
|   |   +---obj
|   |   |   \---Debug
|   |   |       \---TempPE
|   |   \---Properties
|   +---Abatab.Core.OS
|   |   +---bin
|   |   |   \---Debug
|   |   +---Documentation
|   |   +---obj
|   |   |   \---Debug
|   |   |       \---TempPE
|   |   \---Properties
|   +---Abatab.Core.Session
|   |   +---bin
|   |   |   \---Debug
|   |   +---Documentation
|   |   +---obj
|   |   |   \---Debug
|   |   |       \---TempPE
|   |   \---Properties
|   +---Abatab.Core.Templates
|   |   +---bin
|   |   |   \---Debug
|   |   +---obj
|   |   |   \---Debug
|   |   |       \---TempPE
|   |   \---Properties
|   \---Abatab.Core.Utilities
|       +---bin
|       |   \---Debug
|       +---Documentation
|       +---obj
|       |   \---Debug
|       |       \---TempPE
|       \---Properties
+---Module
|   +---Abatab.Module.ProgressNote
|   |   +---Action
|   |   +---bin
|   |   |   \---Debug
|   |   +---Documentation
|   |   +---obj
|   |   |   \---Debug
|   |   |       \---TempPE
|   |   \---Properties
|   +---Abatab.Module.Prototype
|   |   +---bin
|   |   |   \---Debug
|   |   +---Documentation
|   |   +---obj
|   |   |   \---Debug
|   |   |       \---TempPE
|   |   \---Properties
|   +---Abatab.Module.QuickMedicationOrder
|   |   +---bin
|   |   |   \---Debug
|   |   +---Documentation
|   |   +---obj
|   |   |   \---Debug
|   |   |       \---TempPE
|   |   \---Properties
|   \---Abatab.Module.Testing
|       +---Action
|       +---bin
|       |   \---Debug
|       +---Documentation
|       +---obj
|       |   \---Debug
|       |       \---TempPE
|       \---Properties
\---ThirdParty
    \---ScriptLinkStandard
        +---bin
        |   \---Debug
        |       +---net461
        |       +---net48
        |       \---netstandard2.0
        +---Helpers
        |   +---Serialize
        |   \---Transform
        +---Interfaces
        +---obj
        |   \---Debug
        |       +---net461
        |       +---net48
        |       \---netstandard2.0
        \---Objects
```












## Overview

```#text
+---Abatab                      Abatab
+---Core                        Abatab Core components
+---Module                      Abatab Module components
+---ThirdParty                  Abatab third-party components
```

<br>

***

<br>

# Abatab



## Abatab\\.github\



## Abatab\docs\

The `docs\` directory contains the output from DocFX when Abatab is built, and is used as the source for GitHub pages.

```#text
+---docs
|   +---api               API documentation sources
|   +---doc               Abatab documentation sources
|   |   \---ReleaseNotes  Abatab version release notes
|   +---fonts             Fonts for DocFX documents
|   +---images            Images for DocFX documents
|   +---man               Abatab Manual sources
|   \---styles            Styles for DocFX documents
```

## Abatab\src\

The `src\` directory contains the main Abatab source code. Some standard project directories are not listed here.

```#text
|   \---src                               Abatab main source code
|       +---bin                           Abatab build results
|       +---docs                          DocFX documenation sources
|       |   \---Documentation Project     The Abatab Documentation Project
|       +---Documentation                 XML documentation
|       +---Properties                    Local Settings.settings file located here
```

***

<div align="center">

  This document is part of the [Abatab Documentation Project](../Abatab%20Documentation%20Project.md).

  <h5>
    Last updated: 230316.0938
  </h5>

</div>
